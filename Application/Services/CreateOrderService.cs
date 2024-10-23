﻿using Application.DTO;
using Application.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public sealed class CreateOrderService : ICreateOrederService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDistrictRepository _districtRepository;

        public CreateOrderService(IOrderRepository orderRepository, IDistrictRepository districtRepository)
        {
            _orderRepository = orderRepository;
            _districtRepository = districtRepository;
        }

        public async Task<long> CreateAsync(CreateOrderDTO createOrderDto, CancellationToken cancellationToken)
        {
            District district;

            if (await _districtRepository.CheckIfExistAsync(createOrderDto.DistrictName) == false)
            {
                district = new District(createOrderDto.DistrictName);

                await _districtRepository.CreateAsync(district, cancellationToken);
            }
            else
            {
                district = await _districtRepository.GetByNameAsync(createOrderDto.DistrictName);
            }

            Order order = new Order(createOrderDto.UniqueNumber, createOrderDto.Weight, createOrderDto.DeliveryTime, district);

            await _orderRepository.CreateAsync(order);

            return order.Id;
        }
    }
}
