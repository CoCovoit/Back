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
COPY --from=build /app/out ./
EXPOSE 80

# On configure le point d'entrée pour démarrer l'application
ENTRYPOINT ["dotnet", "CocovoitAPI.dll"]