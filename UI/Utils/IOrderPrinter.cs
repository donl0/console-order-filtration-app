using ApiClient.Models;

namespace UI.Utils
{
    internal interface IOrderPrinter
    {
        void Print(List<OrderResponce> orders);
    }
}