# Use the ASP.NET runtime image for the base layer 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7098

# Use the SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY ["Presentation/Presentation.csproj", "Presentation/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application.Tests/Application.Tests.csproj", "Application.Tests/"]
RUN dotnet restore "Presentation/Presentation.csproj"

# Copy the entire source and build the project
COPY . .
WORKDIR "/src/Presentation"
RUN dotnet build "Presentation.csproj" -c Release -o /app/build

# Run tests
WORKDIR "/src/Application.Tests"
RUN dotnet test --no-build --verbosity normal

# Publish the application to a folder
FROM build AS publish
WORKDIR "/src/Presentation"
RUN dotnet publish "Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the SDK image again for the final stage to enable hot reload
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS final
WORKDIR /app

# Copy the source code to allow for hot reload
COPY . .

# Set entrypoint to use dotnet watch for hot reload
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:7098"]
