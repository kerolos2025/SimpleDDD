# Migration Guide for Multi-Layer .NET Application

Simple steps to add migrations and update database in a DDD/Clean Architecture project.

---

## Prerequisites

### 1. Install EF Core Design Package in API (Startup Project)

Add this NuGet package to your **API project** (the startup project):

```bash
dotnet add API/API.csproj package Microsoft.EntityFrameworkCore.Design --version 9.0.15
