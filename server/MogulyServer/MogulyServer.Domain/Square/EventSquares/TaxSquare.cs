using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.EventSquares
{
    public class TaxSquare : EventSquare
    {
        private TaxSquare(string name, GameBoard board) : base(name, board)
        {
        }

        public static TaxSquare Create(string name, GameBoard board)
        {
            return new TaxSquare(name, board);
        }
    }
}
