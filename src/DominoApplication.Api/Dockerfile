FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DominoApplication.Api/DominoApplication.Api.csproj", "DominoApplication.Api/"]
COPY ["DominoApplication.Application/DominoApplication.Application.csproj", "DominoApplication.Application/"]
COPY ["DominoApplication.Persistence/DominoApplication.Persistence.csproj", "DominoApplication.Persistence/"]
COPY ["DominoApplication.Domain/DominoApplication.Domain.csproj", "DominoApplication.Domain/"]
RUN dotnet restore "DominoApplication.Api/DominoApplication.Api.csproj"
COPY . .
WORKDIR "/src/DominoApplication.Api"
RUN dotnet build "DominoApplication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DominoApplication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DominoApplication.Api.dll"]