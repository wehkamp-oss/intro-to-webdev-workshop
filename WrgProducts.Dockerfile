#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev binutils
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WRG.Products.Service/WRG.Products.Service.csproj", "src/WRG.Products.Service/"]
RUN dotnet restore "./src/WRG.Products.Service/WRG.Products.Service.csproj"
COPY . .
WORKDIR "/src/src/WRG.Products.Service"
RUN dotnet build "./WRG.Products.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WRG.Products.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./WRG.Products.Service"]