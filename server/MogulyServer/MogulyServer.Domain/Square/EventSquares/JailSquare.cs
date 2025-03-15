using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.EventSquares
{
    public class JailSquare : EventSquare
    {
        private JailSquare(string name, GameBoard board) : base(name, board)
        {
        }

        private JailSquare() 
            : base()
        {

        }

        public static JailSquare Create(GameBoard board)
        {
            return new JailSquare("Jail", board);
        }
    }
}
