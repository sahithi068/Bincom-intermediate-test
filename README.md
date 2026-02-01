# Library Management System (LMS) – C# Intermediate Test

## Overview
This project is a **Library Management System (LMS)** developed as a **single-project ASP.NET Core Web API** for the **BINCOM Academy C# Intermediate Test**.

The application demonstrates the use of:
- SOLID principles
- Design patterns
- Entity Framework Core
- LINQ
- Async programming
- JWT authentication with role-based authorization

---

## Features

### Authentication & Authorization
- JWT-based authentication
- Two roles: **Admin** and **User**
- Admins can perform full CRUD operations on books
- Users can only view book details

---

### Entity Framework Core
- Books table with fields:
  - Id
  - Title
  - Author
  - ISBN
  - CopiesAvailable
- Database seeded with at least 5 sample books
- EF Core migrations included

---

### LINQ Queries
- Endpoint to retrieve books **grouped by Author**
- Endpoint to retrieve **top 3 most borrowed books** (mock borrowing data)

---

### Async Programming
- Async endpoint simulating fetching book details from an external API using `async/await`

---

### API Security & Documentation
- All endpoints secured using role-based authorization
- Swagger documentation available at `/swagger`
- Swagger includes request and response examples

---

## Technologies Used
- C#
- ASP.NET Core Web API
- Entity Framework Core
- LINQ
- JWT Authentication
- Swagger (OpenAPI)
- .NET 7

---

## Setup Instructions

### Prerequisites
- .NET 7 SDK
- Visual Studio or VS Code
- SQL Server / LocalDB (if applicable)

---

### Steps to Run the Application

1. Clone the repository

2. Open the solution in **Visual Studio**

3. Restore dependencies

4. Apply database migrations

5. Build the project

6. Run the application

7. Open Swagger in your browser

---

## Notes
- The database is seeded automatically on startup
- JWT tokens are required to access secured endpoints
- This project focuses on backend API functionality and best practices


