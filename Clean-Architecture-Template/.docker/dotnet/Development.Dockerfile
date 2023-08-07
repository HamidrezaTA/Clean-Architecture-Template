#################### base ####################
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

WORKDIR /app
EXPOSE 80

#################### build ####################
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ./ ./
RUN dotnet restore
WORKDIR /src/

#################### publish ####################
FROM build AS publish

RUN dotnet publish -c Release -o /app/publish

#################### run ####################
FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]