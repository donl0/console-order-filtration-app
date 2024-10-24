using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;
using UI.StateMachine.Transitions;

namespace UI.StateMachine
{
    internal sealed class StateMachine
    {
        private readonly IInputDataBag _bag;

        private BaseState _currentState;

        private Dictionary<BaseState, List<IBaseTransition>> _transitionsMap = new Dictionary<BaseState, List<IBaseTransition>>();

        public StateMachine(IInputDataBag bag)
        {
            _bag = bag;

            Init();
        }

        private void Init()
        {
            BaseState startState = new WaitingChooseBeginningActionState(_bag);

            _currentState = startState;

            BaseState inputOrderNumberState = new InputOrderNumberState(_bag);

            IBaseTransition positiveStartTransitionFirstInput = new PositiveValidationTransition(new EqualLastInputTransition<string>(null, startState, _bag, "1"), inputOrderNumberState, (IValidatableState)startState);
            IBaseTransition negativeStartTransition = new NegativeValidationTransition(null, (IValidatableState)startState);


            IBaseTransition positiveInputOrderNumberTransition = new PositiveValidationTransition(null, startState, (IValidatableState)inputOrderNumberState);
            IBaseTransition negativeInputOrderNumberTransition = new NegativeValidationTransition(null, (IValidatableState)inputOrderNumberState);

            _transitionsMap[startState] = new List<IBaseTransition>() { positiveStartTransitionFirstInput, negativeStartTransition };
            _transitionsMap[inputOrderNumberState] = new List<IBaseTransition>() { positiveInputOrderNumberTransition, negativeInputOrderNumberTransition };
        }

        public void Start()
        {
            while (true)
            {
                _currentState.ExecuteInput();

                if (_transitionsMap[_currentState].Count > 0)
                {
                    foreach (var transition in _transitionsMap[_currentState])
                    {
                        if (transition.CheckIsNeedTransit())
                        {
                            _currentState = transition.GetStateToSwitch();
                            break;
                        }
                    }
                }
            }
        }
    }
}
