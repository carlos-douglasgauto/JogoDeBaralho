using Moq;
using Xunit;
using backend.Services;
using backend.Clients;

namespace backend.Tests;

public class JogoServiceTests
{
	[Fact]
	public async Task IniciarJogo_DeveDistribuirCincoCartasPorJogador()
	{
		// Arrange - Configura o "dublê" da API
		var mockClient = new Mock<DeckOfCardsClient>(new HttpClient());
		var numJogadores = 2;

		mockClient.Setup(c => c.CreateDeck())
				  .ReturnsAsync(new DeckResponse { Id = "test_deck" });

		mockClient.Setup(c => c.DrawCards(It.IsAny<string>(), 5))
				  .ReturnsAsync(new DrawResponse
				  {
					  Cards = new List<Carta> { new(), new(), new(), new(), new() }
				  });

		var service = new JogoService(mockClient.Object);

		// Act - Executa a lógica
		var resultado = await service.IniciarJogo(numJogadores);

		// Assert - Verifica se a regra de 5 cartas foi seguida
		Assert.Equal(numJogadores, resultado.Count);
		Assert.All(resultado, j => Assert.Equal(5, j.Cartas.Count));
	}
}