using MediatR;

namespace MogulyServer.Signal.Feature.JoinGame
{
    public record JoinGameCommand(Guid GameId, Guid Rkey) : IRequest;
}
