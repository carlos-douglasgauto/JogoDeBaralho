# Estágio de Compilação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia os arquivos e restaura as dependências
COPY . .
RUN dotnet restore

# Compila o projeto
RUN dotnet publish -c Release -o out

# Estágio de Execução
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# IMPORTANTE: Verifique se o nome abaixo é exatamente o nome do seu arquivo .csproj
ENTRYPOINT ["dotnet", "backend.dll"]