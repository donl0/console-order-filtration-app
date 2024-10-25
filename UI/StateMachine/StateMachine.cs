﻿using ApiClient;
using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States;
using UI.StateMachine.States.ValidateStates;
using UI.StateMachine.Transitions;
using UI.Utils;

namespace UI.StateMachine
{
    internal sealed class StateMachine
    {
        private readonly IInputDataBag _bag;
        private readonly IOrderExcecutorApiClient _apiClient;
        private readonly IOrderPrinter _orderPrinter;
        private BaseState _currentState;

        private Dictionary<BaseState, List<IBaseTransition>> _transitionsMap = new Dictionary<BaseState, List<IBaseTransition>>();

        public StateMachine(IInputDataBag bag, IOrderExcecutorApiClient apiClient, IOrderPrinter orderPrinter)
        {
            _bag = bag;
            _apiClient = apiClient;
            _orderPrinter = orderPrinter;

            Init();
        }

        private void Init()
        {
            BaseState startState = new WaitingChooseBeginningActionState(_bag);

            _currentState = startState;

            BaseState inputOrderNumberState = new InputOrderNumberState(_bag);

            BaseState inputWeightForCreateOrder = new InputWeightState(_bag);

            BaseState inputDistrictForCreateOrder = new InputDistrictState(_bag);

            BaseState inputDateForCreateOrder = new InputOrderDateState(_bag);

            BaseState createOrderState = new CreateOrderState(_bag, _apiClient);

            IBaseTransition positiveStartTransitionFirstInput = new PositiveValidationTransition(new EqualLastInputTransition<string>(null, startState, _bag, "1"), inputOrderNumberState, (IValidatableState)startState);
            IBaseTransition negativeStartTransition = new NegativeValidationTransition(null, (IValidatableState)startState);

            IBaseTransition positiveInputOrderNumberTransition = new PositiveValidationTransition(null, inputWeightForCreateOrder, (IValidatableState)inputOrderNumberState);
            IBaseTransition negativeInputOrderNumberTransition = new NegativeValidationTransition(null, (IValidatableState)inputOrderNumberState);

            IBaseTransition positiveInputWeightForCreateOrder = new PositiveValidationTransition(null, inputDistrictForCreateOrder, (IValidatableState)inputWeightForCreateOrder);
            IBaseTransition negativeInputWeightForCreateOrder = new NegativeValidationTransition(null, (IValidatableState)inputWeightForCreateOrder);

            IBaseTransition positiveDistrictForCreateOrder = new PositiveValidationTransition(null, inputDateForCreateOrder, (IValidatableState)inputDistrictForCreateOrder);
            IBaseTransition negativeDistrictForCreateOrder = new NegativeValidationTransition(null, (IValidatableState)inputDistrictForCreateOrder);

            IBaseTransition positiveDateForCreateOrder = new PositiveValidationTransition(null, createOrderState, (IValidatableState)inputDateForCreateOrder);
            IBaseTransition negativeDateForCreateOrder = new NegativeValidationTransition(null, (IValidatableState)inputDateForCreateOrder);

            IBaseTransition onOrderEnd = new OnEndTransition(startState);

            BaseState inputDistrictForFilter = new InputDistrictState(_bag);

            BaseState inputDateForFilter = new InputOrderDateState(_bag);

            BaseState filterOrders = new FilterOrdersState(_bag, _apiClient, _orderPrinter);

            IBaseTransition positiveStartTransitionForFilter = new PositiveValidationTransition(new EqualLastInputTransition<string>(null, startState, _bag, "2"), inputDistrictForFilter, (IValidatableState)startState);

            IBaseTransition positiveFromDistrictToDateForFilter = new PositiveValidationTransition(null, inputDateForFilter, (IValidatableState)inputDistrictForFilter);
            IBaseTransition negativeinputDistrictForFilter = new NegativeValidationTransition(null, (IValidatableState)inputDistrictForFilter);

            IBaseTransition positiveFromDateToFilter = new PositiveValidationTransition(null, filterOrders, (IValidatableState)inputDateForFilter);
            IBaseTransition negativeDistrictForFilter = new NegativeValidationTransition(null, (IValidatableState)inputDateForFilter);

            IBaseTransition onFilterEnd = new OnEndTransition(startState);


            _transitionsMap[startState] = new List<IBaseTransition>() { positiveStartTransitionFirstInput, negativeStartTransition, positiveStartTransitionForFilter };
            _transitionsMap[inputOrderNumberState] = new List<IBaseTransition>() { positiveInputOrderNumberTransition, negativeInputOrderNumberTransition };
            _transitionsMap[inputWeightForCreateOrder] = new List<IBaseTransition>() { positiveInputWeightForCreateOrder, negativeInputWeightForCreateOrder };
            _transitionsMap[inputDistrictForCreateOrder] = new List<IBaseTransition>() { positiveDistrictForCreateOrder, negativeDistrictForCreateOrder };
            _transitionsMap[inputDateForCreateOrder] = new List<IBaseTransition>() { positiveDateForCreateOrder, negativeDateForCreateOrder };

            _transitionsMap[createOrderState] = new List<IBaseTransition>() { onOrderEnd };

            _transitionsMap[inputDistrictForFilter] = new List<IBaseTransition>() { positiveFromDistrictToDateForFilter, negativeinputDistrictForFilter };
            _transitionsMap[inputDateForFilter] = new List<IBaseTransition>() { positiveFromDateToFilter, negativeDistrictForFilter };

            _transitionsMap[filterOrders] = new List<IBaseTransition>() { onFilterEnd };
        }

        public async Task Start()
        {
            while (true)
            {
                await _currentState.ExecuteInput();

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
