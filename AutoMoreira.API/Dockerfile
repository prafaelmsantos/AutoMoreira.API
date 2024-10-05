#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release

#Add GitHub NuGet sources
ENV GITHUB_PASSWORD=password

WORKDIR /src
COPY ["AutoMoreira.API/AutoMoreira.API.csproj", "AutoMoreira.API/"]
COPY ["AutoMoreira.Infrastructure/AutoMoreira.Infrastructure.csproj", "AutoMoreira.Infrastructure/"]
COPY ["AutoMoreira.Core/AutoMoreira.Core.csproj", "AutoMoreira.Core/"]
RUN dotnet nuget add source -n github -u AZ -p ${GITHUB_PASSWORD} --store-password-in-clear-text https://nuget.pkg.github.com/prafaelmsantos/index.json
RUN dotnet restore "./AutoMoreira.API/./AutoMoreira.API.csproj"
COPY . .
WORKDIR "/src/AutoMoreira.API"
RUN dotnet build "./AutoMoreira.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AutoMoreira.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoMoreira.API.dll"]