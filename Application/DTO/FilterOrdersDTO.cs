using Domain.Models.Orders;

namespace Application.DTO
{
    public class FilterOrdersDTO
    {
        public DateTime TimeAfterFirstOrder { get; set; }
        public string DistrictName { get; set; }
    }
}
