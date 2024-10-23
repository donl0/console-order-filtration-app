namespace Domain.Models.FilteredOrders
{
    public interface IFilteredResultRepository
    {
        public Task<FilteredResult> GetFilteredResultByDistrictNameAsync();
        public Task<long> CreateAsync(FilteredResult value); 
    }
}
