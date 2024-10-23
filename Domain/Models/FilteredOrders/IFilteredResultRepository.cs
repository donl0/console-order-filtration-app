namespace Domain.Models.FilteredOrders
{
    public interface IFilteredResultRepository
    {
        public Task<FilteredResult> GetFilteredResultByDistrictNameAsync(string districtName);
        public Task<long> CreateAsync(FilteredResult value, CancellationToken cancellationToken);
        public Task<List<FilteredResult>> GetAllAsync();
        public Task<long> UpdateAsync(FilteredResult filteredResult, CancellationToken cancellationToken);
    }
}
