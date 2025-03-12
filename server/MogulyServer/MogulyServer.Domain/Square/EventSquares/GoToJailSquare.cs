using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.EventSquares
{
    public class GoToJailSquare : EventSquare
    {
        private GoToJailSquare(string name, GameBoard board) : base(name, board)
        {
        }

        public static GoToJailSquare Create(GameBoard board)
        {
            return new GoToJailSquare("Go to jail", board);
        }
    }
}
