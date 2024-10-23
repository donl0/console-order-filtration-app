using Application.DTO;

namespace Application.Interfaces
{
    public interface ICreateOrederService
    {
        Task CreateAsync(CreateOrderDTO createOrderDto);
    }
}