using Domain.Exceptions;

namespace Domain.Models
{
    public class Order : Entity
    {
        public Guid UniqueNumber { get; private set; }
        public int Weight { get; private set; }
        public DateTime DeliveryTime{ get; private set; }
        public District District { get; private set; }

        public Order() { }

        public Order(Guid uniqueNumber, int weight, DateTime deliveryTime, District district)
        {
            UniqueNumber = uniqueNumber;
            Weight = weight;
            DeliveryTime = deliveryTime;
            District = district;

            Validate();
        }

        private void Validate()
        {
            if (UniqueNumber == Guid.Empty)
                throw new FieldIsNullOrEmptyException(nameof(UniqueNumber));

            if (Weight == null)
                throw new FieldIsNullOrEmptyException(nameof(Weight));

            if (DeliveryTime == null)
                throw new FieldIsNullOrEmptyException(nameof(DeliveryTime));

            if (District == null)
                throw new FieldIsNullOrEmptyException(nameof(District));

            if (Weight <= 0)
                throw new WeightExceptino(nameof(Weight));

            if (DeliveryTime < DateTime.UtcNow)
                throw new FutureTimeException(DeliveryTime.ToString());
        }
    }
}
