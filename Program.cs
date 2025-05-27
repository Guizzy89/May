using MyStore.BusinessLogicLayer.Services;
using MyStore.DataAccessLayer.Repositories;
using WebApplication1.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/1", () => "Hello ALL World!");

app.Run();
