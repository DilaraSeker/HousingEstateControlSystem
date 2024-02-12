# Housing Estate Control System

Bu proje, bir apartman sitesinin aidat ve ortak kullanım faturalarının yönetimini sağlayan bir sistemdir. 

## Proje Tanımı

Bu projede, .NET 8 ve EF Core kullanılarak bir RESTful API geliştirilmiştir. Proje, apartman site yöneticileri ve daire sahipleri/kiracıları için ayrı ayrı işlevselliğe sahiptir. Yönetici, dairelerin aidat ve fatura bilgilerini girerken, daire sahipleri/kiracıları kendi ödemelerini yapabilirler. Proje, MS SQL Server veritabanı üzerinde çalışmaktadır.

## Dosya Yapısı

# HousingEstateControlSystem

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
  
## Nasıl Çalıştırılır?

1. Proje klonlanır.
2. `HousingEstateControlSystem.API` klasörüne gidilir ve `dotnet run` komutu ile projenin çalıştırılması sağlanır.
3. API, varsayılan olarak `https://localhost:7144` adresinde çalışır.
4. Postman veya benzer bir araç kullanarak API endpoint'lerine istekler gönderilebilir.

## Kullanılan Teknolojiler

- .NET 8
- Entity Framework Core
- MS SQL Server
- RESTful API
- JWT Authentication
