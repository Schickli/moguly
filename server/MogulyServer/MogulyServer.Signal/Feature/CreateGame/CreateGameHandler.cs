using MediatR;
using MogulyServer.Domain.Board;
using MogulyServer.Domain.Player;
using MogulyServer.Persistence.Board;
using MogulyServer.Persistence.Context;

namespace MogulyServer.Signal.Feature.CreateGame
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        private readonly BoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGameHandler(BoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var creator = Player.Create(request.Rkey);

            var board = GameBoard.Create(creator);

            await _boardRepository.AddBoardAsync(board);
            await _unitOfWork.SaveChangesAsync();

            return board.Id;
        }
    }
}
