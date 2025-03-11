using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Signal.Feature.JoinGame;

namespace MogulyServer.Signal.Feature.Moguly
{
    public class MogulyHub : Hub<IMogulyClient>
    {
        private readonly IMediator _mediator;

        public MogulyHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}", "has joined");
        }

        public async Task SendToAll(string message)
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}", $"{message}");
        }

        public async Task JoinGame(Guid gameId)
        {
            var playerConnectionId = Context.ConnectionId; // CLARIFY: maybe use userIdentifier????

            var cmd = new JoinGameCommand()
            {
                GameId = gameId,
                PlayerConnectionId = playerConnectionId
            };

            await _mediator.Send(cmd);
        }

        public async Task PingPlayers(Guid gameId)
        {
            await Clients.Group(gameId.ToString()).ReceiveMessage("TEST", $"Your are in grou {gameId}");
        }
    }
}
