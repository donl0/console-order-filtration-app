using UI.StateMachine.Payloads.InputData;

namespace UI.StateMachine.States.ValidateStates
{
    internal abstract class ValidateState : BaseState, IValidatableState
    {
        protected ValidateState(IInputDataBag bag) : base(bag)
        {
        }

        public bool IsValid { get; private set; }

        protected void SetIsValid() { 
            IsValid = true;
        }

        protected void SetInvalid() { 
            IsValid = false;
        }
    }
}
