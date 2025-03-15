using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MogulyServer.Domain.Board;
using MogulyServer.Domain.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using BoardGameState = MogulyServer.Domain.GameState.GameState;

namespace MogulyServer.Persistence.Board.GameState
{
    public class GameStateConverter : ValueConverter<BoardGameState, string>
    {
        public GameStateConverter()
            : base(
            state => state.GetType().Name,
            state => GetGameState(state)
        )
        {
        }

        private static BoardGameState GetGameState(string state)
        {
            return state switch
            {
                nameof(GameFinished) => new GameFinished(),
                nameof(GameInProgress) => new GameInProgress(),
                nameof(GameInLobby) => new GameInLobby(),
                _ => throw new InvalidOperationException("Unknown state")
            };
        }
    }
}
