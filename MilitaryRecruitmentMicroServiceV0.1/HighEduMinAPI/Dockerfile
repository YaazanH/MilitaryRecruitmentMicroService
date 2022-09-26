#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HighEduMinAPI/HighEduMinAPI.csproj", "HighEduMinAPI/"]
RUN dotnet restore "HighEduMinAPI/HighEduMinAPI.csproj"
COPY . .
WORKDIR "/src/HighEduMinAPI"
RUN dotnet build "HighEduMinAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HighEduMinAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HighEduMinAPI.dll"]