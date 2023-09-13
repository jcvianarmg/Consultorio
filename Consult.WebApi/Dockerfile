#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Consult.WebApi/Consult.WebApi.csproj", "Consult.WebApi/"]
COPY ["Consult.Core/Consult.Core.csproj", "Consult.Core/"]
COPY ["Consult.Data/Consult.Data.csproj", "Consult.Data/"]
RUN dotnet restore "Consult.WebApi/Consult.WebApi.csproj"
COPY . .
WORKDIR "/src/Consult.WebApi"
RUN dotnet build "Consult.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consult.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consult.WebApi.dll"]