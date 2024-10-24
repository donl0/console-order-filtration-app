using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.Transitions
{
    internal class PositiveValidationTransition : BaseTransition
    {
        private readonly IValidatableState _currentState;

        private readonly BaseState _stateToSwitch;

        public PositiveValidationTransition(BaseTransition nextTransition, BaseState stateToSwitch, IValidatableState currentState) : base(nextTransition)
        {
            _stateToSwitch = stateToSwitch;
            _currentState = currentState;
        }

        public override BaseState GetStateToSwitch()
        {
            return _stateToSwitch;
        }

        protected override bool CheckIsNeedInternalTransition()
        {
            return _currentState.ValidationIsValid == true;
        }
    }
}
