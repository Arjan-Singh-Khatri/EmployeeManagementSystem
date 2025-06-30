# Employee Management System - ASP.NET Core MVC

This is a simple employee management system built using **ASP.NET Core MVC**, **SQL Server**, and **Entity Framework Core**. 

---

## 🧱 Project Architecture

- **ASP.NET Core MVC**: For web UI, routing, and backend logic
- **Entity Framework Core (with raw SQL)**: For calling stored procedures
- **SQL Server (SSMS)**: Database with manually created tables and stored procedures

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
├── appsettings.json <br/>
└── Program.cs (main app setup)<br/>


## Setup Instructions

1. **Create Database**:
   - Open SQL Server Management Studio (SSMS)
   - Run provided SQL scripts to create:
     - `Users` and `Employees` tables
     - Stored procedures for Login, Register, Add/Edit/Delete Employee

2. **Configure Connection String**:
   - Open `appsettings.json`
   - Update the `DefaultConnection` with your local SQL Server connection string

3. **Run the App**:
   - Open the solution in Visual Studio
   - Build and Run the project
   - Default route goes to `Home/Index`, where you can go to Login or Register

4. **Login/Register Flow**:
   - Register a new user
   - After logging in, the user can view, add, edit, or delete employees

---

## Features Implemented

- User Registration and Login
- Secure password storage using hashes
- CRUD operations on Employee data via stored procedures
- Clean, maintainable codebase following MVC structure
