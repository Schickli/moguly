using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.GameState
{
    public class GameInProgress : GameState
    {
        public override void EndGame(GameBoard board)
        {
            board.State = new GameFinished();
        }
    }
}
