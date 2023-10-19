# ASP.NET Core Web API Basics

This repository is a simple introduction to building a Web API using ASP.NET Core. It includes controllers and models as a starting point for your API development journey.

## Installation

Before getting started, ensure you have the following packages installed. You can use NuGet Package Manager or the .csproj file to add these packages to your project.

```bash
Install-Package Microsoft.Extensions.DependencyInjection
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Relational
Install-Package MySqlConnector
Install-Package Pomelo.EntityFrameworkCore.MySql
```

## Getting Started

Follow these steps to set up your ASP.NET Core Web API project:

1. Create an ASP.NET Core Web API project.
2. Modify the `launchSettings.json` file by changing the port to 5000 and setting `launchBrowser` to `false`.
3. Choose IIS Express for project compilation.
4. Delete the default controller folder and the default APIs/models.
5. Create a `features` folder, and within it, create subfolders for each database table.
6. For example, if you have a `User` table, create a `User` folder and store models, controllers, and DTOs within it.
7. Create a class file in the `User` folder to represent the table's properties.
8. Mark non-nullable properties by adding `= null!` to class types and strings.
9. Add the Required Annotation to properties like `Id` or `ForeignKey`, e.g., `[Key]` or `[ForeignKey(nameof(CategoryId))]`.
10. Change the data type of primary keys from `int` to `long`.
11. Store your database connection string in the `appsettings.json` file as follows:

```json
"ConnectionStrings": {
    "Default": "server=localhost;port=3306;database=app_db;uid=root;password="
}
```

12. Create a `DatabaseContext` file and set up the constructor, including adding all the database tables to it.
13. Update the `program.cs` file as shown below:

```csharp
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});
```

14. Migrate your changes by opening the Package Manager Console and running the following commands:

```bash
add-migration "migrationnamewithoutspace"
update-database
```

15. Create controllers within the specific `features` folder for your API endpoints.

Now you're ready to start building your ASP.NET Core Web API. Happy coding!
