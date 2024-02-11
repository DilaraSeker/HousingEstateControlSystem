# Housing Estate Control System

Bu proje, bir apartman sitesinin aidat ve ortak kullanım faturalarının yönetimini sağlayan bir sistemdir. 

## Proje Tanımı

Bu projede, .NET 8 ve EF Core kullanılarak bir RESTful API geliştirilmiştir. Proje, apartman site yöneticileri ve daire sahipleri/kiracıları için ayrı ayrı işlevselliğe sahiptir. Yönetici, dairelerin aidat ve fatura bilgilerini girerken, daire sahipleri/kiracıları kendi ödemelerini yapabilirler. Proje, MS SQL Server veritabanı üzerinde çalışmaktadır.

## Dosya Yapısı

HousingEstateControlSystem
│
├───HousingEstateControlSystem.API
│ ├───Controllers
│ ├───Filters
│ ├───Middlewares
│ ├───Program.cs
│ └───appsettings.json
│
├───HousingEstateControlSystem.Services
│ ├───Interfaces
│ ├───Implementations
│ └───Mappers
│
├───HousingEstateControlSystem.Repositories
│ ├───Models
│ ├───Interfaces
│ ├───Implementations
│ └───Migrations
│
├───HousingEstateControlSystem.Common
│ └───ResponseDto.cs
│
└───HousingEstateControlSystem.DTOs
├───User
├───Bill
├───Dues
├───Payment
└───Condo


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

## Katkıda Bulunma

1. Bu repoyu forklayın.
2. Yeni bir branch oluşturun: `git checkout -b yeni-özellik`
3. Yaptığınız değişiklikleri commitleyin: `git commit -am 'Yeni özellik eklendi'`
4. Branch'i pushlayın: `git push origin yeni-özellik`
5. Pull request (PR) oluşturun.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.
