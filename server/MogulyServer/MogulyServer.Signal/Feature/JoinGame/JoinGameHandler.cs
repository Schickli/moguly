using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Signal.Feature.Moguly;

namespace MogulyServer.Signal.Feature.JoinGame
{
    public class JoinGameHandler : IRequestHandler<JoinGameCommand>
    {

        private readonly IHubContext<MogulyHub> _hubContext;

        public JoinGameHandler(IHubContext<MogulyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(JoinGameCommand request, CancellationToken cancellationToken)
        {
            await _hubContext.Groups.AddToGroupAsync(request.PlayerConnectionId, request.GameId.ToString(), cancellationToken);
        }
    }
}
