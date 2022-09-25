#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HealthMinAPI/HealthMinAPI.csproj", "HealthMinAPI/"]
RUN dotnet restore "HealthMinAPI/HealthMinAPI.csproj"
COPY . .
WORKDIR "/src/HealthMinAPI"
RUN dotnet build "HealthMinAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthMinAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthMinAPI.dll"]