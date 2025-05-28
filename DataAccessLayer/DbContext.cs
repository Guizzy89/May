using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer
{
    public class StoreDbContext : DbContext
    {
        // Коллекции сущностей
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } // Добавлена коллекция категорий
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        // Конструктор с параметрами для настройки контекста
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        // Конфигурация строки подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyStoreDB;Trusted_Connection=True;");
            }
        }

        // Основная настройка моделей данных и их взаимосвязей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка поля "цена" для товаров с типом данных Decimal(18,2)
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 2)");

            // Настройка модели пользователя
            modelBuilder.Entity<User>(static entity =>
            {
                entity.HasKey(u => u.UserId);          // Первичный ключ
                entity.Property(u => u.Email).HasMaxLength(256).IsRequired(); // Уникальность и индексирование
                entity.Property(u => u.FirstName).IsRequired(); // Обязательное поле
                entity.Property(u => u.LastName).IsRequired();   // Обязательное поле
            });

            // Настройка модели заказа
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);           // Первичный ключ
                entity.Property(o => o.CreatedAt).IsRequired(); // Обязательность даты создания
                entity.Property(o => o.TotalPrice).IsRequired(); // Обязательность общей суммы
                entity.Property(o => o.Adress).IsRequired();     // Обязательность адреса доставки
            });

            // Настройка модели корзины
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.CartId);                 // Первичный ключ
                entity.HasOne(c => c.User)                    // Односторонняя связь с пользователем
                  .WithOne(u => u.Cart)               // Пользователь владеет одной корзиной
                  .HasForeignKey<Cart>(c => c.UserId);        // Внешний ключ на пользователя
            });

            // Настройка модели элементов корзины
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(ci => ci.CartItemId);            // Первичный ключ
                entity.HasOne(ci => ci.Product)                // Элемент корзины ссылается на продукт
                  .WithMany(p => p.CartItems)                 // Продукт может находиться в нескольких корзинах
                  .HasForeignKey(ci => ci.ProductId);         // Внешний ключ на продукт
                entity.HasOne(ci => ci.Cart)                   // Элемент корзины принадлежит определенной корзине
                  .WithMany(c => c.Items)                     // Корзина содержит множество элементов
                  .HasForeignKey(ci => ci.CartId);            // Внешний ключ на корзину
            });

            // Настройка модели категории
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(cat => cat.CategoryId);        // Первичный ключ
                entity.Property(cat => cat.Name).IsRequired();// Название категории обязательное
            });

            // Связь между категорией и продуктом
            modelBuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);
        }
    }
}