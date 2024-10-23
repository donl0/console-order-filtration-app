using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using Infrastructure.Db.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db
{
    public class OrderDbContext : DbContext, IDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<FilteredResult> FilteredResults { get; set; }

        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
