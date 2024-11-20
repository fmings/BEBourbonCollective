# BEBourbonCollective 🥃

[Technologies](#technologies) | [Getting Started](#getting-started) | [API Endpoints](#api-endpoints) | [Postman Documentation](#postman-documentation) | [Project Owner](#collaborators)

This is the server-side repository for the full-stack app, **Bourbon Collective** — a user-friendly platform where collectors can catalog their bourbons, view other users’ collections, and propose trades. By providing a space to manage collections and connect with fellow enthusiasts for trading, Bourbon Collective enables users to build their ideal collections while fostering community and discovery.

### 👤 Ideal User
The ideal user for Bourbon Collective is a bourbon enthusiast, ranging from curious newcomers to seasoned connoisseurs. 
They are individuals who enjoy discovering new bourbons and tracking their building collection of the spirit. 
These users value a sense of community, appreciate curated recommendations, and are eager to connect with others who share their passion for bourbon. 

---

## 💻 Technologies

- C#
- .NET
- Entity Framework Core
- Moq
- xUnit
- PostgreSQL
- pgAdmin
- Swagger
- Postman

---

## 🚀 Getting Started

### Prerequisites

For this project to run successfully, you'll need the following:

- [.NET](https://dotnet.microsoft.com/en-us)
- [PostgreSQL](https://www.postgresql.org/download)
- [pgAdmin](https://www.pgadmin.org)

### 1. Clone the Repo

Clone this repo using the following command in your terminal:

```bash
git clone https://github.com/fmings/BEBourbonCollective.git
```

### 2. Install Required Packages

Once the repository is cloned, navigate to the project directory in your terminal and run the following commands to install necessary packages:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0
```

### 3. Set Up Secrets for PostgreSQL Connection

To store sensitive connection details, initialize the secret storage with:

```bash
dotnet user-secrets init
```

Then, set the connection string for your PostgreSQL database (replace with your actual PostgreSQL password):

```bash
dotnet user-secrets set "BourbonCollectiveDbConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=BourbonCollective"
```

### 4. Apply Migrations to the Database

Run the following command to apply the database migrations:

```bash
dotnet ef database update
```

This will create the necessary tables and schema in your PostgreSQL database.

### 5. Run the Solution

Launch the solution. Swagger should automatically launch and provide you with the API documentation.

## 📍 Features/API Endpoints

| Route											| Description														|
|-----------------------------------------------|-------------------------------------------------------------------|
| **GET /bourbons**                             | Retrieve a list of all bourbons									|
| **POST /bourbons**                            | Add a bourbon														|
| **PUT /bourbons/{id}**						| Update a bourbon													|
| **DELETE /bourbons/{id}**                     | Delete a bourbon													|
| **GET /distilleries**							| Retrieve a list of all distilleries								|
| **POST /distilleries**						| Add a distillery													|
| **PUT /distilleries/{distilleryId}**          | Update a distillery												|
| **DELETE /distilleries/{distilleryId}**       | Delete a distillery												|
| **GET /tradeRequests/use/{userId}**           | Retrieve a list of pending trade requests for the signed in user  |
| **POST /tradeRequests**						| Add a new trade request											|
| **PUT /tradeRequests/{tradeRequestId}**       | Update a trade request											|
| **DELETE /tradeRequests/{tradeRequestId}**    | Delete a trade request											|
| **GET /userBourbons**							| Retrieve a list of all userBourbons                               |
| **POST /userBourbons**						| Add a userBourbon													|
| **PATCH /userBourbons/{userBourbonId}**       | Update a userBourbon												|
| **DELETE /userBourbons/{userBourbonId}**		| Delete a userBourbon												|
| **GET /users/checkUser/{uid}**                | Check to see if user is existing									|
| **POST /users/register**						| Register/add user													|
| **GET /users/{id}**							| Get a single user													|
| **GET /users**								| Get all users														|
| **USER /users{id}**							| Update a user														|

## 📄 Postman Documentation

Check out the [Bourbon Collective Postman Documentation](https://documenter.getpostman.com/view/31976414/2sAYBRFDUy) to learn more about the API routes and see examples of how each request and response should look.

## 📋 Project Board

View the [Bourbon Collective Project Board](https://github.com/users/fmings/projects/13/views/1) to see open and completed project tickets.

## Project Owner

<table>
<tr>
<td align="center">
<a href="https://github.com/fmings">
<img src="https://avatars.githubusercontent.com/u/150978100?v=4" width="100px;" alt="Felicia Mings Profile Picture"/><br>
<sub><b>Felicia Mings</b></sub>
</a>
</td>
</tr>
</table>
