# YourSolution API

This repository contains the source code for the YourSolution API and its associated front-end application. The API is built with ASP.NET Core, adhering to the principles of Clean Architecture and SOLID principles.

## Architecture

The solution is structured into several projects:

- `YourSolution.API`: The entry point for the API, hosting the controllers and the API configuration.
- `YourSolution.Application`: Contains the application logic and defines interfaces that the API will use.
- `YourSolution.Domain`: Includes domain entities and interfaces.
- `YourSolution.Infrastructure`: Houses the implementation of data access and other infrastructure concerns.
- `YourSolution.Presentation`: The front-end React application that interacts with the API.

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
    git clone https://your-repository-url.com/YourSolution.git
    ```

2. Navigate to the API project directory and restore the .NET packages:

    ```sh
    cd YourSolution/src/YourSolution.API
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

5. To start the front-end React application, navigate to the `YourSolution.Presentation` directory and install the necessary node modules:

    ```sh
    cd YourSolution/src/YourSolution.Presentation
    npm install
    ```

6. Start the React development server:

    ```sh
    npm start
    ```

The API should now be running on <http://localhost:5000> and the React app on <http://localhost:3000>.

### Running with Docker (Optional)

If you prefer to use Docker, you can use the provided `docker-compose.yml` file at the root of the solution to build and run the application:

```sh
docker-compose up --build
