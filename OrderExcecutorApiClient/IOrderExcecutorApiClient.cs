using ApiClient.Models;
using Domain.Models.FilteredOrders;

namespace ApiClient
{
    public interface IOrderExcecutorApiClient
    {
        Task<long> CreateOrderAsync(Guid uniqueNumber, int weight, DateTime deliveryTime, string districtName, CancellationToken cancellationToken);
        Task<List<FilteredResult>> GetAllFilteredResultsAsync(CancellationToken cancellationToken);
        Task<List<OrderResponce>> InitializeFilteringAsync(DateTime timeAfterFirstOrder, string districtName, CancellationToken cancellationToken);
    }
}