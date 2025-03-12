using MediatR;
using MogulyServer.Signal.Feature.JoinGame;

namespace MogulyServer.Signal.Feature.RollDice
{
    public record RollDiceCommand : IGameCommand
    {
        public Guid GameId { get; set; }
        public string PlayerConnectionId { get; set; }
    }
}
