using ApiClient.Models;
using UI.Extentions.Printer;

namespace UI.Utils
{
    internal sealed class OrderPrinter : IOrderPrinter
    {
        public void Print(List<OrderResponce> orders)
        {
            foreach (var item in orders)
            {
                item.Print();
            }
        }
    }
}
