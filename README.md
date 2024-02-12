# Housing Estate Control System

This project is a system for managing dues and common usage bills of an apartment complex.

## Project Description

In this project, a RESTful API is developed using .NET 8 and EF Core. The project provides functionality for both apartment site managers and apartment owners/tenants. The manager can enter dues and bill information for the units, while owners/tenants can make their payments. The project runs on MS SQL Server.

## Layers

### 1. HousingEstateControlSystem.API

**Controllers:** API requests handling components reside in this folder.
- **AuthController.cs:** Handles requests related to authentication and authorization.
- **BillController.cs:** Processes requests for bill operations.
- **CondoController.cs:** Processes requests for condo operations.
- **DuesController.cs:** Processes requests for dues operations.
- **PaymentController.cs:** Processes requests for payment operations.
- **UserController.cs:** Processes requests for user operations.

**Filters:** Contains filters that perform necessary checks during processing.
- **NotFoundActionFilter.cs:** Handles requests made to resources that cannot be found.

**Middlewares:** Contains middleware components for processing requests and responses.
- **ExceptionMiddleware.cs:** Handles exceptions within the application.
- **LoggingMiddleware.cs:** Handles logging of requests and responses.

**Program.cs:** Entry point of the application.

**appsettings.json:** Configuration file containing application settings.

### 2. HousingEstateControlSystem.Services

**Interfaces:** Contains interfaces defining the methods of services.
**Implementations:** Contains application classes that implement the business logic of services.
**Mappers:** Contains mapper classes that facilitate transformation between data transfer objects (DTOs) and data models.

### 3. HousingEstateControlSystem.Repositories

**Models:** Contains model classes for database structures.
**Interfaces:** Contains interfaces defining methods for database operations.
**Implementations:** Contains application classes that perform database operations.
**Migrations:** Contains code managing and applying changes to the database structure.

### 4. HousingEstateControlSystem.Common

Contains common components used across the application.
- **ResponseDto.cs:** Defines the structure of response data transfer objects (DTOs).

### 5. HousingEstateControlSystem.DTOs

Contains data transfer objects (DTOs) used for communication between layers.
- **Auth:** DTOs related to authentication.
- **Bill:** DTOs related to bill operations.
- **Condo:** DTOs related to condo operations.
- **Dues:** DTOs related to dues operations.
- **Login:** DTOs related to login operations.
- **Payment:** DTOs related to payment operations.
- **User:** DTOs related to user operations.
## File Structure

- **HousingEstateControlSystem.API**
  - **Controllers**
    - AuthController.cs
    - BillController.cs
    - CondoController.cs
    - DuesController.cs
    - PaymentController.cs
    - UserController.cs
  - **Filters**
    - NotFoundActionFilter.cs
  - **Middlewares**
    - ExceptionMiddleware.cs
    - LoggingMiddleware.cs
  - Program.cs
  - appsettings.json

- **HousingEstateControlSystem.Services**
  - **Interfaces**
    - IAuthService
    - IBillService
    - ICondoService
    - IDuesService
    - IPaymentService
    - IUserService
  - **Implementations**
    - AuthService.cs
    - BillService.cs
    - CondoService.cs
    - DuesService.cs
    - PaymentService.cs
    - UserService.cs
  - **Mappers**
    - AuthMapper.cs
    - BillMapper.cs
    - CondoMapper.cs
    - DuesMapper.cs
    - PaymentMapper.cs
    - UserMapper.cs
- **HousingEstateControlSystem.Repositories**
  - **Models**
    - Bill.cs
    - Condo.cs
    - Dues.cs
    - Payment.cs
    - Role.cs
    - User.cs
  - **Interfaces**
    - IBillRepository.cs
    - ICondoRepository.cs
    - IDuesRepository.cs
    - IPaymentRepository.cs
    - IUserRepository.cs
  - **Implementations**
    - BillRepository.cs
    - CondoRepository.cs
    - DuesRepository.cs
    - PaymentRepository.cs
    - UserRepository.cs
  - **Migrations**
  - DatabaseContext.cs

- **HousingEstateControlSystem.Common**
  - ResponseDto.cs

- **HousingEstateControlSystem.DTOs**
  - **Auth**
    - AuthDTO.cs
    - AuthResponseDTO.cs
  - **Bill**
    - BillDTO.cs
    - BillAddDtoRequest.cs
    - BillUpdateRequest.cs
  - **Condo**
    - CondoDTO.cs
    - CondoAddDtoRequest.cs
    - CondoUpdateRequest.cs
  - **Dues**
    - DuesDTO.cs
    - DuesAddDtoRequest.cs
    - DuesUpdateRequest.cs
  - **Login**
    - LoginDTO.cs
  - **Payment**
    - PaymentDTO.cs
    - PaymentAddDtoRequest.cs
    - PaymentUpdateRequest.cs
  - **User**
    - UserDTO.cs
    - UserAddDtoRequest.cs
    - UserUpdateRequest.cs
  
## How to Run?

1. Clone the project.
2. Navigate to the `HousingEstateControlSystem.API` folder and run the project using the `dotnet run` command.
3. The API runs by default at `https://localhost:7144`.
4. Requests can be sent to the API endpoints using Postman or a similar tool.

## Technologies Used

- .NET 8
- Entity Framework Core
- MS SQL Server
- RESTful API
- JWT Authentication
