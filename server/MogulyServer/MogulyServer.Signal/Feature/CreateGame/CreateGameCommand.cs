using MediatR;

namespace MogulyServer.Signal.Feature.CreateGame
{
    public record CreateGameCommand(Guid Rkey) : IRequest<Guid>;

}
