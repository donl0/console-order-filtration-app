using UI.StateMachine.States;

namespace UI.StateMachine.StateSwitcher
{
    internal interface IStateSwitcher
    {
        public void SwithState(ITransitionableBaseState transitTo);
    }
}
