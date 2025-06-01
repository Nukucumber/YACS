FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG ROOT_DIR="."
WORKDIR /src
COPY ${ROOT_DIR}/src /src
WORKDIR /src/CloudStorageService/Web
RUN dotnet publish "CloudStorageService.Web.csproj" -c Release -o /app/publish


FROM base AS final
ARG CONFIG_DIR=""
WORKDIR /app
COPY --from=build /app/publish .
COPY ${CONFIG_DIR}/ /app/
RUN ls /app -la
ENTRYPOINT ["dotnet", "CloudStorageService.Web.dll"]