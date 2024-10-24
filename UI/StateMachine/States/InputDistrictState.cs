using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.Payloads;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.States
{
    internal class InputDistrictState : ValidateState
    {
        public InputDistrictState(IInputDataBag bag) : base(bag)
        {
        }

        public override async Task ExecuteInput()
        {
            Console.WriteLine("Input District:");

            string input = Console.ReadLine();

            if (Validate(input) == false)
            {
                SetInvalid();
            }
            else
            {
                Bag.SetPayload(new DistrictPayload(input));
                SetIsValid();
            }
        }

        private bool Validate(string input) {
            if (input == "")
            {
                Console.WriteLine("Can't be empty.");
                return false;
            }

            return true;
        }
    }
}
