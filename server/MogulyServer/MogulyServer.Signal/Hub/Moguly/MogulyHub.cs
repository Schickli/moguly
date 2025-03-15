using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Signal.Feature.CreateGame;
using MogulyServer.Signal.Feature.JoinGame;
using Newtonsoft.Json.Linq;

namespace MogulyServer.Signal.Hub.Moguly
{
    public class MogulyHub : Hub<IMogulyClient>
    {
        private readonly IMediator _mediator;
        private readonly CommandTypeResolver _commandTypeResolver;

        private Dictionary<Guid, List<string>> userConnectionMappings = new Dictionary<Guid, List<string>>();

        public MogulyHub(IMediator mediator, CommandTypeResolver commandTypeResolver)
        {
            _mediator = mediator;
            _commandTypeResolver = commandTypeResolver;
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

        public async Task CreateGame()
        {
            var userSessionId = Context.GetHttpContext()!.Request.Headers["rkey"];
            var createGameCommand = new CreateGameCommand(Guid.Parse(userSessionId!));

            var gameId = await _mediator.Send(createGameCommand);

            await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());

            await Clients.Group(gameId.ToString()).ReceiveMessage(userSessionId!, "has created a new group");
        }

        public async Task JoinGame(Guid gameId)
        {
            var userSessionId = Context.GetHttpContext()!.Request.Headers["rkey"];

            var joinGameCommand = new JoinGameCommand(gameId, Guid.Parse(userSessionId!));

            await _mediator.Send(joinGameCommand);

            await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());

            await Clients.Group(gameId.ToString()).ReceiveMessage(userSessionId!, "new player joined");
        }
    }
}
