# Dockerfile for UI Console Application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Скопируем файл решения и все .csproj файлы
COPY UI/UI.sln ./UI/
COPY OrderExcecutorApiClient/ApiClient.csproj OrderExcecutorApiClient/
COPY UI/UI.csproj UI/
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY OrderExcecutor/OrderExcecutor.csproj OrderExcecutor/

# Выполняем dotnet restore
RUN dotnet restore ./UI/UI.sln

# Копируем оставшиеся файлы
COPY . .

# Публикуем UI
WORKDIR /src/UI
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./ 

ENTRYPOINT ["dotnet", "UI.dll"]

