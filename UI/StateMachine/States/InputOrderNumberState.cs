using UI.StateMachine.Payloads;
using UI.StateMachine.Payloads.InputData;
using UI.StateMachine.States.ValidateStates;

namespace UI.StateMachine.States
{
    internal class InputOrderNumberState : ValidateState
    {
        public InputOrderNumberState(IInputDataBag bag) : base(bag)
        {
        }

        public override async Task ExecuteInput()
        {
            Console.WriteLine("Please enter a GUID:");

            string input = Console.ReadLine();

            if (Guid.TryParse(input, out Guid guid))
            {
                Bag.SetPayload(new UniqueNumberPayload(guid));
                SetIsValid();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid GUID.");
                SetInvalid();
            }
        }
    }
}
