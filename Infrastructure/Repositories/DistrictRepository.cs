using Domain.Models.Orders;
using Infrastructure.Db.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly IDbContext _dbContext;

        public DistrictRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfExistAsync(string name)
        {
            return await _dbContext.Districts.AnyAsync(d => d.Name == name);
        }

        public async Task CreateAsync(District district, CancellationToken cancellationToken)
        {
            await _dbContext.Districts.AddAsync(district);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<District> GetByNameAsync(string name)
        {
            return await _dbContext.Districts.FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
