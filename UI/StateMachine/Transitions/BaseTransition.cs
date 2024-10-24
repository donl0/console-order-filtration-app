using UI.StateMachine.States;

namespace UI.StateMachine.Transitions
{
    internal abstract class BaseTransition: IBaseTransition
    {
        private readonly BaseTransition _nextTransition;

        public BaseTransition(BaseTransition nextTransition = null)
        {
            _nextTransition = nextTransition;
        }

        public bool CheckIsNeedTransit() {
            bool internalResult = CheckIsNeedInternalTransition() == true;

            if (_nextTransition == null)
            {
                return internalResult;
            }

            return internalResult & _nextTransition.CheckIsNeedTransit();
        }

        public abstract BaseState GetStateToSwitch();
        protected abstract bool CheckIsNeedInternalTransition();
    }
}