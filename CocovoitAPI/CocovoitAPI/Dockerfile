# On utilise l'image officielle du SDK .NET Core pour build l'application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# On copie le fichier .csproj et on restaure les dépendances
COPY *.csproj ./
RUN dotnet restore

# On copie le reste des fichiers
COPY . .

# On compile l'application
RUN dotnet publish -c Release -o out

# On crée l'image de l'application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Installation de node_exporter pour exposer les métriques Prometheus
RUN apt-get update \
    && apt-get install -y --no-install-recommends wget ca-certificates \
    && wget -q https://github.com/prometheus/node_exporter/releases/download/v1.8.1/node_exporter-1.8.1.linux-amd64.tar.gz \
    && tar -xzf node_exporter-1.8.1.linux-amd64.tar.gz \
    && mv node_exporter-1.8.1.linux-amd64/node_exporter /usr/local/bin/ \
    && rm -rf node_exporter-1.8.1.linux-amd64* \
    && apt-get purge -y --auto-remove wget \
    && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/out ./
EXPOSE 80 9100

# Démarrage de l'API et de node_exporter
ENTRYPOINT ["sh", "-c", "node_exporter & exec dotnet CocovoitAPI.dll"]
