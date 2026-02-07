namespace backend.Models;

using System.Text.Json.Serialization;

public class DeckResponse
{
    [JsonPropertyName("deck_id")]
    public string Id { get; set; } = string.Empty;

    public bool Shuffled { get; set; }
    public int Remaining { get; set; }
}

public class DrawResponse
{
    [JsonPropertyName("deck_id")]
    public string DeckId { get; set; } = string.Empty;

    public List<Carta> Cards { get; set; } = new();
    public int Remaining { get; set; }
}