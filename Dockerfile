# ===============================================
# Stage 1: Build
# ===============================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["Calculators.sln", "./"]
COPY ["Calculators.Core/Calculators.Core.csproj", "Calculators.Core/"]
COPY ["Calculators.Infrastructure/Calculators.Infrastructure.csproj", "Calculators.Infrastructure/"]
COPY ["Calculators.Web/Calculators.Web.csproj", "Calculators.Web/"]

# Restore dependencies
RUN dotnet restore

# Copy entire source and publish
COPY . . 
WORKDIR "/src/Calculators.Web"
RUN dotnet publish -c Release -o /app/publish

# ===============================================
# Stage 2: Runtime
# ===============================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Start app
ENTRYPOINT ["dotnet", "Calculators.Web.dll"]
