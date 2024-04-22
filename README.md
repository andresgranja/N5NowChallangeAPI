# N5NowChallangeAPI

This repository contains the source code for the N5NowChallangeAPI. The API is built with ASP.NET Core, adhering to the principles of Clean Architecture and SOLID principles.

## Architecture

The solution is structured into several projects:

- `N5Now.API`: The entry point for the API, hosting the controllers and the API configuration.
- `N5Now.Application`: Contains the application logic and defines interfaces that the API will use.
- `N5Now.Domain`: Includes domain entities and interfaces.
- `N5Now.Infrastructure`: Houses the implementation of data access and other infrastructure concerns.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other database with an EF Core provider)
- [Docker](https://www.docker.com/get-started) (optional)

### Setting Up Development Environment

1. Clone the repository:

    ```sh
    git clone https://github.com/andresgranja/N5NowChallangeAPI.git
    ```

2. Navigate to the API project directory and restore the .NET packages:

    ```sh
    cd YourSolution/src/N5Now.API
    dotnet restore
    ```

3. Apply the database migrations to create your database schema:

    ```sh
    dotnet ef database update
    ```

4. Start the API project:

    ```sh
    dotnet run
    ```

The API should now be running on <http://localhost:5000>.

### Running with Docker (Optional)

If you prefer to use Docker, you can use the provided `docker-compose.yml` file at the root of the solution to build and run the application:

```sh
docker-compose up --build
