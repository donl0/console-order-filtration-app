using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using Infrastructure.Db.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Repositories
{
    public sealed class FilteredResultRepository : IFilteredResultRepository
    {
        private readonly IDbContext _dbContext;

        public FilteredResultRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> CreateAsync(FilteredResult value, CancellationToken cancellationToken)
        {
            await _dbContext.FilteredResults.AddAsync(value);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return value.Id;
        }

        public async Task<FilteredResult> GetFilteredResultByDistrictNameAsync(string districtName)
        {
            FilteredResult result = await _dbContext.FilteredResults
                .Include(fr => fr.District)
                .FirstOrDefaultAsync(fr => fr.District.Name == districtName);

            return result;
        }

        public async Task<long> UpdateAsync(FilteredResult filteredResult, CancellationToken cancellationToken)
        {
            _dbContext.FilteredResults.Update(filteredResult);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return filteredResult.Id;
        }
    }
}
