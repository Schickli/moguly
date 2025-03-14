using MediatR;
using Microsoft.AspNetCore.SignalR;
using MogulyServer.Domain.Player;
using MogulyServer.Persistence.Board;
using MogulyServer.Persistence.Context;
using MogulyServer.Signal.Feature.RollDice;
using MogulyServer.Signal.Hub.Moguly;

namespace MogulyServer.Signal.Feature.JoinGame
{
    public class JoinGameHandler : IRequestHandler<JoinGameCommand>
    {
        private readonly BoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public JoinGameHandler(IUnitOfWork unitOfWork, BoardRepository boardRepository)
        {
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
        }

        public async Task Handle(JoinGameCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetBoardByIdAsync(request.GameId);

            var player = Player.Create(request.Rkey);

            board.AddPlayer(player);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
