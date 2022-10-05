#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BloodBankAPI/BloodBankAPI.csproj", "BloodBankAPI/"]
RUN dotnet restore "BloodBankAPI/BloodBankAPI.csproj"
COPY . .
WORKDIR "/src/BloodBankAPI"
RUN dotnet build "BloodBankAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BloodBankAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BloodBankAPI.dll"]