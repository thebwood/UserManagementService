#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserManagementService.Api/UserManagementService.Api.csproj", "UserManagementService.Api/"]
COPY ["UserManagementService.Domain/UserManagementService.Domain.csproj", "UserManagementService.Domain/"]
COPY ["UserManagementService.Infrastructure/UserManagementService.Infrastructure.csproj", "UserManagementService.Infrastructure/"]
COPY ["UserManagementService.Library/UserManagementService.Library.csproj", "UserManagementService.Library/"]
RUN dotnet restore "./UserManagementService.Api/./UserManagementService.Api.csproj"
COPY . .
WORKDIR "/src/UserManagementService.Api"
RUN dotnet build "./UserManagementService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserManagementService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementService.Api.dll"]