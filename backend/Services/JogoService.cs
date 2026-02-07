using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;   
using backend.Clients;

namespace backend.Services
{
    public class JogoService
    {
        private readonly DeckClient _client;

        public JogoService(DeckClient client)
        {
            _client = client;
        }

        public async Task<List<Jogador>> IniciarJogo(int numJogadores)
        {
            var deck = await _client.CreateDeck();

            if (deck == null || string.IsNullOrEmpty(deck.Id))
            {
                throw new Exception("Não foi possível criar o baralho.");
            }

            var jogadores = new List<Jogador>();

            for (int i = 1; i <= numJogadores; i++)
            {
                var draw = await _client.DrawCards(deck.Id, 5);

                jogadores.Add(new Jogador
                {
                    Id = i,
                    Cartas = draw?.Cards ?? new List<Carta>()
                });
            }

            return jogadores;
        }
    }
}
