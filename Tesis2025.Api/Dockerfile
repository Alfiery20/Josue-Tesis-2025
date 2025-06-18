# Imagen base para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR webapp

EXPOSE 80
EXPOSE 5024

# Copiar solución y .csproj (rutas ajustadas para Dockerfile dentro de Tesis2025.Api)
COPY ../Tesis-2025.sln ./
COPY ../Tesis2025.Api/Tesis2025.Api.csproj ./Tesis2025.Api/
COPY ../Tesis2025.Application/Tesis2025.Application.csproj ./Tesis2025.Application/
COPY ../Tesis2025.Domain/Tesis2025.Domain.csproj ./Tesis2025.Domain/
COPY ../Tesis2025.Infrastructure/Tesis2025.Infrastructure.csproj ./Tesis2025.Infrastructure/
COPY ../Tesis2025.Persistence/Tesis2025.Persistence.csproj ./Tesis2025.Persistence/

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código fuente (desde la raíz)
COPY ../ ./

# Publicar el proyecto API
RUN dotnet publish -c Release -o out

# Imagen final para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT ["dotnet", "Tesis2025.Api.dll"]