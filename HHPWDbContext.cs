using Microsoft.EntityFrameworkCore;
using hhpw_be.Models;

namespace hhpw_be
{
    public class HHPWDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }

        public HHPWDbContext(DbContextOptions<HHPWDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, IsCashier = true, Uid = "uid1" },
                new User { Id = 2, IsCashier = false, Uid = "uid2" },
                new User { Id = 3, IsCashier = true, Uid = "uid3" },
                new User { Id = 4, IsCashier = false, Uid = "uid4" },
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { Id = 1, CustomerId = 4, CustomerName = "Johnny Faucet", CustomerEmail = "johnny@faucet.com", CustomerPhone = "606-600-0006", DateClosed = DateTime.Now, IsClosed = true, OrderTypeId = 2, PaymentTypeId = 1, Total = 24.44M },
                new Order { Id = 2, CustomerId = 3, CustomerName = "Bros Keet", CustomerEmail = "bro@keet.com", CustomerPhone = "838-830-0006", DateClosed = null, IsClosed = false, OrderTypeId = 1, PaymentTypeId = 2, Total = 56.44M },
                new Order { Id = 3, CustomerId = 2, CustomerName = "Jim Jo", CustomerEmail = "jim@jo.com", CustomerPhone = "002-387-0006", DateClosed = DateTime.Now, IsClosed = true, OrderTypeId = 3, PaymentTypeId = 3, Total = 93.44M },
                new Order { Id = 4, CustomerId = 1, CustomerName = "Greg Gerg", CustomerEmail = "greg@gerg.com", CustomerPhone = "499-399-0006", DateClosed = null, IsClosed = false, OrderTypeId = 3, PaymentTypeId = 1, Total = 28.44M },
            });

            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item { Id = 1, Name = "Toblerone Cake", Price = 24.99M },
                new Item { Id = 2, Name = "Donut Shake", Price = 6.99M },
                new Item { Id = 3, Name = "Chicken Hibachi", Price = 18.99M },
                new Item { Id = 4, Name = "California Roll", Price = 24.99M }
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType { Id = 1, Name = "Cash" },
                new PaymentType { Id = 2, Name = "Card" },
                new PaymentType { Id = 3, Name = "PayPal" }
            });

            modelBuilder.Entity<OrderType>().HasData(new OrderType[]
            {
                new OrderType { Id = 1, Name = "Walk-in" },
                new OrderType { Id = 2, Name = "Call-in" },
                new OrderType { Id = 3, Name = "Mobile" }
            });
        }
    }
}
