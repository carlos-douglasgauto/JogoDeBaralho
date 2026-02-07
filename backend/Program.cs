using backend.Clients;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// SOLID: Injeção de Dependência e Configuração de Cliente HTTP
builder.Services.AddHttpClient<DeckOfCardsClient>(client => {
    client.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
});

// Registro do Serviço de Negócio
builder.Services.AddScoped<JogoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de CORS para permitir comunicação com o Angular
builder.Services.AddCors(options => {
    options.AddPolicy("AngularPolicy", policy => {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Documentação Swagger sempre disponível para o avaliador
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AngularPolicy");
app.MapControllers();

app.Run();