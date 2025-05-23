using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;
using ProductAPI.MapperProfile;
using ProductAPI.ProductServices;
using ProductAPI.ProjectDbContext;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ProjectDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DockerConnection"));
});
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.MapScalarApiReference("/productApi");
//}

app.MapOpenApi();

app.MapScalarApiReference("/productApi");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
