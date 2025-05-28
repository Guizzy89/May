using Microsoft.EntityFrameworkCore;
using WebApplication1.BusinessLogicLayer.Services;
using WebApplication1.DataAccessLayer;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� ���� ������
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� �������� � ������������
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>(); //��� ���?
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IRepository, Repository>();// ������ �� �����?

// ����������� ������������
builder.Services.AddControllers();

// �������� ����������
var app = builder.Build();

// ��������� ����������� ������
app.UseStaticFiles();

// ��������� ������������� ��� API-������������
app.UseRouting();

// ��������� �������� �����
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // ����������� ������������
});

// ������� �������� ��� ������������
app.MapGet("/", () => "Hello World!");
app.MapGet("/1", () => "Hello ALL World!");

// ������ ����������
app.Run();