## To-do List (Full Stack)

A full-stack **To-do List** application built to learn by shipping: **Angular** frontend, **ASP.NET Core Web API** backend, and **SQL Server** database.

## What this project does

- Users can **register** and **log in**
- Each user can **create, view, update, complete, and delete** their own to-do items
- Data is **persisted** in a SQL Server database

## Why this project exists

This repository is a learning-focused, end-to-end project to practice:

- **Frontend**: Angular components, routing, services, guards, HTTP interceptors
- **Backend**: REST APIs, authentication (JWT), validation, error handling
- **Database**: relational modeling, migrations, querying, and performance basics

## Tech stack

- **Frontend**: Angular
- **Backend**: ASP.NET Core Web API (.NET)
- **Database**: Microsoft SQL Server (MSSQL)
- **Data access**: Entity Framework Core (planned)
- **Auth**: JWT (planned)

## Repository layout

This repo is intended to store **frontend + backend + database artifacts together**:

```text
./
  frontend/     # Angular app (planned)
  backend/      # .NET Web API (planned)
  database/     # SQL scripts, notes, and/or local dev setup (planned)
  README.md
```

## Getting started (development)

This section will be updated as the `frontend/` and `backend/` projects are added.

### Prerequisites

- Node.js (for Angular)
- .NET SDK (for ASP.NET Core Web API)
- SQL Server (LocalDB / SQL Server Express / Developer Edition)
- Git

### Run the backend (planned)

- The API will live under `backend/`
- It will expose endpoints for authentication and to-do CRUD
- Scalar/OpenAPI will be enabled for easy testing

### Run the frontend (planned)

- The Angular app will live under `frontend/`
- It will call the backend API and use JWT for authenticated requests

### Database (planned)

- SQL Server schema will be managed via migrations and/or scripts in `database/`
- A development connection string will be documented once the backend is scaffolded

## API (planned)

Expected REST endpoints (subject to change during implementation):

- `POST /api/auth/register`
- `POST /api/auth/login`
- `GET /api/todos`
- `POST /api/todos`
- `PUT /api/todos/{id}`
- `DELETE /api/todos/{id}`

## Contributing

Since this is a learning project, contributions are welcome in the form of:

- Bug reports and suggestions (open an issue)
- Small PRs that improve clarity, structure, or developer experience

## Help / Support

- If something doesn’t work, please open an issue with:
  - What you expected to happen
  - What actually happened (error text / screenshots)
  - Steps to reproduce
  - Your environment (OS, Node, .NET SDK, SQL Server version)

## Reference

- GitHub guide on writing READMEs: `https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-readmes`
