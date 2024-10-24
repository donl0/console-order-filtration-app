using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;
using UI.StateMachine.StateSwitcher;

namespace UI.StateMachine.Transitions
{
    internal class RetryOnNegativeValidationTransition : BaseTransition<IValidatableState>
    {
        public RetryOnNegativeValidationTransition(IStateSwitcher stateSwitcher, IValidatableState previousState, IValidatableState nextState) : base(stateSwitcher, previousState, nextState)
        {
        }

        public override bool TryTransit()
        {
            if (CurrentState.IsValid == false)
            {
                GoCurrentState();
                return true;
            }

            return false;
        }
    }
}
