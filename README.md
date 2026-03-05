<div align="center">

# 📌 Task Management API

[![.NET](https://img.shields.io/badge/.NET-8.0-blue?style=for-the-badge&logo=dotnet)]()
[![Build & Deploy](https://img.shields.io/github/actions/workflow/status/LauraBailie/TaskManagementApi/deploy.yml?style=for-the-badge)]()
[![Azure](https://img.shields.io/badge/Hosted%20on-Azure-0078D4?style=for-the-badge&logo=microsoftazure)]()
[![Status](https://img.shields.io/badge/status-Production%20Ready-green?style=for-the-badge)]()

Production-ready ASP.NET Core Web API demonstrating secure authentication, clean architecture, automated testing, CI/CD, and Azure cloud deployment.

</div>

---

# 🌍 Live Demo

### 🔎 Swagger UI
👉 https://manage-task-fdenbvbxe3hbffc2.southafricanorth-01.azurewebsites.net/swagger

### ❤️ Health Check
👉 https://manage-task-fdenbvbxe3hbffc2.southafricanorth-01.azurewebsites.net/health

---

# 🚀 Overview

Task Management API is a secure RESTful API built using **ASP.NET Core (.NET 8)**.

It demonstrates real-world backend engineering practices:

- 🔐 JWT Authentication & Authorization
- 🧱 Clean Layered Architecture
- 🗄 Entity Framework Core (SQLite)
- 🧪 Unit Testing (xUnit + Moq)
- 🔄 CI/CD with GitHub Actions
- ☁️ Azure App Service Deployment
- 📊 Production Monitoring Ready

---

# 🏗 System Architecture

## Layered Architecture


Client → Controller → Service → Repository → Database


```mermaid
flowchart LR

Client["Client (Swagger / Postman)"]

subgraph API["ASP.NET Core Web API (.NET 8)"]
Controllers["Controllers"]
Middleware["JWT Authentication"]
Swagger["Swagger / OpenAPI"]
end

subgraph Services["Business Layer"]
Service["TaskService"]
end

subgraph Data["Data Layer"]
Repository["TaskRepository"]
EFCore["EF Core"]
Database[("SQLite")]
end

CI["GitHub Actions"]
Azure["Azure App Service"]

Client --> Controllers
Controllers --> Service
Service --> Repository
Repository --> EFCore
EFCore --> Database

Controllers --> Middleware
Controllers --> Swagger

CI --> Azure
Azure --> Client
```


## 🔐 Authentication Flow

```mermaid
sequenceDiagram
    participant Client
    participant AuthController
    participant JWT
    participant API

    Client->>AuthController: POST /api/auth/login
    AuthController->>JWT: Generate Token
    JWT-->>Client: Return JWT

    Client->>API: Request with Bearer Token
    API->>JWT: Validate Token
    JWT-->>API: Valid
    API-->>Client: Protected Resource
```



## 📷 Screenshots

✅ CI/CD Pipeline Success
<p align="center"> <img src="docs/images/CI-Pipeline.png" width="800"/> </p>
🔎 Swagger UI (Live Deployment)
<p align="center"> <img src="docs/images/Swagger-UI-Running.png" width="800"/> </p>



## 🔐 Features

- JWT-secured authentication

- Protected endpoints with [Authorize]

- Full CRUD task management

- Swagger UI with Bearer token support

- Health check endpoint

- Environment-based configuration

- Automated CI pipeline

- Production-ready cloud deployment


## 🧪 Testing Strategy

Unit tests validate:

- Business logic (Service layer)

- Repository interactions (mocked)

- Validation rules and expected outputs

- Testing Tools

- xUnit

- Moq

Tests run automatically via GitHub Actions.


## 🔄 CI/CD Pipeline

On every push to main:

- Restore dependencies

- Build solution

- Run unit tests

- Publish build artifacts

- Deploy to Azure App Service

- Ensures quality, reliability, and production stability.

## ☁️ Deployment & DevOps

Hosted on Azure App Service (Linux).

Configured with:

- GitHub Actions deployment workflow

- Secure publish profile secret

- Environment variables via Azure Configuration

- HTTPS enforced at platform level

- Production monitoring ready (Application Insights)


## ⚙️ Production Environment Variables

Configured in Azure:

Jwt__Key

Jwt__Issuer

Jwt__Audience

ConnectionStrings__DefaultConnection

ASPNETCORE_ENVIRONMENT=Production


## 🧪 Run Locally

```
    git clone https://github.com/LauraBailie/task-management-api.git
    cd task-management-api
    dotnet restore
    dotnet run
```


Open:

https://localhost:5253/swagger



## 📈 Future Enhancements

- Azure SQL integration

- Docker containerization

- Role-based authorization

- Front-end client (React or Blazor)

- Integration testing

- API versioning