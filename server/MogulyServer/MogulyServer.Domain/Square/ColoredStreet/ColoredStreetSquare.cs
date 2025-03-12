using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.ColoredStreets
{
    class ColoredStreetSquare : OwnableSquare
    {
        public StreetColor Color { get; init; }
        public int RentCost { get; private set; }
        public int Houses { get; private set; }
        public bool HasHotel { get; private set; }
        public bool IsMortaged { get; private set; }
        
        private ColoredStreetSquare(string name, GameBoard board, int price, StreetColor color, int baseRentCost)
            : base(name, board, price)
        {
            Color = color;
            Houses = 0;
            HasHotel = false;
            IsMortaged = false;
            RentCost = baseRentCost;
        }

        public static ColoredStreetSquare Create(string name, GameBoard board, int price, StreetColor color, int rent)
        {
            return new ColoredStreetSquare(name, board, price, color, rent);
        }
    }
}
