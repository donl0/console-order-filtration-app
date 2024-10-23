using Application.DTO;
using Domain.Models.FilteredOrders;
using Domain.Models.Orders;

namespace Application.Interfaces
{
    public interface IFilterOrdersServise
    {
        Task<List<Order>> Filter(FilterOrdersDTO filterOrdersDTO, CancellationToken cancellationToken);
        Task<List<FilteredResult>> GetAllAsync();
    }
}