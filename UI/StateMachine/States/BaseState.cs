using UI.StateMachine.Payloads.InputData;

namespace UI.StateMachine.States
{
    internal abstract class BaseState : ITransitionableBaseState
    {
        protected readonly IInputDataBag Bag;

        protected BaseState(IInputDataBag bag)
        {
            Bag = bag;
        }

        public abstract void ExecuteInput();
    }
}
