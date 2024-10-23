using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db.Interface
{
    public interface IDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<FilteredResult> FilteredResults { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
