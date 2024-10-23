using Domain.Exceptions;
using Domain.Models.Orders;
using Domain.Primitives;

namespace Domain.Models.FilteredOrders
{
    public class FilteredResult: Entity
    {
        public DateTime TimeAfterFirstOrder { get; private set; }
        public District District { get; private set; }
        public List<Order> Orders { get; private set; }

        public FilteredResult() { }

        public FilteredResult(DateTime timeAfterFirstOrder, District district, List<Order> orders)
        {
            TimeAfterFirstOrder = timeAfterFirstOrder;
            District = district;
            Orders = orders;

            Validate();
        }

        public void Update(List<Order> orders, DateTime timeAfterFirstOrder) {
            Orders = orders;
            TimeAfterFirstOrder = timeAfterFirstOrder;

            Validate();
        }

        private void Validate()
        {
            if (District == null)
                throw new FieldIsNullOrEmptyException(nameof(District));
        }
    }
}
