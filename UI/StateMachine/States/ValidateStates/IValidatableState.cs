namespace UI.StateMachine.States.ValidateStates
{
    internal interface IValidatableState : ITransitionableBaseState
    {
        public bool ValidationIsValid { get; }
    }
}
