using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //builder.Services.AddControllers();

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContextFactory<ElDbContext>(
            op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("MyConn1"));
            }
        );
        builder.Services.AddScoped<ICategoryServ, CategoryServ>();
        builder.Services.AddScoped<IRepository<FoodServed>, FoodServedRepoService>();
        builder.Services.AddScoped<IRepository<Order>, OrderRepoService>();
        builder.Services.AddScoped<IRepository<OrderDetails>, OrderDetailsRepoService>();
        builder.Services.AddScoped<IRepository<Restaurant>, RestaurantRepoService>();
        builder.Services.AddScoped<IRepository<User>, UserRepoService>();
        builder.Services.AddScoped<IRepository<UserType>, UserTypeRepoService>();


        //AddCors ^&*%^&$%^&#$%^#^
        builder.Services.AddCors(p=>p.AddPolicy("corspolicy",build =>
        {
            build.WithOrigins("https://localhost:7007").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            build.AllowAnyOrigin();
            //build.WithOrigins("https://localhost:7137").AllowAnyMethod().AllowAnyHeader();

        }));



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //AddCors Name ^&*%^&$%^&#$%^#^
        app.UseCors("corspolicy");

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}