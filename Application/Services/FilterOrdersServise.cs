using Application.DTO;
using Application.Exceptions;
using Domain.Models.FilteredOrders;
using Domain.Models.Orders;

namespace Application.Services
{
    public sealed class FilterOrdersServise : IFilterOrdersServise
    {
        private readonly IFilteredResultRepository _filteredResultRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDistrictRepository _districtRepository;

        public FilterOrdersServise(IFilteredResultRepository filteredResultRepository, IOrderRepository orderRepository, IDistrictRepository districtRepository)
        {
            _filteredResultRepository = filteredResultRepository;
            _orderRepository = orderRepository;
            _districtRepository = districtRepository;
        }

        public async Task<long> Filter(FilterOrdersDTO filterOrdersDTO, CancellationToken cancellationToken)
        {
            List<Order> closestOrders = await _orderRepository.GetCloseOrdersInHalfHourAsync(filterOrdersDTO.TimeAfterFirstOrder, filterOrdersDTO.DistrictName);

            FilteredResult filteredResult = await _filteredResultRepository.GetFilteredResultByDistrictNameAsync(filterOrdersDTO.DistrictName);

            if (filteredResult == null)
            {
                long id = await Create(filteredResult, filterOrdersDTO, _districtRepository, closestOrders, cancellationToken);

                return id;
            }
            else
            {
                long id = await Update(filteredResult, closestOrders, cancellationToken);

                return id;
            }
        }

        private async Task<long> Update(FilteredResult filteredResult, List<Order> closestOrders, CancellationToken cancellationToken)
        {
            filteredResult.Update(closestOrders, filteredResult.TimeAfterFirstOrder);

            long id = await _filteredResultRepository.UpdateAsync(filteredResult, cancellationToken);

            return id;
        }

        private async Task<long> Create(FilteredResult filteredResult, FilterOrdersDTO filterOrdersDTO, IDistrictRepository districtRepository, List<Order> closestOrders, CancellationToken cancellationToken)
        {
            District district = await districtRepository.GetByNameAsync(filterOrdersDTO.DistrictName);

            if (district == null)
            {
                throw new DistrictNotFound(filterOrdersDTO.DistrictName);
            }

            filteredResult = new FilteredResult(filterOrdersDTO.TimeAfterFirstOrder, district, closestOrders);

            await _filteredResultRepository.CreateAsync(filteredResult, cancellationToken);

            return filteredResult.Id;
        }
    }
}
