﻿using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public sealed class FilterOrdersServise : IFilterOrdersServise
    {
        private readonly IFilteredResultRepository _filteredResultRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ILogger<FilterOrdersServise> _logger;

        public FilterOrdersServise(IFilteredResultRepository filteredResultRepository, IOrderRepository orderRepository, IDistrictRepository districtRepository, ILogger<FilterOrdersServise> logger)
        {
            _filteredResultRepository = filteredResultRepository;
            _orderRepository = orderRepository;
            _districtRepository = districtRepository;
            _logger = logger;
        }

        public async Task<List<FilteredResult>> GetAllAsync()
        {
            List<FilteredResult> results = await _filteredResultRepository.GetAllAsync();

            return results;
        }

        public async Task<List<Order>> Filter(FilterOrdersDTO filterOrdersDTO, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Filter started with params: {@filterOrdersDTO}", filterOrdersDTO);

            DateTime utfTime = DateTime.SpecifyKind(filterOrdersDTO.TimeAfterFirstOrder, DateTimeKind.Utc);

            List<Order> closestOrders = await _orderRepository.GetCloseOrdersInHalfHourAsync(utfTime, filterOrdersDTO.DistrictName);

            FilteredResult filteredResult = await _filteredResultRepository.GetFilteredResultByDistrictNameAsync(filterOrdersDTO.DistrictName);

            if (filteredResult == null)
            {
                await Create(filterOrdersDTO.DistrictName, utfTime, _districtRepository, closestOrders, cancellationToken);

                return closestOrders;
            }
            else
            {
                await Update(filteredResult, utfTime, closestOrders, cancellationToken);

                return closestOrders;
            }

            _logger.LogInformation("Filter ends with result: {@filteredResult}", filteredResult);
        }

        private async Task<long> Update(FilteredResult filteredResult, DateTime time, List<Order> closestOrders, CancellationToken cancellationToken)
        {
            filteredResult.Update(closestOrders, time);

            long id = await _filteredResultRepository.UpdateAsync(filteredResult, cancellationToken);

            return id;
        }

        private async Task<long> Create(string districtName, DateTime time, IDistrictRepository districtRepository, List<Order> closestOrders, CancellationToken cancellationToken)
        {
            District district = await districtRepository.GetByNameAsync(districtName);

            if (district == null)
            {
                throw new DistrictNotFound(districtName);
            }

            FilteredResult filteredResult = new FilteredResult(time, district, closestOrders);

            await _filteredResultRepository.CreateAsync(filteredResult, cancellationToken);

            return filteredResult.Id;
        }
    }
}
