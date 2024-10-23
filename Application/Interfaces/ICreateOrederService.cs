using Application.DTO;

namespace Application.Interfaces
{
    public interface ICreateOrederService
    {
        void CreateAsync(CreateOrderDTO createOrderDto);
    }
}