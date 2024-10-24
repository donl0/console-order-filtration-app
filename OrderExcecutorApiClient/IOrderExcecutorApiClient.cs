using Domain.Models.FilteredOrders;
using Domain.Models.Orders;

namespace ApiClient
{
    public interface IOrderExcecutorApiClient
    {
        Task<long> CreateOrderAsync(Guid uniqueNumber, int weight, DateTime deliveryTime, string districtName, CancellationToken cancellationToken);
        Task<List<FilteredResult>> GetAllFilteredResultsAsync(CancellationToken cancellationToken);
        Task<List<Order>> InitializeFilteringAsync(DateTime timeAfterFirstOrder, string districtName, CancellationToken cancellationToken);
    }
}