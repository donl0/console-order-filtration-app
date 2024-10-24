using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.Transitions
{
    internal class NegativeValidationTransition : BaseTransition
    {
        private readonly IValidatableState _state;

        public NegativeValidationTransition(BaseTransition nextTransition, IValidatableState state) : base(nextTransition)
        {
            _state = state;
        }

        public override BaseState GetStateToSwitch()
        {
            return (BaseState)_state;
        }

        protected override bool CheckIsNeedInternalTransition()
        {
            return _state.ValidationIsValid == false;
        }
    }
}
