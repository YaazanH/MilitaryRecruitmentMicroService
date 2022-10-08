#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CourtAPI/CourtAPI.csproj", "CourtAPI/"]
RUN dotnet restore "CourtAPI/CourtAPI.csproj"
COPY . .
WORKDIR "/src/CourtAPI"
RUN dotnet build "CourtAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourtAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourtAPI.dll"]
