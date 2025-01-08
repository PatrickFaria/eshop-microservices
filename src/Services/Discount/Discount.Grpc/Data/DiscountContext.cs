using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id= 1, ProductName = "IphoneX", Description = "Iphone Discription", Amount = 300},
            new Coupon { Id= 2, ProductName = "Samsung s24", Description = "Samsung Discription", Amount = 200}
            );
    }
}
