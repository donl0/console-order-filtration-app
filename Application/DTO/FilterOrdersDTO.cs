using Domain.Models.Orders;

namespace Application.DTO
{
    public class FilterOrdersDTO
    {
        public DateTime TimeAfterFirstOrder { get; private set; }
        public string DistrictName { get; private set; }
    }
}
