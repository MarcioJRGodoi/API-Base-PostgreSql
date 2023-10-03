#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API_PostgreSql/API_PostgreSql.csproj", "API_PostgreSql/"]
RUN dotnet restore "API_PostgreSql/API_PostgreSql.csproj"
COPY . .
WORKDIR "/src/API_PostgreSql"
RUN dotnet build "API_PostgreSql.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_PostgreSql.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS="https://*$PORT" dotnet API_PostgreSql.dll
