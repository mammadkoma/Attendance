# Attendance
A templated project for asp.net core 6 blazor wasm. (Persian and RTL)

1. Download the project
2. Open it by Visual Studio 2022 or VS Code
3. Open PowerShell in **Server** folder path (I recommend install "windows terminal" from Microsoft Store)
4. Execute this command in your powershell for creating sql server database in your .\SQLEXPRESS instance : dotnet ef database update
5. If you want to edit or add database tables execute this command in your powershell for adding a new migration to server/data/migrations folder : dotnet ef migrations add createDb -o data/migrations
6. If you have not sql server database .\SQLEXPRESS instance , install sql server express from this link : https://go.microsoft.com/fwlink/?linkid=866658
7. If you want to create the DataBase in your own sql server instance , edit the connection string in this file : Server/appsettings.json (line 10) , then execute dotnet ef database update command