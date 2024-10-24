namespace Application.DTO
{
    public class CreateOrderDTO
    {
        public Guid UniqueNumber { get; set; }
        public int Weight { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string DistrictName { get; set; }
    }
}
