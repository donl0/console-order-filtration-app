using UI.StateMachine.Transitions;

namespace UI.StateMachine.States
{
    internal class OnEndTransition : BaseTransition
    {
        public readonly BaseState _nextState;

        public OnEndTransition(BaseState nextState)
        {
            _nextState = nextState;
        }

        public override BaseState GetStateToSwitch()
        {
            return _nextState;
        }

        protected override bool CheckIsNeedInternalTransition()
        {
            return true;
        }
    }
}
