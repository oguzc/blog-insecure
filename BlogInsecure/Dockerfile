FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY BlogInsecure/BlogInsecure.csproj BlogInsecure/
RUN dotnet restore BlogInsecure/BlogInsecure.csproj
COPY . .
WORKDIR /src/BlogInsecure
RUN dotnet build BlogInsecure.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BlogInsecure.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlogInsecure.dll"]
