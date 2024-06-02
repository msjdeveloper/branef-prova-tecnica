# Common definitions
ARG BUILD_CONFIGURATION=Release

# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Build environment for compiling solutions
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION
WORKDIR /src

# Copy entire source code directory
COPY ./src .

# Change working directory to the main project
WORKDIR "/src/CompanySystem.API"

# Restore NuGet packages for all projects (potential adjustment)
RUN dotnet restore "CompanySystem.API.csproj"

# Build stage focusing on the main solution (potential adjustment)
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION
RUN dotnet publish "CompanySystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final stage for running the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT ${ASPNETCORE_ENVIRONMENT:-Staging}
ENTRYPOINT ["dotnet", "CompanySystem.API.dll"]