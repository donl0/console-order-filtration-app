using ApiClient;
using UI.StateMachine.Payloads;
using UI.StateMachine.Payloads.InputData;

namespace UI.StateMachine.States
{
    internal class CreateOrderState : BaseState
    {
        private readonly IOrderExcecutorApiClient _apiClient;

        public CreateOrderState(IInputDataBag bag, IOrderExcecutorApiClient apiClient) : base(bag)
        {
            _apiClient = apiClient;
        }

        public override async Task ExecuteInput()
        {
            Guid number = Bag.GetPayload<UniqueNumberPayload>().Payload;
            string district = Bag.GetPayload<DistrictPayload>().Payload;
            int weight = Bag.GetPayload<WeightPayload>().Payload;
            DateTime time = Bag.GetPayload<TimeDeliveryPayload>().Payload;

            try {
                var result = await _apiClient.CreateOrderAsync(number, weight, time, district, new CancellationToken());

                Console.WriteLine("Order create sucess!");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during saving");
            }
        }
    }
}
