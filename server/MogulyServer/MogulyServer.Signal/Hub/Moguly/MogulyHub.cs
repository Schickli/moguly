using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Signal.Feature.JoinGame;
using Newtonsoft.Json.Linq;

namespace MogulyServer.Signal.Hub.Moguly
{
    public class MogulyHub : Hub<IMogulyClient>
    {
        private readonly IMediator _mediator;
        private readonly CommandTypeResolver _commandTypeResolver;

        public MogulyHub(IMediator mediator, CommandTypeResolver commandTypeResolver)
        {
            _mediator = mediator;
            _commandTypeResolver = commandTypeResolver;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}", "has joined");
        }

        public async Task SendToAll(string message)
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}", $"{message}");
        }

        public async Task HandleCommand(string commandType, JObject payload)
        {
            var type = _commandTypeResolver.GetCommandType(commandType);
            if (type == null)
            {
                throw new InvalidOperationException($"Unknown command type: {commandType}");
            }

            var command = payload.ToObject(type);
            if (!type.IsInstanceOfType(command))
            {
                throw new InvalidOperationException($"Invalid command type: {commandType} does not match {command.GetType().Name}");
            }

            await _mediator.Send(command);
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
