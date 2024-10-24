namespace ApiClient.Models
{
    public class OrderResponce
    {
        public Guid UniqueNumber { get; set; }
        public int Weight { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DistrictResponce District { get; set; }
    }
}
