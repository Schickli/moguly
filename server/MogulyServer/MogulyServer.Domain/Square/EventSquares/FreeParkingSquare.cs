using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.EventSquares
{
    public class FreeParkingSquare : EventSquare
    {
        private FreeParkingSquare(string name, GameBoard board) : base(name, board)
        {
        }

        public static FreeParkingSquare Create(GameBoard board)
        {
            return new FreeParkingSquare("Free parking", board);
        }
    }
}
