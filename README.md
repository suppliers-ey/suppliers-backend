# Suppliers Backend

**Suppliers** is a web application designed to streamline the supplier due diligence process. As developers, we have created this platform with the aim of allowing users to input crucial information about suppliers and carry out an automated data screening process against high-risk lists to identify potential risky associations.

## Prerequisites

List any prerequisites that users need to have installed or configured before running the project. For example:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (SQL Server 2022 or higher)
- [Visual Studio](https://visualstudio.microsoft.com/)

## Getting Started

Provide step-by-step instructions on how to run the project locally.

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/your-repository.git
```

### 2. Set up the Database
Create a new database in your SQL Server instance. You can use SQL Server Management Studio or any other tool you prefer. The approach in this project is code-first, so the database schema will be generated based on the entities defined in the code.

### 3. Configuring Connection String 
Update the connection string in the `appsettings.json` in the `suppliers.API` directory to point to your newly created database.
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:localhost;Database=<YOUR-DATABASE>;User=<YOUR-USERNAME>;Password=<YOUR-PASSWORD>;Encrypt=True;TrustServerCertificate=True;"
  }
}
```

Also, update the connectin string in the database context `Suppliers.Infrastructure/Context/SuppliersContext.cs`
```c#
if (!optionsBuilder.IsConfigured)
{
    var connectionString = "Server=SPIGISAURIO\\MSSQLSERVER01;Database=suppliers;Encrypt=false;Integrated Security=SSPI;persist security info=True;";
    optionsBuilder.UseSqlServer(connectionString);
}
```


### 4. Build and Run the Project

```bash
dotnet restore
dotnet build
cd suppliers.API
dotnet run
```
> If you're using Visual Studio or Visual Studio Code, you can also run the project from the IDE.

## Usage

Once the project is running, you can interact with it via the Swagger UI. Swagger provides a user-friendly interface to explore and test the available API endpoints.

1. Open your web browser and navigate to the Swagger URL generated when running the .NET project. The URL is: <a href="http://localhost:port/swagger" target="_blank" >http://localhost:port/swagger</a>

2. Explore the available endpoints listed in the Swagger UI. You can view details about each endpoint, including the HTTP method, route, request/response parameters, and example requests/responses.

3. Use the Swagger UI to test the endpoints. You can send requests directly from the UI and view the responses. This allows you to verify that the API is functioning as expected.

4. Optionally, you can integrate the API endpoints into your application by sending requests programmatically using libraries like Axios (for JavaScript), HttpClient (for .NET), or any other HTTP client library.



