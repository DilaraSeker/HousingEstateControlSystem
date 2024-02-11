# Housing Estate Control System

Bu proje, bir apartman sitesinin aidat ve ortak kullanım faturalarının yönetimini sağlayan bir sistemdir. 

## Proje Tanımı

Bu projede, .NET 8 ve EF Core kullanılarak bir RESTful API geliştirilmiştir. Proje, apartman site yöneticileri ve daire sahipleri/kiracıları için ayrı ayrı işlevselliğe sahiptir. Yönetici, dairelerin aidat ve fatura bilgilerini girerken, daire sahipleri/kiracıları kendi ödemelerini yapabilirler. Proje, MS SQL Server veritabanı üzerinde çalışmaktadır.

## Dosya Yapısı

# HousingEstateControlSystem

- **HousingEstateControlSystem.API**
  - **Controllers**
    - UserController.cs
    - CondoController.cs
    - DuesController.cs
    - BillController.cs
    - AuthController.cs
    - PaymentController.cs
  - **Filters**
    - NotFoundActionFilter.cs
  - **Middlewares**
    - ExceptionMiddleware.cs
  - Program.cs
  - appsettings.json

- **HousingEstateControlSystem.Services**
  - **Interfaces**
    - IUserService.cs
    - ICondoService.cs
    - IDuesService.cs
    - IBillService.cs
    - IPaymentService.cs
  - **Implementations**
    - UserService.cs
    - CondoService.cs
    - DuesService.cs
    - BillService.cs
    - PaymentService.cs
  - **Mappers**
    - UserMapper.cs
    - CondoMapper.cs
    - DuesMapper.cs
    - BillMapper.cs
    - PaymentMapper.cs

- **HousingEstateControlSystem.Repositories**
  - **Models**
    - User.cs
    - Condo.cs
    - Dues.cs
    - Bill.cs
    - Role.cs
    - Payment.cs
  - **Interfaces**
    - IUserRepository.cs
    - ICondoRepository.cs
    - IDuesRepository.cs
    - IBillRepository.cs
    - IPaymentRepository.cs
  - **Implementations**
    - UserRepository.cs
    - CondoRepository.cs
    - DuesRepository.cs
    - BillRepository.cs
    - PaymentRepository.cs
  - **Migrations**
  - DatabaseContext.cs

- **HousingEstateControlSystem.Common**
  - ResponseDto.cs

- **HousingEstateControlSystem.DTOs**
  - **User**
    - UserDTO.cs
    - UserAddDtoRequest.cs
    - UserUpdateRequest.cs
  - **Bill**
    - BillDTO.cs
    - BillAddDtoRequest.cs
    - BillUpdateRequest.cs
  - **Dues**
    - DuesDTO.cs
    - DuesAddDtoRequest.cs
    - DuesUpdateRequest.cs
  - **Payment**
    - PaymentDTO.cs
    - PaymentAddDtoRequest.cs
    - PaymentUpdateRequest.cs
  - **Condo**
    - CondoDTO.cs
    - CondoAddDtoRequest.cs
    - CondoUpdateRequest.cs
  - **Login**
    - LoginDTO.cs


## Nasıl Çalıştırılır?

1. Proje klonlanır.
2. `HousingEstateControlSystem.API` klasörüne gidilir ve `dotnet run` komutu ile projenin çalıştırılması sağlanır.
3. API, varsayılan olarak `https://localhost:5001` adresinde çalışır.
4. Postman veya benzer bir araç kullanarak API endpoint'lerine istekler gönderilebilir.

## Kullanılan Teknolojiler

- .NET 8
- Entity Framework Core
- MS SQL Server
- RESTful API
- JWT Authentication
