# Invoice API

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![EF Core](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)


This project is an API built using **.NET, EF Core, Migrations and PostgresSQL as the database.**



## Table of Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Database](#database)

## Installation

1. Clone the repository:

```bash
git clone https://github.com/Lucas-barreto1/Invoice
```

2. Install dependencies

3. Install [PostgresSQL](https://www.postgresql.org/)

## Usage

1. Start the application 
2. The API will be accessible at [(http://localhost:5258/swagger/index.html)](http://localhost:5258/swagger/index.html)


## API Endpoints
The API provides the following endpoints:

```markdown
GET /customer - Retrieve a list of all customers.

POST /customer - Register a new customer.

GET /customer/{id}/products - Find all products by customer 

GET /customer/{id} - Find customer by id

PUT /customer/{id} - Update customer

DELETE /customer/{id} - Delete customer by id



GET /invoice - Retrieve a list of all invoices.

POST /invoice - Register a new invoice.

GET /invoice/{id} - Find invoice by id

PUT /invoice/{id} - Update invoice

DELETE /invoice/{id} - Delete invoice by id




GET /product - Retrieve a list of all products.

POST /product - Register a new product.

GET /product/{id} - Find product by id

PUT /product/{id} - Update product

DELETE /product/{id} - Delete product by id
```

## Database
The project utilizes [PostgresSQL](https://www.postgresql.org/) as the database.
