namespace UI.StateMachine.Payloads
{
    internal class TimeDeliveryPayload : BasePayload, IPayload<DateTime>
    {
        private readonly DateTime _time;

        public DateTime Payload => _time;

        public TimeDeliveryPayload(DateTime time)
        {
            _time = time;
        }
    }
}
