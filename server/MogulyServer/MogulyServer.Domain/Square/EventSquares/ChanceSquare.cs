using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.EventSquares
{
    public class ChanceSquare : EventSquare
    {
        private ChanceSquare(string name, GameBoard board) : base(name, board)
        {
        }

        public static ChanceSquare Create(string name, GameBoard board)
        {
            return new ChanceSquare(name, board);
        }
    }
}
