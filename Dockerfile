FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./src /src
WORKDIR /src/Services/CloudStorageService/Presentation
RUN dotnet publish "CloudStorageService.Presentation.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CloudStorageService.Presentation.dll"]