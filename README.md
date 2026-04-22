# Simple Way to Add Migration and Update Database (Multi-Layer App)

## 1) Install NuGet Package in API Project

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.15" />
```

## 2) Install EF Core CLI Tool

```bash
dotnet tool install --global dotnet-ef --version 9.0.15
```

## 3) Add Migration

```bash
dotnet ef migrations add modifytables --project Infrastructure/Infrastructure.csproj --startup-project API/API.csproj
```

## 4) Update Database

```bash
dotnet ef database update --project Infrastructure/Infrastructure.csproj --startup-project API/API.csproj
```

## Notes

* `--project` points to the project that contains `DbContext` and migrations.
* `--startup-project` points to the runnable project (API).
* Replace `modifytables` with your migration name.
