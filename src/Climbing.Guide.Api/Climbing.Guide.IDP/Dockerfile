FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Climbing.Guide.IDP/Climbing.Guide.IDP.csproj", "Climbing.Guide.IDP/"]
RUN dotnet restore "Climbing.Guide.IDP/Climbing.Guide.IDP.csproj"
COPY . .
WORKDIR "/src/Climbing.Guide.IDP"
RUN dotnet build "Climbing.Guide.IDP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Climbing.Guide.IDP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Climbing.Guide.IDP.dll"]