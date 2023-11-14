#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutoMoreira.API/AutoMoreira.API.csproj", "AutoMoreira.API/"]
COPY ["AutoMoreira.Persistence/AutoMoreira.Persistence.csproj", "AutoMoreira.Persistence/"]
COPY ["AutoMoreira.Core/AutoMoreira.Core.csproj", "AutoMoreira.Core/"]
RUN dotnet restore "AutoMoreira.API/AutoMoreira.API.csproj"
COPY . .
WORKDIR "/src/AutoMoreira.API"
RUN dotnet build "AutoMoreira.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoMoreira.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoMoreira.API.dll"]