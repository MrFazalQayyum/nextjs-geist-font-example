using Microsoft.EntityFrameworkCore;
using FoodDeliveryAdmin.Models;

namespace FoodDeliveryAdmin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .HasForeignKey(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(m => m.OrderItems)
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed initial data
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "Pizza Palace",
                    Description = "Authentic Italian pizzas made with fresh ingredients and traditional recipes",
                    ImageUrl = "https://images.pexels.com/photos/315755/pexels-photo-315755.jpeg",
                    Rating = 4.5m,
                    DeliveryTime = "25-35 min",
                    DeliveryFee = 2.99m,
                    Address = "123 Main St, City",
                    Phone = "555-0123",
                    Email = "info@pizzapalace.com"
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Burger Barn",
                    Description = "Juicy gourmet burgers with premium beef and fresh toppings",
                    ImageUrl = "https://images.pexels.com/photos/1639557/pexels-photo-1639557.jpeg",
                    Rating = 4.3m,
                    DeliveryTime = "20-30 min",
                    DeliveryFee = 1.99m,
                    Address = "456 Oak Ave, City",
                    Phone = "555-0124",
                    Email = "info@burgerbarn.com"
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Sushi Zen",
                    Description = "Fresh sushi and Japanese cuisine prepared by expert chefs",
                    ImageUrl = "https://images.pexels.com/photos/357756/pexels-photo-357756.jpeg",
                    Rating = 4.7m,
                    DeliveryTime = "30-40 min",
                    DeliveryFee = 3.99m,
                    Address = "789 Pine St, City",
                    Phone = "555-0125",
                    Email = "info@sushizen.com"
                }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Margherita Pizza",
                    Description = "Classic pizza with tomato sauce, mozzarella, and fresh basil",
                    Price = 14.99m,
                    ImageUrl = "https://images.pexels.com/photos/315755/pexels-photo-315755.jpeg",
                    Category = "Pizza",
                    RestaurantId = 1
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Pepperoni Pizza",
                    Description = "Traditional pizza topped with pepperoni and mozzarella cheese",
                    Price = 16.99m,
                    ImageUrl = "https://images.pexels.com/photos/315755/pexels-photo-315755.jpeg",
                    Category = "Pizza",
                    RestaurantId = 1
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Classic Cheeseburger",
                    Description = "Beef patty with cheese, lettuce, tomato, and special sauce",
                    Price = 12.99m,
                    ImageUrl = "https://images.pexels.com/photos/1639557/pexels-photo-1639557.jpeg",
                    Category = "Burgers",
                    RestaurantId = 2
                }
            );
        }
    }
}
