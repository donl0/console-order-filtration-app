using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.Transitions
{
    internal class NegativeValidationTransition : BaseTransition
    {
        private readonly IValidatableState _stateToTransit;

        public NegativeValidationTransition(BaseTransition nextTransition, IValidatableState stateToTransit) : base(nextTransition)
        {
            _stateToTransit = stateToTransit;
        }

        public override BaseState GetStateToSwitch()
        {
            return (BaseState)_stateToTransit;
        }

        protected override bool CheckIsNeedInternalTransition()
        {
            return _stateToTransit.ValidationIsValid == false;
        }
    }
}
