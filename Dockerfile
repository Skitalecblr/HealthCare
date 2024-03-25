#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV DOTNET_URLS=http://+:5000

WORKDIR /src
COPY ["HealthCareApi/HealthCareApi.csproj", "HealthCareApi/"]
COPY ["HealthCareCore/HealthCareCore.csproj", "HealthCareCore/"]
RUN dotnet restore "HealthCareApi/HealthCareApi.csproj"
COPY . .
WORKDIR "/src/HealthCareApi"
RUN dotnet build "HealthCareApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthCareApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthCareApi.dll"]