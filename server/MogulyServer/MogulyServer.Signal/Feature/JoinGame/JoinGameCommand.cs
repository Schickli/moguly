using MediatR;

namespace MogulyServer.Signal.Feature.JoinGame
{
    public record JoinGameCommand : IGameCommand
    {
        public Guid GameId { get; set; }
        public string PlayerConnectionId { get; set; }
    }
}
