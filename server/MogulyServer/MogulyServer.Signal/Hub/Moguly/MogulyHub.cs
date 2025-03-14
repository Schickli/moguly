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


        // Most likely useless (Connect(), Disconnect()), since we always have the rkey in header
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userSessionId = Guid.Parse(Context.GetHttpContext()!.Request.Headers["rkey"]!);


            if (userConnectionMappings.ContainsKey(userSessionId))
            {
                userConnectionMappings[userSessionId].Add(Context.ConnectionId);
            }
            else
            {
                userConnectionMappings.Add(userSessionId, [Context.ConnectionId]);
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            var userSessionId = Guid.Parse(Context.GetHttpContext()!.Request.Headers["rkey"]!);

            userConnectionMappings[userSessionId].Remove(Context.ConnectionId);

            if (!userConnectionMappings[userSessionId].Any())
            {
                userConnectionMappings.Remove(userSessionId);
            }

            return base.OnDisconnectedAsync(exception);
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
        }

        public async Task JoinGame(Guid gameId)
        {
            var userSessionId = Context.GetHttpContext()!.Request.Headers["rkey"];

            var joinGameCommand = new JoinGameCommand(gameId, Guid.Parse(userSessionId!));

            await _mediator.Send(joinGameCommand);

            await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
        }
    }
}
