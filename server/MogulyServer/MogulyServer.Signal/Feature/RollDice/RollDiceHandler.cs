using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Signal.Hub.Moguly;

namespace MogulyServer.Signal.Feature.RollDice
{
    public class RollDiceHandler : IRequestHandler<RollDiceCommand>
    {

        private readonly IHubContext<MogulyHub> _hubContext;

        public RollDiceHandler(IHubContext<MogulyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(RollDiceCommand request, CancellationToken cancellationToken)
        {
            await _hubContext.Groups.AddToGroupAsync(request.PlayerConnectionId, request.GameId.ToString(), cancellationToken);
        }
    }
}
