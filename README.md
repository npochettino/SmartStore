# Project Overview: SmartStore – A Modular E-commerce API
🔹 Tech Stack:
- .NET 8 Web API

- Entity Framework Core (In-Memory or SQL Server)

- MediatR for CQRS and Mediator Pattern

- Serilog for logging

- xUnit + Moq for unit tests

- Swagger for API documentation

- Docker (optional) for containerization

🔹 Architecture Layers

SmartStore.sln
│
├── SmartStore.API                → Presentation Layer
├── SmartStore.Application       → CQRS Handlers, DTOs, Interfaces
├── SmartStore.Domain            → Entities, Enums, Aggregates
├── SmartStore.Infrastructure    → EF Core, Repositories, UoW
├── SmartStore.Tests             → Unit & Integration Tests
