namespace MogulyServer.Signal.Hub.Moguly
{
    public interface IMogulyClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
