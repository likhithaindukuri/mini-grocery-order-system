# Mini Grocery Order System

This project is a demo assignment to demonstrate backend architecture, API discipline, and transactional order handling.

---

## Tech Stack
- Backend: ASP.NET Core Web API (.NET)
- Database: SQLite (Entity Framework Core)
- Frontend: Ionic + Angular

---

## Project Structure

backend/
└── MiniGroceryApi/
    ├── Controllers/ → API endpoints (request/response only)
    ├── Services/ → Business logic
    ├── Repositories/ → Database access
    ├── Models/ → Database models & DTOs
    └── Program.cs

frontend/
└── groceryApp/ → Ionic Angular frontend


---

## APIs

### GET /products
- Fetches list of available products
- No business logic
- Directly uses repository

### POST /orders
- Places an order
- Handles:
  - Product existence check
  - Stock validation
  - Stock deduction
  - Order creation
- All operations executed inside **a single database transaction**

❗ Only these two APIs are implemented as per assignment rules.

---

## Business Logic Handling
- All order-related logic is implemented in the **Service layer**
- Controllers contain no business logic
- Repositories are responsible only for database operations

---

## Transaction Handling
- Order placement is executed inside a single database transaction
- Ensures:
  - Atomicity
  - Stock consistency
  - No partial updates

---

## Frontend
- Minimal UI
- Lists products
- Places order
- Displays success or failure message
- No business logic handled in frontend