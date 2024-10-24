namespace UI.StateMachine.Payloads.InputData
{
    internal class InputDataBag : IInputDataBag
    {
        private string _lastInputData;

        private List<BasePayload> _payloads = new List<BasePayload>();

        public string LastInputData => _lastInputData;

        public void SetLastInput(string value)
        {
            _lastInputData = value;
        }

        public void SetPayload(BasePayload value)
        {
            var findValue = _payloads.Find(p => p.GetType() == value.GetType());

            if (findValue != null)
            {
                _payloads.Remove(findValue);

            }

            _payloads.Add(value);
        }

        public T GetPayload<T>() where T : BasePayload
        {
            foreach (var payload in _payloads)
            {
                if (payload is T typedPayload)
                {
                    return typedPayload;
                }
            }
            throw new InvalidOperationException($"Payload of type {typeof(T)} not found.");
        }
    }
}
