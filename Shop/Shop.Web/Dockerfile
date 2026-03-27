FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Shop.Web/Shop.Web.csproj", "Shop.Web/"]
COPY ["Shop.Contracts/Shop.Contracts.csproj", "Shop.Contracts/"]
COPY ["Shop.Data/Shop.Data.csproj", "Shop.Data/"]
COPY ["Shop.Db/Shop.Db.csproj", "Shop.Db/"]
COPY ["Shop.Services/Shop.Services.csproj", "Shop.Services/"]

RUN dotnet restore "Shop.Web/Shop.Web.csproj"

COPY . .
WORKDIR "/src/Shop.Web"
RUN dotnet publish "Shop.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Shop.Web.dll"]