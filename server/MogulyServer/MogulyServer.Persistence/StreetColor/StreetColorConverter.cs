using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MogulyServer.Domain.Square.ColoredStreets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using SquareStreetColor = MogulyServer.Domain.Square.ColoredStreets.StreetColor;

namespace MogulyServer.Persistence.StreetColor
{
    class StreetColorConverter : ValueConverter<SquareStreetColor, string>
    {
        public StreetColorConverter() : base(
                streetColor => streetColor.ToString(),
                color => SquareStreetColor.Parse(color)
            )
        {
        }
    }
}
