using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.Railroad
{
    public class RailRoadSquare : OwnableSquare
    {
        private RailRoadSquare(string name, GameBoard board, int price) : base(name, board, price)
        {
        }

        public static RailRoadSquare Create(string name, GameBoard board, int price)
        {
            return new RailRoadSquare(name, board, price);
        }
    }
}
