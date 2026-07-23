# StudentManagementSystem.API
1. Project Description

Student Management System is a RESTful Web API developed using ASP.NET Core Web API and SQL Server. The application provides secure APIs to manage student records and user authentication.

The system supports CRUD operations for students, JWT-based authentication, global exception handling, logging, and Swagger API documentation.

This project follows a layered architecture to maintain clean, scalable, and maintainable code.

2. Technologies Used
C#
ASP.NET Core Web API
.NET 8
Entity Framework Core
SQL Server
SQL Server Management Studio (SSMS)
JWT (JSON Web Token) Authentication
Swagger / OpenAPI
Serilog Logging
RESTful API
Git
GitHub
Visual Studio
3. Features
Authentication
User Registration
User Login
JWT Token Generation
JWT Token-based Authentication
Secure Password Hashing
Student Management
Get all students
Get student by ID
Add a new student
Update student details
Delete student
Additional Features
Layered Architecture
Repository Pattern
Service Layer
DTOs (Data Transfer Objects)
Global Exception Handling Middleware
Logging using Serilog
Swagger API Documentation
SQL Server Database Integration
RESTful API Design
4. Project Architecture

The project follows a layered architecture.

StudentManagementSystem
│
├── StudentManagementSystem.API
│   │
│   ├── Controllers
│   │   ├── AuthController.cs
│   │   └── StudentController.cs
│   │
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   │
│   ├── DTOs
│   │   ├── LoginDto.cs
│   │   ├── RegisterDto.cs
│   │   └── StudentDto.cs
│   │
│   ├── Models
│   │   ├── User.cs
│   │   └── Student.cs
│   │
│   ├── Repositories
│   │   ├── IStudentRepository.cs
│   │   └── StudentRepository.cs
│   │
│   ├── Services
│   │   ├── IStudentService.cs
│   │   └── StudentService.cs
│   │
│   ├── Middleware
│   │   └── ExceptionMiddleware.cs
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── StudentManagementSystem.API.csproj
│
├── README.md
├── .gitignore
└── StudentManagementSystem.sln



Architecture Flow
Client
   │
   ▼
Controller
   │
   ▼
Service Layer
   │
   ▼
Repository Layer
   │
   ▼
Entity Framework Core
   │
   ▼
SQL Server Database
Layer Responsibilities

Controllers

Handle HTTP requests and responses.

Services

Contain business logic and application rules.

Repositories

Handle database operations.

Models

Represent database entities.

DTOs

Transfer data between the client and API.

Middleware

Handles exceptions globally and returns consistent error responses.

Data

Contains Entity Framework Core DbContext and database configuration.

5. Database Setup Using SQL Server
Step 1: Install SQL Server

Install SQL Server on your computer.

You can use:

SQL Server Express
SQL Server Developer Edition

Make sure the SQL Server service is running.

Step 2: Install SQL Server Management Studio

Install SQL Server Management Studio (SSMS) to manage the SQL Server database.

Open SSMS and connect to your SQL Server instance.

Example:

Server Type: Database Engine
Server Name: localhost
Authentication: Windows Authentication

The server name may be different depending on your SQL Server installation.

For SQL Server Express, the server name may be:

localhost\SQLEXPRESS

or:

.\SQLEXPRESS
Step 3: Create the Database

Open a New Query window in SSMS and execute:

CREATE DATABASE StudentManagementDB;

To check the database:

SELECT name
FROM sys.databases;

You should see:

StudentManagementDB
6. Connection String Configuration

Open:

appsettings.json

Configure the SQL Server connection string.

For SQL Server Express
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
For LocalDB

If you are using LocalDB:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
For SQL Server with SQL Authentication

If you use SQL Server Authentication:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StudentManagementDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  }
}

Replace the server name, username, and password according to your SQL Server configuration.

Security Note

Do not commit real database passwords, JWT secrets, or other sensitive information to GitHub.

Use:

User Secrets
Environment Variables
Azure Key Vault
Other secure secret management systems
7. Entity Framework Core Configuration

Make sure the required Entity Framework Core packages are installed.

For SQL Server:

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

For migrations:

dotnet add package Microsoft.EntityFrameworkCore.Tools

For design-time support:

dotnet add package Microsoft.EntityFrameworkCore.Design
8. How to Run the Project
Step 1: Clone the Repository
git clone YOUR_GITHUB_REPOSITORY_URL

Navigate to the project:

cd StudentManagementSystem
Step 2: Configure SQL Server

Make sure:

SQL Server is installed
SQL Server service is running
SQL Server Management Studio is installed
StudentManagementDB database is created
The connection string is correctly configured
Step 3: Restore NuGet Packages

Run:

dotnet restore
Step 4: Apply Entity Framework Migration

If migrations already exist:

dotnet ef database update

If migrations do not exist, create a migration:

dotnet ef migrations add InitialCreate

