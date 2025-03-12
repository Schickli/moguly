using MogulyServer.Signal.Feature;

namespace MogulyServer.Signal.Hub.Moguly
{
    public interface IMogulyClient
    {
        Task ReceiveMessage(string user, string message);
        Task AvailableCommands(string player, List<string> availableCommands);
    }
}
