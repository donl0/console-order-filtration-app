using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.Payloads;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.States
{
    internal class InputOrderDateState : ValidateState
    {
        public InputOrderDateState(IInputDataBag bag) : base(bag)
        {
        }

        public override async Task ExecuteInput()
        {
            Console.WriteLine("Input Order date in yyyy-MM-dd HH:mm:ss format:");

            string input = Console.ReadLine();

            if (Validate(input, out DateTime date) == false)
            {
                SetInvalid();
            }
            else
            {
                Bag.SetPayload(new TimeDeliveryPayload(date));
                SetIsValid();
            }
        }

        private bool Validate(string input, out DateTime date)
        {
            if (DateTime.TryParse(input, out date) == false)
            {
                Console.WriteLine("Mast be a datetime.");
                return false;
            }

            return true;
        }
    }
}
