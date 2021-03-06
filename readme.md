- sqllocal db start
- dotnet ef database update
- source ./SqlServerEnv.sh
- dotnet run

docker run --rm -e DATABASE_SERVICE_HOST=172.20.10.2 -e MSSQL_DATABASE=mydatabase -e MSSQL_USER=sa -e MSSQL_PASSWORD="StrongPassw0rd" -p 7616:80 wiziah/cu-final:latest --name cu-final

sqllocaldb stop

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=StrongPassw0rd' -p 1433:1433 --name ms-sql -d mcr.microsoft.com/mssql/server:2017-latest

kubectl create secret generic mssql-pass --from-literal=SA_PASSWORD="StrongPassw0rd"

kubectl port-forward svc/mssql-linux-db-svc 1433:1433


# Get up and running
Set the Environment Variables which points to that database and build and run the code against it:

```
DATABASE_SERVICE_HOST=127.0.0.1
export DATABASE_SERVICE_HOST
MSSQL_DATABASE=mydatabase
export MSSQL_DATABASE
MSSQL_USER=sa
export MSSQL_USER
MSSQL_PASSWORD="StrongPassw0rd"
export MSSQL_PASSWORD
dotnet restore
dotnet run
```
## Docker (usin docker hub)
``` docker run --name cu-final -P -d wiziah/cu-final ```


# Contoso University sample app

Contoso University demonstrates how to use Entity Framework Core in an
ASP.NET Core MVC web application.

## Build it from scratch

You can build the application by following the steps in [a series of tutorials](https://docs.microsoft.com/aspnet/core/data/ef-mvc/intro).

## Download it

Download the [completed project](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-mvc/intro/samples/cu-final) from GitHub by downloading or cloning the [aspnet/Docs repository](https://github.com/aspnet/Docs) and navigating to `aspnetcore\data\ef-mvc\intro\samples\cu-final` in your local file system.  After downloading the project, create the database by entering `dotnet ef database update` at a command-line prompt. As an alternative you can use **Package Manager Console** -- for more information, see [Command-line interface (CLI) vs. Package Manager Console (PMC)](https://docs.microsoft.com/aspnet/core/data/ef-mvc/migrations#command-line-interface-cli-vs-package-manager-console-pmc).
