#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/UniversityAPI/Dockerfile
COPY ["UniversityAPI/UniversityAPI.csproj", "UniversityAPI/"]
RUN dotnet restore "UniversityAPI/UniversityAPI.csproj"
COPY . .
WORKDIR "/src/UniversityAPI"
RUN dotnet build "UniversityAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniversityAPI.csproj" -c Release -o /app/publish
========
COPY ["PassportAPI/PassportAPI.csproj", "PassportAPI/"]
RUN dotnet restore "PassportAPI/PassportAPI.csproj"
COPY . .
WORKDIR "/src/PassportAPI"
RUN dotnet build "PassportAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PassportAPI.csproj" -c Release -o /app/publish
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Dockerfile

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
<<<<<<<< HEAD:MilitaryRecruitmentMicroServiceV0.1/UniversityAPI/Dockerfile
ENTRYPOINT ["dotnet", "UniversityAPI.dll"]
========
ENTRYPOINT ["dotnet", "PassportAPI.dll"]
>>>>>>>> c4c9bd9f6f6df766c31863df9e2fede3507db9a2:MilitaryRecruitmentMicroServiceV0.1/PassportAPI/Dockerfile
