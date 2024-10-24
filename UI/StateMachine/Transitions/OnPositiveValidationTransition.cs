using UI.StateMachine.States.ValidateStates;
using UI.StateMachine.StateSwitcher;

namespace UI.StateMachine.Transitions
{
    internal class OnPositiveValidationTransition: BaseTransition<IValidatableState>
    {
        public OnPositiveValidationTransition(IStateSwitcher stateSwitcher, IValidatableState previousState, IValidatableState nextState) : base(stateSwitcher, previousState, nextState)
        {
        }

        public override bool TryTransit()
        {
            if (CurrentState.IsValid == true)
            {
                GoNextState();
                return true;
            }

            return false;
        }
    }
}
