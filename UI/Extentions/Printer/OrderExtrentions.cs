using ApiClient.Models;

namespace UI.Extentions.Printer
{
    internal static class OrderExtrentions
    {
        public static void Print(this OrderResponce value)
        {
            Console.WriteLine("---\nNumber: " + value.UniqueNumber +
                "\n District: " + value.District.Name + "\n Delivery time: "
                + value.DeliveryTime
                + "\n Weight: " + value.Weight);
        }
    }
}
