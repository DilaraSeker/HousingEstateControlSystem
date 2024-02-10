using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HousingEstateControlSystem.API.Middlewares;
using HousingEstateControlSystem.Services.Interfaces;
using HousingEstateControlSystem.Services.Implementations;
using HousingEstateControlSystem.Repositories;
using HousingEstateControlSystem.Services;
using HousingEstateControlSystem.API.Filters;
using HousingEstateControlSystem.Repositories.Implementations;
using HousingEstateControlSystem.Repositories.Interfaces;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.ConfigureServices((context, services) =>
    {
        // Add DbContext
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Add scoped services
        services.AddScoped<IDuesRepository, DuesRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICondoRepository, CondoRepository>();
        services.AddScoped<IBillRepository, BillRepository>();
        services.AddScoped<IDuesService, DuesService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICondoService, CondoService>();
        services.AddScoped<IBillService, BillService>();
        // Add controllers
        services.AddControllers(options =>
        {
            options.Filters.Add<NotFoundActionFilter>();
        });

        // Add Swagger/OpenAPI
        services.AddSwaggerGen();

        // Add AutoMapper
        services.AddAutoMapper(typeof(Program));
    });

    webBuilder.Configure(app =>
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Add exception middleware
        app.UseMiddleware<ExceptionMiddleware>();

        // Configure Swagger/OpenAPI
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "HousingEstateControlSystem API V1");
        });
    });
});

builder.Build().Run();
