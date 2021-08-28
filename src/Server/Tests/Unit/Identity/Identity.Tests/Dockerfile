#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Server/Tests/Unit/Identity/Identity.Tests/Identity.Tests.csproj", "Server/Tests/Unit/Identity/Identity.Tests/"]
COPY . .

WORKDIR "/src/Server/Tests/Unit/Identity/Identity.Tests/"
RUN dotnet test "Identity.Tests.csproj" 

ENTRYPOINT ["dotnet", "test"]