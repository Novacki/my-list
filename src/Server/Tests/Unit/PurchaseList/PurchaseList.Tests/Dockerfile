#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Server/Tests/Unit/PurchaseList/PurchaseList.Tests/PurchaseList.Tests.csproj", "src/Server/Tests/Unit/PurchaseList/PurchaseList.Tests/"]
COPY . .

WORKDIR "/src/src/Server/Tests/Unit/PurchaseList/PurchaseList.Tests/"
RUN dotnet test "PurchaseList.Tests.csproj" 

ENTRYPOINT ["dotnet", "test"]