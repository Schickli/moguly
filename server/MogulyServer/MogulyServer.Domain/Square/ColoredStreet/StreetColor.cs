using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square.ColoredStreets
{
    public record StreetColor
    {
        public static readonly StreetColor Brown = new("Brown");
        public static readonly StreetColor LightBlue = new("LightBlue");
        public static readonly StreetColor Pink = new("Pink");
        public static readonly StreetColor Orange = new("Orange");
        public static readonly StreetColor Red = new("Red");
        public static readonly StreetColor Yellow = new("Yellow");
        public static readonly StreetColor Green = new("Green");
        public static readonly StreetColor DarkBlue = new("DarkBlue");

        private readonly string _color;
        private StreetColor(string color)
        {
            _color = color;
        }
    }
}
