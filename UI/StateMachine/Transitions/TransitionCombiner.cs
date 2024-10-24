using UI.StateMachine.Exceptions;
using UI.StateMachine.States;

namespace UI.StateMachine.Transitions
{
    internal class TransitionCombiner : BaseTransition
    {
        private readonly IReadOnlyCollection<BaseTransition> _transitions = new List<BaseTransition>();

        public TransitionCombiner(List<BaseTransition> transitions)
        {
            _transitions = transitions;

            Validate(transitions);
        }

        public override bool IsNeedTransit()
        {
            foreach (var transition in _transitions)
            {
                if (transition.IsNeedTransit() == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void Validate(IReadOnlyCollection<BaseTransition> transitions) {
            if (transitions.Count == 0)
            {
                throw new ArgumentNullException();
            }

            CheckOnSameGoal(transitions);
        }

        private void CheckOnSameGoal(IReadOnlyCollection<BaseTransition> transitions) {
            BaseState goal = transitions.First().StateToSwitch;

            foreach (var transition in transitions)
            {
                if (transition.StateToSwitch != goal)
                {
                    throw new TransitionsHasDifferentStatesException();
                }
            }
        }
    }
}
