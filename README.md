# 0) Установка под Ubuntu (через консоль)
## 0.1 .NET 8 SDK
sudo apt-get update
sudo apt-get install -y wget gpg apt-transport-https

wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0
dotnet --version

## 0.2 Node.js (через nvm) + npm
sudo apt-get install -y curl
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.7/install.sh | bash

### Перезапусти терминал или:
export NVM_DIR="$HOME/.nvm"
. "$NVM_DIR/nvm.sh"

nvm install 20
node -v
npm -v

## 0.3 SQLite CLI (полезно для проверки)
sudo apt-get install -y sqlite3
sqlite3 --version

# 1) Общая структура репозитория

Создадим 1 папку, в ней: backend/ и frontend/.

mkdir StockFlowTest
cd StockFlowTest
mkdir backend frontend

ВЕРСИЯ 1 — Backend на Minimal API (Clean Architecture + DI + EF Core + Dapper + SQLite)

## 1.1 Создаём solution и проекты
cd backend

dotnet new sln -n StockFlowTest

dotnet new classlib -n StockFlowTest.Domain
dotnet new classlib -n StockFlowTest.Application
dotnet new classlib -n StockFlowTest.Infrastructure
dotnet new web -n StockFlowTest.Api   # Minimal API

dotnet sln add StockFlowTest.Domain/StockFlowTest.Domain.csproj
dotnet sln add StockFlowTest.Application/StockFlowTest.Application.csproj
dotnet sln add StockFlowTest.Infrastructure/StockFlowTest.Infrastructure.csproj
dotnet sln add StockFlowTest.Api/StockFlowTest.Api.csproj

### зависимости слоёв (Clean-ish)
dotnet add StockFlowTest.Application/StockFlowTest.Application.csproj reference StockFlowTest.Domain/StockFlowTest.Domain.csproj
dotnet add StockFlowTest.Infrastructure/StockFlowTest.Infrastructure.csproj reference StockFlowTest.Application/StockFlowTest.Application.csproj
dotnet add StockFlowTest.Infrastructure/StockFlowTest.Infrastructure.csproj reference StockFlowTest.Domain/StockFlowTest.Domain.csproj
dotnet add StockFlowTest.Api/StockFlowTest.Api.csproj reference StockFlowTest.Application/StockFlowTest.Application.csproj
dotnet add StockFlowTest.Api/StockFlowTest.Api.csproj reference StockFlowTest.Infrastructure/StockFlowTest.Infrastructure.csproj

##1.2 Ставим пакеты EF Core + Dapper + Swagger
### Infrastructure: EF Core + SQLite + Dapper
dotnet add StockFlowTest.Infrastructure package Microsoft.EntityFrameworkCore --version 8.0.22
dotnet add StockFlowTest.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.22
dotnet add StockFlowTest.Infrastructure package Microsoft.EntityFrameworkCore.Design --version 8.0.22
dotnet add StockFlowTest.Infrastructure package Dapper
dotnet add StockFlowTest.Infrastructure package Microsoft.Data.Sqlite

## Api: swagger
dotnet add StockFlowTest.Api package Swashbuckle.AspNetCore

## tools для миграций EF (глобально)
dotnet tool install --global dotnet-ef
export PATH="$PATH:$HOME/.dotnet/tools"
dotnet ef --version
