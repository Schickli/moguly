using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.Utility
{
    public class UtilitySquare : OwnableSquare
    {
        private UtilitySquare(string name, GameBoard board, int price) : base(name, board, price)
        {
        }

        public static UtilitySquare Create(string name, GameBoard board, int price)
        {
            return new UtilitySquare(name, board, price);
        }

        public override void LandOnSquare()
        {
            // hduiabiuda
        }
    }
}
