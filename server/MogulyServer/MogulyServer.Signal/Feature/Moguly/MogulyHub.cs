using Microsoft.AspNetCore.SignalR;

namespace MogulyServer.Signal.Feature.Moguly
{
    public class MogulyHub : Hub<IMogulyClient>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}", "has joined");
        }

        public async Task SendToAll(string message)
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}", $"{message}");
        }
    }
}
