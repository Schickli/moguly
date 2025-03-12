using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.EventSquares
{
    public class GoSquare : EventSquare
    {
        private GoSquare(string name, GameBoard board) : base(name, board)
        {
        }

        public static GoSquare Create(GameBoard board)
        {
            return new GoSquare("Go", board);
        }
    }
}
