using UI.StateMachine.States;
using UI.StateMachine.StateSwitcher;
using UI.StateMachine.Transitions;

namespace UI.StateMachine.TransitionMapGenerator
{
    internal interface ITransitionMapGenerator
    {
        public Dictionary<ITransitionableBaseState, List<IBaseTransition>> Generate(List<ITransitionableBaseState> states, List<IBaseTransition> transitionsContainer, IStateSwitcher stateSwitcher);
    }
}
