FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 8082/tcp
ENV ASPNETCORE_URLS http://*:8082

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/Services/Blog.Api
RUN dotnet restore
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Blog.Api.dll"]