Then update the database:

dotnet ef database update
Step 5: Run the Application

Run:

dotnet run

Or run the project using Visual Studio.

The API will start at a URL similar to:

https://localhost:7027

The exact port may be different depending on your project configuration.

9. API Endpoints
Authentication APIs
Register User
POST /api/Auth/register

Request Body:

{
  "username": "admin",
  "email": "admin@gmail.com",
  "password": "Admin@123"
}
Login User
POST /api/Auth/login

Request Body:

{
  "email": "admin@gmail.com",
  "password": "Admin@123"
}

Successful Response:

{
  "token": "YOUR_JWT_TOKEN"
}

Copy the JWT token from the response.

Student APIs
Get All Students
GET /api/Student
Get Student By ID
GET /api/Student/{id}

Example:

GET /api/Student/1
Add New Student
POST /api/Student

Request Body:

{
  "name": "Rahul Patil",
  "email": "rahul@gmail.com",
  "age": 21,
  "course": "Computer Science"
}
Update Student
PUT /api/Student/{id}

Example:

PUT /api/Student/1

Request Body:

{
  "name": "Rahul Patil",
  "email": "rahulpatil@gmail.com",
  "age": 22,
  "course": "Information Technology"
}
Delete Student
DELETE /api/Student/{id}

Example:

DELETE /api/Student/1
10. JWT Authentication Instructions

The Student APIs are protected using JWT Authentication.

Step 1: Register

Send a request to:

POST /api/Auth/register

Example:

{
  "username": "admin",
  "email": "admin@gmail.com",
  "password": "Admin@123"
}
Step 2: Login

Send a request to:

POST /api/Auth/login

Example:

{
  "email": "admin@gmail.com",
  "password": "Admin@123"
}

The API will return a JWT token.

Example:

{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
Step 3: Authorize the API

Copy the JWT token returned from the login API.

In Swagger, click the Authorize button.

Enter:

Bearer YOUR_JWT_TOKEN

Example:

Bearer eyJhbGciOiJIUzI1NiIs...

Click Authorize.

You can now access the protected Student APIs.

11. Swagger Instructions

Swagger provides an interactive interface for testing the API.

After running the application, open:

https://localhost:7027/swagger

The exact port may be different depending on your project configuration.

Using Swagger
Step 1: Register

Find:

POST /api/Auth/register

Click:

Try it out

Enter:

{
  "username": "admin",
  "email": "admin@gmail.com",
  "password": "Admin@123"
}

Click:

Execute
Step 2: Login

Find:

POST /api/Auth/login

Click:

Try it out

Enter:

{
  "email": "admin@gmail.com",
  "password": "Admin@123"
}

Click:

Execute

Copy the JWT token from the response.

Step 3: Authorize

Click the Authorize button in Swagger.

Enter:

Bearer YOUR_JWT_TOKEN

Click:

Authorize

Then click:

Close

You can now call the protected Student APIs.

12. Example API Request Flow
1. Register User
       │
       ▼
2. Login User
       │
       ▼
3. Receive JWT Token
       │
       ▼
4. Click Authorize in Swagger
       │
       ▼
5. Enter Bearer JWT Token
       │
       ▼
6. Access Student APIs
       │
       ├── Get All Students
       │
       ├── Get Student By ID
       │
       ├── Add Student
       │
       ├── Update Student
       │
       └── Delete Student
13. Example Student API Requests
Create Student
POST /api/Student
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json

Request Body:

{
  "name": "Tejashree Mudhale",
  "email": "tejashree@gmail.com",
  "age": 22,
  "course": "Computer Science and Engineering"
}
Get All Students
GET /api/Student
Authorization: Bearer YOUR_JWT_TOKEN
Update Student
PUT /api/Student/1
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json

Request Body:

{
  "name": "Tejashree Mudhale",
  "email": "tejashree.updated@gmail.com",
  "age": 23,
  "course": "Computer Science"
}
Delete Student
DELETE /api/Student/1
Authorization: Bearer YOUR_JWT_TOKEN
14. Error Handling

The application uses Global Exception Handling Middleware to handle unexpected errors.

Example error response:

{
  "statusCode": 500,
  "message": "An unexpected error occurred."
}

The API uses appropriate HTTP status codes:

200 OK
201 Created
204 No Content
400 Bad Request
401 Unauthorized
403 Forbidden
404 Not Found
500 Internal Server Error
15. Logging

The application uses Serilog for application logging.

Logs can be used to track:

Application startup
API requests
Errors
Exceptions
Important application events
16. Testing

The APIs can be tested using:

Swagger UI
Postman
cURL

Swagger is recommended for quick API testing and demonstration.

17. GitHub Repository

GitHub Repository:

YOUR_GITHUB_REPOSITORY_URL
18. Author

Developed as a technical assignment for a Student Management System using ASP.NET Core Web API and SQL Server.
