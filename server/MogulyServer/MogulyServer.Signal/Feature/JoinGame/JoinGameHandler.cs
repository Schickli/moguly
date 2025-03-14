using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Persistence.Context;
using MogulyServer.Signal.Feature.RollDice;
using MogulyServer.Signal.Hub.Moguly;

namespace MogulyServer.Signal.Feature.JoinGame
{
    public class JoinGameHandler : IRequestHandler<JoinGameCommand>
    {

        private readonly IHubContext<MogulyHub, IMogulyClient> _hubContext;

        public JoinGameHandler(IHubContext<MogulyHub, IMogulyClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(JoinGameCommand request, CancellationToken cancellationToken)
        {
            // TODO: DB stuff
            return Task.CompletedTask;
        }
    }
}
