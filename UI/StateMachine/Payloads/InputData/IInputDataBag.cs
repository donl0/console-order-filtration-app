namespace UI.StateMachine.Payloads.InputData
{
    internal interface IInputDataBag
    {
        string LastInputData { get; }

        T GetPayload<T>() where T : BasePayload;
        void SetLastInput(string value);
        void SetPayload(BasePayload value);
    }
}