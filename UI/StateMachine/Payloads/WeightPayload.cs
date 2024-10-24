namespace UI.StateMachine.Payloads
{
    internal sealed class WeightPayload : BasePayload, IPayload<int>
    {
        private readonly int _payload;

        public int Payload => _payload;
        public WeightPayload(int payload)
        {
            _payload = payload;
        }
    }
}
