using UI.StateMachine.States;

namespace UI.StateMachine.Transitions
{
    internal interface IBaseTransition
    {
        public abstract BaseState GetStateToSwitch();

        public abstract bool CheckIsNeedTransit();
    }
}