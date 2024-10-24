using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.States
{
    internal class WaitingChooseBeginningActionState : ValidateState
    {
        public WaitingChooseBeginningActionState(IInputDataBag bag) : base(bag)
        {
        }

        public override void ExecuteInput()
        {
            Console.WriteLine("Press 1 to create order\n" +
                              "Press 2 to filter orders");

            string input = Console.ReadLine();

            if (Validate(input) == true)
            {
                Bag.SetLastInput(input);
                SetIsValid();
            }
            else
            {
                Console.WriteLine("Not correct input");

                SetInvalid();
            }
        }

        private bool Validate(string value) {
            return value == "1" | value == "2";
        }
    }
}
