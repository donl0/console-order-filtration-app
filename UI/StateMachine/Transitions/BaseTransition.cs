using UI.StateMachine.States;
using UI.StateMachine.StateSwitcher;

namespace UI.StateMachine.Transitions
{
    internal abstract class BaseTransition<T> : IBaseTransition where T : ITransitionableBaseState
    {
        protected readonly T CurrentState;
        protected readonly T NextState;

        protected readonly IStateSwitcher StateSwitcher;

        protected BaseTransition(IStateSwitcher stateSwitcher, T currentState, T nextState)
        {
            StateSwitcher = stateSwitcher;
            CurrentState = currentState;
            NextState = nextState;
        }

        protected void GoCurrentState() {
            StateSwitcher.SwithState(CurrentState);
        }

        protected void GoNextState() {
            StateSwitcher.SwithState(NextState);
        }

        public abstract bool TryTransit();
    }
}
