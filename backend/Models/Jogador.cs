namespace backend.Models;

public class Jogador
{
    public int Id { get; set; }
    public List<Carta> Cartas { get; set; } = new();
}