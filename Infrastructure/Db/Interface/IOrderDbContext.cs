using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db.Interface
{
    public interface IDbContext
    {
        public DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
