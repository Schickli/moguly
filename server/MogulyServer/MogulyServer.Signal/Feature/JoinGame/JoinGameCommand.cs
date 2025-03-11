using MediatR;

namespace MogulyServer.Signal.Feature.JoinGame
{
    public record JoinGameCommand : IRequest
    {
        public Guid GameId { get; set; }
        public string PlayerConnectionId { get; set; }
    }
}
