namespace backend.Clients;

using System.Net.Http.Json;

public class DeckOfCardsClient
{
	private readonly HttpClient _httpClient;

	public DeckOfCardsClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<DeckResponse?> CreateDeck()
	{
		return await _httpClient.GetFromJsonAsync<DeckResponse>("new/shuffle/?deck_count=1");
	}

	public async Task<DrawResponse?> DrawCards(string deckId, int count)
	{
		return await _httpClient.GetFromJsonAsync<DrawResponse>($"{deckId}/draw/?count={count}");
	}
}

public class DeckResponse { public string Id { get; set; } = string.Empty; }
public class DrawResponse { public List<Carta> Cards { get; set; } = new(); }
public class Carta { public string Image { get; set; } = string.Empty; public string Value { get; set; } = string.Empty; }