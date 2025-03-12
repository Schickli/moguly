using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square
{
    public abstract class OwnableSquare : Square
    {
        public string Owner { get; private set; }
        public int Price { get; init; }

        protected OwnableSquare(string name, GameBoard board, int price)
            : base(name, board)
        {
            Owner = "Bank";
            Price = price;
        }

        // TODO: How money is received to the player is still TBD
    }
}
