# 1. Base Stage: Use ASP.NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7098

# 2. Build Stage: Use .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2.1. Copy Project Files and Restore Dependencies
COPY ["Presentation/Presentation.csproj", "Presentation/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application.Tests/Application.Tests.csproj", "Application.Tests/"]
RUN dotnet restore "Presentation/Presentation.csproj"

# 2.2. Copy All Source Files and Build
COPY . .
WORKDIR "/src/Presentation"
RUN dotnet build "Presentation.csproj" -c Release -o /app/build

# 2.3. Run Tests
WORKDIR "/src/Application.Tests"
RUN dotnet test --no-build --verbosity normal

# 3. Publish Stage
FROM build AS publish
WORKDIR "/src/Presentation"
RUN dotnet publish "Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Final Stage: Development with Hot Reload
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# 4.1. Copy Source from Build Stage
COPY --from=build /src /app

# 4.3. Entrypoint for Hot Reload
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:7098"]
