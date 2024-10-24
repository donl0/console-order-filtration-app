using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States;

namespace UI.StateMachine.Transitions
{
    internal class EqualLastInputTransition<T> : BaseTransition where T: IComparable
    {
        private readonly BaseState _state;
        private readonly IInputDataBag _bag;
        private readonly T _compareValue;

        public EqualLastInputTransition(BaseTransition nextTransition, BaseState state, IInputDataBag bag, T compareValue) : base(nextTransition)
        {
            _state = state;
            _bag = bag;
            _compareValue = compareValue;
        }

        public override BaseState GetStateToSwitch()
        {
            return _state;
        }

        protected override bool CheckIsNeedInternalTransition()
        {
            return _bag.LastInputData?.CompareTo(_compareValue) == 0;
        }
    }
}
