using MediatR;
using MogulyServer.Domain.Board;
using MogulyServer.Domain.Player;

namespace MogulyServer.Signal.Feature.CreateGame
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        public Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var creator = Player.Create(request.Rkey);

            var board = GameBoard.Create(creator);

            return Task.FromResult(board.Id);
        }
    }
}
