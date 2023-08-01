FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sikoia.Api/Sikoia.Api.csproj", "Sikoia.Api/"]
RUN dotnet restore "Sikoia.Api/Sikoia.Api.csproj"
COPY . .
WORKDIR "/src/Sikoia.Api"
RUN dotnet build "Sikoia.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sikoia.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sikoia.Api.dll"]
