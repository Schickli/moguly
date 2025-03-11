namespace MogulyServer.Signal.Feature.Moguly
{
    public interface IMogulyClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
