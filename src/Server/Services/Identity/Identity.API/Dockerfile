#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ENV ROOT_PATH=./Server/Services/Identity/Identity.API
WORKDIR /src
COPY ["./", "${ROOT_PATH}/"]
RUN dotnet restore "${ROOT_PATH}/Identity.API.csproj"

COPY . .
WORKDIR /src
RUN dotnet build "${ROOT_PATH}/Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "${ROOT_PATH}/Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]
