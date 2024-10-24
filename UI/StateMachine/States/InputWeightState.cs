using UI.StateMachine.Payloads;
using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.States
{
    internal class InputWeightState : ValidateState
    {
        public InputWeightState(IInputDataBag bag) : base(bag)
        {
        }

        public override async Task ExecuteInput()
        {
            Console.WriteLine("Please enter the weight:");

            string input = Console.ReadLine();
            int weight;

            if (Validate(input, out weight) == false)
            {
                SetInvalid();
            }
            else
            {
                Bag.SetPayload(new WeightPayload(weight));
                SetIsValid();
            }
        }

        private bool Validate(string input, out int weight) {
            if (int.TryParse(input, out weight))
            {
                if (weight < 0)
                {
                    Console.WriteLine("Can't be negative.");

                    return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Must be a number.");

                return false;
            }
        }
    }
}
