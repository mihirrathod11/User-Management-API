# User Management API

A simple ASP.NET Core Web API for managing users — built for the Back-End Development with .NET course on Coursera.

## What this project does

This API lets you create, read, update, and delete users using standard HTTP methods.

## Project Structure

```
UserManagementAPI/
├── Controllers/
│   └── UsersController.cs     ← all CRUD endpoints
├── Middleware/
│   └── LoggingMiddleware.cs   ← logs every request
├── Models/
│   └── User.cs                ← user data + validation rules
├── Program.cs                 ← app setup and middleware
└── UserManagementAPI.csproj
```

## How to run

```bash
dotnet run
```

Then open: `https://localhost:5001/swagger`

## API Endpoints

| Method | URL | What it does |
|--------|-----|--------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get one user |
| POST | `/api/users` | Create a user |
| PUT | `/api/users/{id}` | Update a user |
| DELETE | `/api/users/{id}` | Delete a user |

## Example — Create a user

```json
POST /api/users
{
  "name": "Jane Doe",
  "email": "jane@example.com",
  "age": 28
}
```

## Validation

- Name is required
- Email must be a valid email address
- Age must be between 1 and 120

## Middleware

`LoggingMiddleware` logs every incoming request and response status code to the console.