using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.GameState
{
    public abstract class GameState
    {
        public virtual void StartGame(GameBoard board)
        {
            throw new NotImplementedException($"This Operation is not valid for {board.State}");
        }

        public virtual void EndGame(GameBoard board)
        {
            throw new NotImplementedException($"This Operation is not valid for {board.State}");
        }
    }
}
