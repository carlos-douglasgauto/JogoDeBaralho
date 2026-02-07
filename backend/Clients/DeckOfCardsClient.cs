namespace backend.Clients;

using System.Net.Http.Json;
using backend.Models;

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