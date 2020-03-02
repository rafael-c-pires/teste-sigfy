FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["segfy.youtube.frontend/segfy.youtube.frontend.csproj", "segfy.youtube.frontend/"]
RUN dotnet restore "segfy.youtube.frontend/segfy.youtube.frontend.csproj"
COPY . .
WORKDIR /src/segfy.youtube.frontend
RUN dotnet build "segfy.youtube.frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "segfy.youtube.frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "segfy.youtube.frontend.dll"]
