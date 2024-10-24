using System.Reflection;
using UI.StateMachine.States;
using UI.StateMachine.StateSwitcher;
using UI.StateMachine.Transitions;

namespace UI.StateMachine.TransitionMapGenerator
{
    internal class ReflectionTransitionMapGenerator : ITransitionMapGenerator
    {
        public Dictionary<ITransitionableBaseState, List<IBaseTransition>> Generate(
            List<ITransitionableBaseState> states,
            List<IBaseTransition> transitionsContainer, IStateSwitcher stateSwitcher)
        {
            var transitionsMap = new Dictionary<ITransitionableBaseState, List<IBaseTransition>>();

            foreach (var transition in transitionsContainer)
            {
                var transitionType = transition.GetType();

                var currentStateField = transitionType.GetField("CurrentState", BindingFlags.Instance | BindingFlags.NonPublic);
                var nextStateField = transitionType.GetField("NextState", BindingFlags.Instance | BindingFlags.NonPublic);

                var currentState = currentStateField?.GetValue(transition) as ITransitionableBaseState;
                var nextState = nextStateField?.GetValue(transition) as ITransitionableBaseState;

                if (currentState != null && nextState != null)
                {
                    if (!transitionsMap.ContainsKey(currentState))
                    {
                        transitionsMap[currentState] = new List<IBaseTransition>();
                    }

                    transitionsMap[currentState].Add(transition);
                }
            }

            return transitionsMap;
        }
    }
}
