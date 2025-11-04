# Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia apenas o csproj e restaura dependências
COPY ["PayFlow.API/PayFlow.API.csproj", "PayFlow.API/"]
RUN dotnet restore "PayFlow.API/PayFlow.API.csproj"

# Copia o restante do código e publica
COPY . .
RUN dotnet publish "PayFlow.API/PayFlow.API.csproj" -c Release -o /app/publish

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PayFlow.API.dll"]