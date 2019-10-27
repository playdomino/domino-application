FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DominoApplication.Api/DominoApplication.Api.csproj", "DominoApplication.Api/"]
RUN dotnet restore "DominoApplication.Api/DominoApplication.Api.csproj"
COPY . .
WORKDIR "/src/DominoApplication.Api"
RUN dotnet build "DominoApplication.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DominoApplication.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DominoApplication.Api.dll"]
