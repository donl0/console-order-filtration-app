namespace UI.StateMachine.Payloads
{
    internal sealed class UniqueNumberPayload : BasePayload, IPayload<Guid>
    {
        private readonly Guid _number;

        public Guid Payload => _number;

        public UniqueNumberPayload(Guid number)
        {
            _number = number;
        }
    }
}
