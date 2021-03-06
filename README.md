# BreakingBad .NET 6


### Repository Pattern in ASP.NET Core

- Check first the installed Nuget packages in the csproj file of the projects inside the solution
- Delete WeatherForecast model and controller
- Create entities
- Create dtos
- Add Automapper package
- Configure AutoMapper by creating a mapping
- Create a class that inherit DbContext
- Add service of DbContext 
- Add Connection String for the Database
- Install or update DotNet CLI below:
- dotnet tool install --global dotnet-ef 
- dotnet tool update --global dotnet-ef
- Go to the terminal and go inside the project to run the EF Core commands
- Make sure you are not inside the solution folder, but inside the project folder of the Web API
- Do EF Core migrations below:
- dotnet ef migrations add initial 
- dotnet ef database update 

(VS Package Manager version)
-- Add-Migrations InitialCreate
-- Update-Database

- Allow dev-certs in the local machine below:
- dotnet dev-certs https --clean 
- dotnet dev-certs https
- Create contracts (interfaces) (optional)
- Create repositories (services) (optional)
- Add Scrutor package configure the Startup.cs
- Add Scoped in the Startup.cs for contract and repository
- Add and configure CORS Policy in the Startup.cs
- Add API versioning
- Add Swashbuckle package
- Configure Swagger UI in the Startup.cs
- Create helpers and extensions for API versioning with Swagger UI integration
- Create a base controller name ApiController
- Create todos controller on v1 only using repository pattern 
- inherit the todos controller from ApiController
- Use the repository in todos controller
- Edit the launchSettings.json of the Properties folder from weatherforecast to swagger/index.html
- Add Serilog Nuget packages
- Configure Serilog in the Program.cs
- Create a global exception handler in Startup.cs
- Add Test project
- Add xunit packages
- Add reference to the web api project
- Create a MockData.cs and put it in the Data folder
- Add Fluent Assertions package
- Add test C# file for each controller
- Add test for each HTTP method
- Add books controller without repository pattern
- Add Hangfire packages for chron jobs or scheduled jobs or timer jobs
- Configure Hangfire in the Startup.cs
- Add jobs controller on v1 and v1.1
- Add authentication and authorization
- Start with Entity, Dto, Interface, Service, Helpers, Controller, add JWT Secret in appsettings.json, register Auth, IUserService/UserService, and add JwtMiddleware in the Startup.cs
- Add authorize attribute in the base controller ApiController.cs
- Add health checks in Startup.cs
- Install redis on your local machine
- To install on macbook, run the command below:
- brew install redis
- Add Redis Cache
- Configure Startup.cs
- Configure appsettings.json
- Configure ApplicationDbContext
- Add Customers controller on v1 and v2 without using repository pattern
- Update the database using dotnet cli
- Add code coverage packages
- Run commands below:
- dotnet tool install -g dotnet-reportgenerator-globaltool
- dotnet test --collect:"XPlat Code Coverage"
- reportgenerator -reports:"Unit.Tests/TestResults/*/coverage.cobertura.xml" -targetdir:"Unit.Tests/coveragereport" -reporttypes:Html
- npx http-server Unit.Tests/coveragereport
- Check http://localhost:8080 to see generated test coverage UI