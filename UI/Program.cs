using ApiClient;
using UI.StateMachine;
using UI.StateMachine.Payloads.InputData;

public static class Program { 
    public static async  Task Main(string[] args) {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

        StateMachine UI = new StateMachine(new InputDataBag(), new OrderExcecutorApiClient(new HttpClient(handler), "https://localhost:7065"));
        await UI.Start();
    }
}