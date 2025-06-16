# Base stage (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5201

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["N-ThaiSmart.csproj", "."]
RUN dotnet restore "./N-ThaiSmart.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./N-ThaiSmart.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./N-ThaiSmart.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage (production)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# บอกให้แอปฟังทุก interface และพอร์ต 5201
ENV ASPNETCORE_URLS=http://+:5201

ENTRYPOINT ["dotnet", "N-ThaiSmart.dll"]
