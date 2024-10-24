using UI.StateMachine.Payloads.InputData;

namespace UI.StateMachine.States.ValidateStates
{
    internal abstract class ValidateState : BaseState, IValidatableState
    {
        protected ValidateState(IInputDataBag bag) : base(bag)
        {
        }

        public bool ValidationIsValid { get; private set; }

        protected void SetIsValid() { 
            ValidationIsValid = true;
        }

        protected void SetInvalid() { 
            ValidationIsValid = false;
        }
    }
}
