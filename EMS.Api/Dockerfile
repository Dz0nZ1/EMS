FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EMS.Api/EMS.Api.csproj", "EMS.Api/"]
COPY ["EMS.Application/EMS.Application.csproj", "EMS.Application/"]
COPY ["EMS.Domain/EMS.Domain.csproj", "EMS.Domain/"]
COPY ["EMS.Infrastructure/EMS.Infrastructure.csproj", "EMS.Infrastructure/"]
RUN dotnet restore "EMS.Api/EMS.Api.csproj"
COPY . .
WORKDIR "/src/EMS.Api"
RUN dotnet build "EMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMS.Api.dll"]
