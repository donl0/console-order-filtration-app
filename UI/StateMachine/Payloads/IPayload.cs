namespace UI.StateMachine.Payloads
{
    internal interface IPayload <T>
    {
        public T Payload { get; }
    }
}
