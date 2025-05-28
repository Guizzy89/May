using Microsoft.EntityFrameworkCore;
using WebApplication1.BusinessLogicLayer.Services;
using WebApplication1.DataAccessLayer;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервисов и репозиториев
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>(); //Что это?
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IRepository, Repository>();// Почему не могут?

// Регистрация контроллеров
builder.Services.AddControllers();

// Создание приложения
var app = builder.Build();

// Включение статических файлов
app.UseStaticFiles();

// Настройка маршрутизации для API-контроллеров
app.UseRouting();

// Настройка конечных точек
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Регистрация контроллеров
});

// Простые маршруты для тестирования
app.MapGet("/", () => "Hello World!");
app.MapGet("/1", () => "Hello ALL World!");

// Запуск приложения
app.Run();