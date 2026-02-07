namespace backend.Models;

public class Carta
{
	public string Code { get; set; } = string.Empty;
	public string Image { get; set; } = string.Empty; // URL da imagem para o Angular exibir [cite: 40]
	public string Value { get; set; } = string.Empty;
	public string Suit { get; set; } = string.Empty;
}