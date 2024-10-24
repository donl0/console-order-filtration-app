using UI.StateMachine;
using UI.StateMachine.Payloads.InputData;

public static class Program { 
    public static void Main(string[] args) {
        StateMachine UI = new StateMachine(new InputDataBag());
        UI.Start();
    }
}