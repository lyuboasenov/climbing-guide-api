FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

# Copy necessary files and restore & build as distinct layer
FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src

# Copy necessary files and restore as distinct layer
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose ports
EXPOSE 80/tcp
EXPOSE 443/tcp
ENV ASPNETCORE_URLS http://*;https://*

# Start
ENTRYPOINT ["dotnet", "Climbing.Guide.Api.Services.dll"]