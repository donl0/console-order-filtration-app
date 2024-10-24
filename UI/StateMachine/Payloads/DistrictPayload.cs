namespace UI.StateMachine.Payloads
{
    internal sealed class DistrictPayload : BasePayload, IPayload<string>
    {
        private readonly string _name;

        public string Payload => _name;

        public DistrictPayload(string name)
        {
            _name = name;
        }
    }
}
