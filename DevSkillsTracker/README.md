# DevSkills Tracker

A Razor Pages web app built in .NET 8 for tracking developer skill progression.

## Features
- Register/Login (ASP.NET Identity)
- Add/Edit/Delete skills
- Track learning sessions with time logs and notes
- Uses SQLite via Entity Framework Core

## Getting Started
```bash
dotnet restore
dotnet ef database update
dotnet run
```

## Tech Stack
- .NET 8
- Razor Pages
- SQLite
- ASP.NET Identity
- EF Core