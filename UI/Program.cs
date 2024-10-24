using UI.StateMachine;
using UI.StateMachine.TransitionMapGenerator;

public static class Program { 
    public static void Main(string[] args) {
        StateMachine UI = new StateMachine(new ReflectionTransitionMapGenerator());
        UI.Start();
    }
}