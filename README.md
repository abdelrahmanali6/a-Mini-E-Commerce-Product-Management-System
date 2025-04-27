# a-Mini-E-Commerce-Product-Management-System

## Description

a Mini E-Commerce Product Management System.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Project Architecture](#project-architecture)
- [Backend (ASP.NET Web API)](#backend-aspnet-web-api)
- [Authentication](#authentication)
- [Database](#database)
- [Usage](#usage)
- [Acknowledgments](#acknowledgments)
- [Contact](#contact)

## Getting Started

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **Visual Studio:** Install Visual Studio from [visualstudio.com](https://visualstudio.microsoft.com/). The project was developed with Visual Studio any version.
- **.NET SDK:** Install the .NET SDK from [dotnet.microsoft.com](https://dotnet.microsoft.com/download). The project was developed with .NET SDK version .NET 6.
- **Database:** Set up a compatible relational database (SQL Server) and configure the connection string in the `appsettings.json` file.
  
## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/abdelrahmanali6/a-Mini-E-Commerce-Product-Management-System.git

## Project Architecture

### Backend (ASP.NET Web API)

## Authentication

User authentication is implemented using JWT (JSON Web Tokens).

## Database

Using SQL Server, Create database code first using Entity Framework.

## Usage

### Backend (ASP.NET Web API)

1. **Run the API Server:**
   - Ensure the ASP.NET Web API server is running. You can typically access it at `http://localhost:5171` (or another specified port).

2. **API Endpoints:**
   - Explore the available API endpoints for managing Accounts/Users.
     - `POST http://localhost:5171/register/` Create a new account.
     - `POST http://localhost:5171/login/` Log in to the account.
       
   - Explore the available API endpoints for managing categories.
     - `GET http://localhost:5171/api/categories` retrieves a list of all categories.
     - `GET http://localhost:5171/api/categories/{id}` retrieves a specific category.
     - `PUT http://localhost:5171/api/categories/{id}` Edit a specific category.
     - `DELETE http://localhost:5171/api/categories/{id}` Delete a specific category by id.
     - `POST http://localhost:5171/api/categories/` Create a new category.
       
   - Explore the available API endpoints for managing products.
     - `GET http://localhost:5171/api/shop` retrieves a list of all products.
     - `GET http://localhost:5171/api/shop/{id}` retrieves a specific product.
     - `PUT http://localhost:5171/api/shop/{id}` Edit a specific product.
     - `DELETE http://localhost:5171/api/shop/{id}` Delete a specific product.
     - `POST http://localhost:5171/api/shop/{categoryId}` Create a product with a specific category.
    
  - Explore the available API endpoints for managing cartItems.
     - `GET http://localhost:5171/api/cart/{id}` retrieves a specific cart.
     - `PUT http://localhost:5171/api/cart/{id}` Edit a specific cart.
     - `DELETE http://localhost:5171/api/cart/{id}` Delete a specific cart by id.

4. **Authentication:**
   - To access protected endpoints, include the JWT token in the Authorization header of your requests.
     - Example: `Authorization: Bearer YOUR_JWT_TOKEN`
