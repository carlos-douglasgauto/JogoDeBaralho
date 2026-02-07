namespace backend.Models;

[cite_start]// Para o endpoint /new/shuffle/ [cite: 7]
public class DeckResponse
{
    public string Deck_Id { get; set; } = string.Empty;
    public bool Shuffled { get; set; }
    public int Remaining { get; set; }
}

[cite_start]// Para o endpoint /draw/ [cite: 37]
public class DrawResponse
{
    public string Deck_Id { get; set; } = string.Empty;
    public List<Carta> Cards { get; set; } = new();
    public int Remaining { get; set; }
}