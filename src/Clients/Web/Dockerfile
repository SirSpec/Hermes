ARG NET_VERSION

FROM mcr.microsoft.com/dotnet/aspnet:${NET_VERSION} AS base
WORKDIR /app
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/sdk:${NET_VERSION} AS publish
ARG CONFIGURATION
WORKDIR /src
COPY . .
RUN dotnet restore
WORKDIR /src/src/Clients/Web
RUN dotnet publish "Web.csproj" --configuration ${CONFIGURATION} --output /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]
