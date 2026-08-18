# Invoice System

## Követelmények

A projekt futtatásához szükséges:

- .NET SDK
- SQL Server
- Visual Studio vagy Visual Studio Code

## Használt csomagok

- Swagger / Swashbuckle
- Entity Framework Core
- QuestPDF
- 
A csomagok  feltepelülnek autómatikusan futtatáskor viszont ha mégsem a lenti parancsokkal fel lehet telepíteni
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
dotnet add package QuestPDF
```

## Adatbázis beállítása

A projekt SQL Server adatbázist használ.

Az `appsettings.json` fájlban található connection stringet a saját SQL Server környezetnek megfelelően kell beállítani:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=InvoiceSystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Az adatbázis szerkezete az alábbi SQL script segítségével hozható létre:

```text
SQL/create_database.sql
```

Entity Framework Core migration használata esetén:

```bash
dotnet ef database update
```

## Projekt futtatása

A projekt mappájában nyiss egy terminált, majd futtasd:

```bash
dotnet restore
```

A szükséges NuGet csomagok letöltése után buildeld a projektet:

```bash
dotnet build
```

Ezután indítsd el az alkalmazást:

```bash
dotnet run
```

## Swagger

Development környezetben a Swagger UI az alábbi címen érhető el:

```text
https://localhost:7083/swagger
```

A portszám eltérhet, ebben az esetben az alkalmazás indításakor megjelenő URL-t kell használni.

## PDF fájlok

A generált PDF számlák az `Output` mappába kerülnek.

Az `Output` mappa automatikusan létrejön, ha még nem létezik.
