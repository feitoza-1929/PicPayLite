FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 5048
EXPOSE 5049

ENV ASPNETCORE_URLS=http://+:5048
ENV ASPNETCORE_HTTPS_PORT=http://+:5049


# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["PicPayLite.csproj", "./"]
RUN dotnet restore ./PicPayLite.csproj
COPY . .
WORKDIR "/src/."
RUN dotnet build ./PicPayLite.csproj --configuration Release --no-restore

FROM build AS publish
RUN dotnet publish ./PicPayLite.csproj -c Release --no-build -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PicPayLite.dll", "--server.urls", "http://+:5048;https://+:5049"]