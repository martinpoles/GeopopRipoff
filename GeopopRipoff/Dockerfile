# Utilizzare l'immagine di base per ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Utilizzare l'immagine di base per il build SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiare solo il file di progetto e ripristinare le dipendenze
COPY GeopopRipoff.csproj ./
RUN dotnet restore

# Copiare il resto del progetto
COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeopopRipoff.dll"]
