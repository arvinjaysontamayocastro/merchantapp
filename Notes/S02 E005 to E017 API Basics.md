## S02 API Basics
Introduction
### S02 E005: Introduction
API Basics
Creating the projects, 3 projects
Clean architecture concepts
Entity framework, session with database server
Docker / SQL Server
Postman
using git for source control

Goal
To have a working API that contains endpoints for the Create, Read, Update and Delete (CRUD) operations.

To understand the basics of an API in .Net

Projects
API I receive HTTP Requests and respond to them
Infrastructure I'll communicate with the DB and send queries and get data
Core I contain the business entities. I do not depend on anything else.

Advantages
Separation of concerns
	each layer have direct or distinct responsibility
Testability
	isolated from any external dependencies
Scalability and maintainability scalable
	understandable, maintanable code
Flexability
	Easier to update layer without impacting other layers, update layeres independently, switch database provider in the infrastructure
Reusability
	Common functionalities can be used on other layers, utilized in other projects

### S02 E006: Creating the .Net Projects
mkdir MerchantApp
dotnet --info
dotnet new list
dotnet new sln
dotnet new webapi -o API -controllers
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
dotnet sln add API
dotnet sln add Core
dotnet sln add Infrastructure
dotnet sln list

API has dependency on Infrastructure
and transitive dependency on Core

Infrastructure has dependency on Core

Core has no dependencies

cd API
dotnet add reference ../Infrastructure

cd ..
cd Infrastructure
dotnet add reference ../Core

dotnet restore
dotnet build

### S02 E007: Reviewing the projects in VS Code
API Startup project
	Run project: Terminal: cd API
		dotnet run

### S02 E008 Creating the Product Entity

### S02 E09 Setting up entity framework
	NUGET
	Search Microsoft.EntityFrameworkCore.SqlServer
		Add to Infrastructure.csproj
	Search Microsoft.EntityFrameworkCore.Design
		Add to API.csproj