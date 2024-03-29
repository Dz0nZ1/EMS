# Event Management System (Backend)

Event Management System (Backend) is the server-side component of a comprehensive platform designed to streamline event organization and attendance. It provides a robust backend infrastructure for handling event creation, reservation management, and business logic.

## Technology Stack

- **.NET Core Framework**: Leveraging .NET Core ensures high performance, scalability, and cross-platform compatibility.

- **ASP .NET**: Utilize ASP .NET for building robust web APIs, providing a solid foundation for hosting and exposing backend functionalities.

- **Application Layer**: Implement business logic within the application layer to ensure separation of concerns and maintainability.

- **Infrastructure Layer**: Integrate with third-party services and components through the infrastructure layer, promoting modularity and extensibility.

- **Domain Layer**: Define entities and domain logic within this layer, adhering to domain-driven design principles.

- **PostgreSQL Database**: Utilize PostgreSQL for storing event data, ensuring reliability, scalability, and support for complex data structures.

- **Swagger**: Integrate Swagger for API documentation, facilitating clear communication and interaction with the backend endpoints.

## Installation

 1. Clone the repository:
   ```sh
   git clone https://github.com/Dz0nZ1/EMS.git
   ```
2. Enter the project with cd command:
 ```bash
cd EMS
```
3. Install dependencies:
 ```bash
dotnet restore
```
4. Set up the database:

   Create a PostgreSQL database and update the connection string in the appsettings.json file.<br/> 
   Apply migrations:
 ```bash
dotnet ef database update
```
5. Run the application:
 ```bash
dotnet run
```






