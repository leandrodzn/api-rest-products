# RestApiNetV1

RestApiNetV1 is a REST API built with .NET 8. This project provides an interface to manage products and greet users.

## Project Structure
RestApiNetV1
- Connected Services
- Dependencies
- Properties
- Context
  - AppDbContext.cs
- Controllers
  - GreetingController.cs
  - ProductsController.cs
- DTOs
  - ProductAmountDTO.cs
- Migrations
  - 20240720032318_Initial.cs
  - AppDbContextModelSnapshot.cs
- Models
  - Product.cs
- appsettings.json
- Program.cs
- RestApiNetV1.http

### Context
- `AppDbContext.cs`: Database context configuration.

### Controllers
- `GreetingController.cs`: Controller for greeting operations.
- `ProductsController.cs`: Controller to manage product-related operations.

### DTOs (Data Transfer Objects)
- `ProductAmountDTO.cs`: DTO for product data transfer.

### Migrations
- `20240720032318_Initial.cs`: Initial database migration.
- `AppDbContextModelSnapshot.cs`: Snapshot of the database context model.

### Models
- `Product.cs`: Data model for products.

### Configuration Files
- `appsettings.json`: Application configuration file.
- `Program.cs`: Application entry point.

### Others
- `RestApiNetV1.http`: HTTP file to test API requests.

## Endpoints

### Greeting 
- **POST /api/Greeting**: Returns a greeting message.

### Products 
- **GET /api/Products**: Retrieves a list of all products.
- **GET /api/Products/{id}**: Retrieves a product by its ID.
- **POST /api/Products**: Creates a new product.
- **PUT /api/Products/{id}**: Updates an existing product.
- **DELETE /api/Products/{id}**: Deletes a product by its ID.
- **POST /api/Products/{id}/amount/{quantity}**: Retrieve the amount of a product based on the quuantity, including subtotal, tax and total.



