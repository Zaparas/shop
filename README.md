# shop

# Requirements:
* docker & docker-compose 

# Getting started:
* Step 1: build and start the database:
* Step 1.A: Start Docker service on your machine
* Step 1.B: Use the command > docker compose up -d
* Step 2: Run the project using > dotnet watch run

# Usefull Commands:
* Start the project : from the Backend Folder > dotnet watch run
* Create & Start DB : from the Storage Datbase Folder > docker compose up -d 
* Update Databases  : from the Backend Folder > dotnet ef database update


# Packages used:
* dotnet add package Microsoft.EntityFrameworkCore
* dotnet add package Microsoft.EntityFrameworkCore.SqlServer
* dotnet add package Microsoft.EntityFrameworkCore.Design


# special thanks to: 
| Access         | Link          | Assistance | 
| -------------  |:-------------:|:-------------: |
| 2023 August    | https://mahedee.net/how-to-connet-sql-server-from-docker-using-ssms/   | helped find server name - proper naming in general is important name was port |
| 2023 August    | https://stackoverflow.com/questions/43098065/entity-framework-core-dbcontextoptionsbuilder-does-not-contain-a-definition-for | Helped find need for SqlServer lib
| left baz       | right baz     |
