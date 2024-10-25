using ApiClient;
using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.Payloads;
using UI.Utils;
using Domain.Models.Orders;
using ApiClient.Models;

namespace UI.StateMachine.States
{
    internal class FilterOrdersState : BaseState
    {
        private readonly IOrderExcecutorApiClient _apiClient;
        private readonly IOrderPrinter _orderPrinter;

        public FilterOrdersState(IInputDataBag bag, IOrderExcecutorApiClient apiClient, IOrderPrinter orderPrinter) : base(bag)
        {
            _apiClient = apiClient;
            this._orderPrinter = orderPrinter;
        }

        public override async Task ExecuteInput()
        {
            string district = Bag.GetPayload<DistrictPayload>().Payload;
            DateTime time = Bag.GetPayload<TimeDeliveryPayload>().Payload;

            try
            {
                List<OrderResponce> result = await _apiClient.InitializeFilteringAsync(time, district, new CancellationToken());

                Console.WriteLine("Order filtered sucess!");

                _orderPrinter.Print(result);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during filtering");
            }
        }
    }
}
