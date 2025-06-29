# Employee Management System - ASP.NET Core MVC

This is a simple employee management system built using **ASP.NET Core MVC**, **SQL Server**, and **Entity Framework Core**. It supports **user registration/login**, and allows **admin users** to manage employee records (create, view, update, delete).

---

## 🧱 Project Architecture

- **ASP.NET Core MVC**: For web UI, routing, and backend logic
- **Entity Framework Core (with raw SQL)**: For calling stored procedures
- **SQL Server (SSMS)**: Database with manually created tables and stored procedures
- **Session Management**: For login and role-based access
- **Bootstrap**: For styling views with responsive UI

---

## 📁 Folder Structure Overview

EmployeeManagementSystem/<br/>
├── Controllers/<br/>
│ ├── AccountController.cs<br/>
│ ├── EmployeeController.cs<br/>
│ └── AdminController.cs<br/>
├── Models/<br/>
│ ├── User.cs<br/>
│ └── Employee.cs<br/>
├── Views/<br/>
│ ├── Account/ (Login/Register)<br/>
│ ├── Employee/ (CRUD for employees)<br/>
│ └── Admin/ (Admin Dashboard)<br/>
├── appsettings.json (connection string)<br/>
└── Program.cs (main app setup)<br/>
