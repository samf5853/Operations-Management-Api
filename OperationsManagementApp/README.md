# 🏭 Operations Management API

A backend REST API built with **C# and ASP.NET Core** that simulates a real-world operations management system — handling inventory tracking, order processing, and cross-entity business logic with enterprise-grade architecture patterns.

> Built as a portfolio project to demonstrate production-minded backend engineering in a second tech stack beyond Java/Spring Boot.

---

## 🔗 Repository

**Backend:** https://github.com/samf5853/Operations-Management-Api

**Author:** Samuel Foster — [LinkedIn](https://linkedin.com/in/samuel-foster-jr/) · [GitHub](https://github.com/samf5853)

---

## 📌 Project Overview

This API models the backend of a small-to-medium operations system where inventory and orders are tightly coupled through business logic. The system enforces real constraints — orders are rejected if inventory is insufficient, quantities can't go negative, and state changes flow through a controlled service layer rather than directly through the database.

Key engineering goals:
- Apply layered architecture in a statically-typed, enterprise-oriented language (C#)
- Enforce business rules at the service layer, not the controller or database
- Demonstrate cross-entity validation and relational data modeling
- Practice async/await patterns and Code First database management with EF Core

---

## 🚀 Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET) |
| Framework | ASP.NET Core |
| ORM | Entity Framework Core (Code First) |
| Database | SQL Server |
| API Docs | Swagger / OpenAPI |

---

## 🧱 Architecture

This project follows a strict layered architecture mirroring real-world enterprise backend systems:
```
HTTP Request
     ↓
Controller Layer      → Handles routing, request/response mapping
     ↓
Service Layer         → Business logic, validation, state management
     ↓
Repository Layer      → Data access via Entity Framework Core
     ↓
Database (SQL Server) → Persisted state
```

### Design Patterns Applied
- **Repository Pattern** — abstracts data access from business logic
- **Service Layer** — all business rules live here, controllers stay thin
- **DTO (Data Transfer Objects)** — clean contracts between API and client
- **Dependency Injection** — loosely coupled components throughout
- **Separation of Concerns** — each layer has one responsibility

---

## 📦 Features

### 🗃️ Inventory Management
- Create, update, and delete inventory items
- Enforce validation rules (quantities cannot go negative)
- Database-backed persistence with full CRUD support

### 📋 Order Management
- Create orders containing multiple line items
- Validate inventory availability before fulfillment
- Automatically reject orders that exceed available stock
- Deduct inventory atomically on successful order placement

### ⚙️ Business Logic Engine
- Cross-entity validation between Orders and Inventory
- Controlled state transitions through the service layer
- Clean boundary between API surface and domain logic

---

## 🧠 Key Concepts Demonstrated

- RESTful API design and HTTP semantics
- One-to-Many entity relationships
- Data annotation validation attributes
- Async/await programming patterns
- Code First migrations with EF Core
- Service layer business rule enforcement
- Repository pattern for testable data access

---

## 🧪 API Endpoints

### Inventory
```http
GET    /api/inventory          # List all inventory items
POST   /api/inventory          # Create a new inventory item
PUT    /api/inventory/{id}     # Update an existing item
DELETE /api/inventory/{id}     # Remove an item
```

### Orders
```http
POST   /api/orders             # Place a new order
```

**Example order request:**
```json
{
  "customerName": "John Doe",
  "items": [
    {
      "inventoryItemId": 1,
      "quantity": 2
    }
  ]
}
```

**What happens under the hood:**
1. Service layer fetches current inventory levels
2. Validates each line item against available stock
3. Rejects the entire order if any item is unavailable
4. Deducts inventory and persists the order if all items are valid

---

## ⚙️ Local Setup

### Prerequisites
- .NET SDK (8.0+)
- SQL Server (local or Docker)

### Steps

1. **Clone the repository**
```bash
git clone https://github.com/samf5853/Operations-Management-Api.git
cd Operations-Management-Api
```

2. **Configure your database connection** in `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OperationsDb;Trusted_Connection=True;"
  }
}
```

3. **Apply migrations**
```bash
dotnet ef database update
```

4. **Run the application**
```bash
dotnet run
```

5. **Explore the API via Swagger**
```
https://localhost:{port}/swagger
```

---

## 📈 Roadmap

- [ ] JWT authentication and role-based access control
- [ ] Order status workflow (Pending → Processing → Fulfilled → Cancelled)
- [ ] Audit logging for inventory changes
- [ ] Supplier management module
- [ ] Pagination and filtering on list endpoints
- [ ] Reporting and analytics endpoints
- [ ] Unit and integration test coverage

---

## 💡 Why This Project Exists

Most portfolio projects demonstrate that someone can follow a tutorial. This one demonstrates something different — the ability to model real business constraints in code.

Inventory and orders aren't just CRUD. They interact. An order that exceeds stock shouldn't silently succeed. Quantities shouldn't go negative. Business rules belong in a service layer, not scattered across controllers or left to the database. This project is an exercise in building a backend that actually thinks about those things.

It also demonstrates that I build for understanding across stacks — not just comfort in one language. My primary stack is Java and Spring Boot. This project applies the same architectural principles in C# and ASP.NET Core, because good backend engineering isn't language-specific.

---

## 👨‍💻 Author

**Samuel Foster** — Backend Software Engineer

📧 samf5853@gmail.com
🔗 [linkedin.com/in/samuel-foster-jr](https://linkedin.com/in/samuel-foster-jr/)
💻 [github.com/samf5853](https://github.com/samf5853)