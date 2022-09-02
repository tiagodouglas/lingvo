##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install cultures (same approach as Alpine SDK image)
RUN apk add --no-cache icu-libs

# Disable the invariant mode (set in base image)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR ../src
COPY ["src/Lingvo.API/Lingvo.API.csproj", "src/Lingvo.API/"]
COPY ["src/Lingvo.Application/Lingvo.Application.csproj", "src/Lingvo.Application/"]
COPY ["src/Lingvo.Domain/Lingvo.Domain.csproj", "src/Lingvo.Domain/"]
COPY ["src/Lingvo.Infrastructure/Lingvo.Infrastructure.csproj", "src/Lingvo.Infrastructure/"]
COPY . .
WORKDIR "src/Lingvo.API"

FROM build AS publish
RUN dotnet publish "Lingvo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lingvo.API.dll"]