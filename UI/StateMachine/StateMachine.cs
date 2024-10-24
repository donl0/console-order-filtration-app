using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;
using UI.StateMachine.StateSwitcher;
using UI.StateMachine.TransitionMapGenerator;
using UI.StateMachine.Transitions;

namespace UI.StateMachine
{
    internal sealed class StateMachine : IStateSwitcher
    {
        private readonly ITransitionMapGenerator _transitionMapGenerator;

        private BaseState _currentState;

        private List<ITransitionableBaseState> _states = new List<ITransitionableBaseState>();
        private List<IBaseTransition> _transitionsContainer = new List<IBaseTransition>();
        private Dictionary<ITransitionableBaseState, List<IBaseTransition>> _transitionsMap = new Dictionary<ITransitionableBaseState, List<IBaseTransition>>();

        public StateMachine(ITransitionMapGenerator transitionMapGenerator)
        {
            _transitionMapGenerator = transitionMapGenerator;

            Init();
        }

        public void Init() { 
            IInputDataBag bag = new InputDataBag();


            IValidatableState startState = new WaitingChooseBeginningActionState(bag);

            _currentState = (BaseState)startState;

            _states.Add(_currentState);

            IValidatableState inputOrderNumberState = new InputOrderNumberState(bag);
            _states.Add(inputOrderNumberState);

            IBaseTransition positiveStartTransition = new OnPositiveValidationTransition(this, startState, inputOrderNumberState);
            IBaseTransition onNegativeStartTransition = new RetryOnNegativeValidationTransition(this, startState, inputOrderNumberState);

            _transitionsContainer.Add(positiveStartTransition);
            _transitionsContainer.Add(onNegativeStartTransition);

            IBaseTransition positiveInputOrderNumberTransition = new OnPositiveValidationTransition(this, inputOrderNumberState, startState);
            IBaseTransition negativeInputOrderNumberTransition = new RetryOnNegativeValidationTransition(this, inputOrderNumberState, startState);

            _transitionsContainer.Add(positiveInputOrderNumberTransition);
            _transitionsContainer.Add(negativeInputOrderNumberTransition);

            _transitionsMap = _transitionMapGenerator.Generate(_states, _transitionsContainer,  this);
        }

        public void Start() {
            while (true)
            {
                _currentState.ExecuteInput();
                if (_transitionsMap.TryGetValue(_currentState, out var stateTransitions))
                {
                    foreach (var transition in stateTransitions)
                    {
                        if (transition.TryTransit())
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void SwithState(ITransitionableBaseState transitTo)
        {
            var value = _states.Find( s => s ==  transitTo);

            _currentState = (BaseState)value;

        }
    }
}
