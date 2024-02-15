#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CadastralBuildingInfo.Web/CadastralBuildingInfo.WebApi.csproj", "CadastralBuildingInfo.Web/"]
RUN dotnet restore "./CadastralBuildingInfo.Web/./CadastralBuildingInfo.WebApi.csproj"
COPY . .
WORKDIR "/src/CadastralBuildingInfo.Web"
RUN dotnet build "./CadastralBuildingInfo.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CadastralBuildingInfo.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadastralBuildingInfo.WebApi.dll"]