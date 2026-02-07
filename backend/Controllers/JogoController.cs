using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
	private readonly JogoService _jogoService;
	public JogoController(JogoService jogoService) => _jogoService = jogoService;

	[HttpGet("/jogar")]
	public async Task<IActionResult> Jogar([FromQuery] int numJogadores)
	{
		if (numJogadores <= 0) return BadRequest("Número de jogadores inválido.");
		var resultado = await _jogoService.IniciarJogo(numJogadores);
		return Ok(resultado);
	}
}