namespace UI.StateMachine.Transitions
{
    internal interface IBaseTransition
    {
        public bool TryTransit();
    }
}