# Dockerfile for OrderExecutor Web API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файл решения и все .csproj файлы, чтобы dotnet restore отработал корректно
COPY UI/UI.sln ./UI/
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY OrderExcecutor/OrderExcecutor.csproj OrderExcecutor/
COPY OrderExcecutorApiClient/ApiClient.csproj OrderExcecutorApiClient/
COPY UI/UI.csproj UI/

# Выполняем dotnet restore на основе файла решения
RUN dotnet restore ./UI/UI.sln

# Копируем все оставшиеся файлы
COPY . .

# Устанавливаем dotnet-ef и запускаем миграции
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations add InitialCreate --project Infrastructure --startup-project OrderExcecutor

# Публикуем API
WORKDIR /src/OrderExcecutor
RUN dotnet publish -c Release -o /app

# Финальный образ для выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "OrderExcecutor.dll"]

