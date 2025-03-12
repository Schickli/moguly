using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.ColoredStreets
{
    class ColoredStreetSquare : Square
    {
        public string Name { get; init; }
        public StreetColor Color { get; init; }
        public string Owner { get; private set; }
        public int Price { get; init; }
        public int RentCost { get; private set; }
        public int Houses { get; private set; }
        public bool HasHotel { get; private set; }
        public bool IsMortaged { get; private set; }
        
        private ColoredStreetSquare(string name, StreetColor color, int price, int rent)
        {
            Name = name;
            Color = color;
            Owner = "Bank"; // By default bank owns all properties and houses
            Price = price;
            Houses = 0;
            HasHotel = false;
            IsMortaged = false;
        }

        public static ColoredStreetSquare? Create(string name, StreetColor color, int price, int rent)
        {
            if (price <= 0) return null;
            if (string.IsNullOrEmpty(name)) return null;

            return new ColoredStreetSquare(name, color, price, rent);
        }
    }
}
