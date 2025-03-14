using MogulyServer.Domain.Square.ColoredStreets;
using MogulyServer.Domain.Square.EventSquares;
using MogulyServer.Domain.Square.Railroad;
using MogulyServer.Domain.Square;
using MogulyServer.Domain.Square.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GamePlayer = MogulyServer.Domain.Player.Player;
using System.Security.Cryptography.X509Certificates;

namespace MogulyServer.Domain.Board
{
    public class GameBoard
    {
        public Guid Id { get; private set; }

        private IList<GamePlayer> _players;

        private readonly Square.Square[] _squares;

        private const int _boardSize = 40;

        private GameBoard() // used by ef
        {

        }
        private GameBoard(GamePlayer creator)
        {
            Id = Guid.NewGuid();

            _players = new List<GamePlayer>()
            {
                creator
            };

            _squares = new Square.Square[_boardSize]
            {
                GoSquare.Create(this),
                ColoredStreetSquare.Create("Mediterranean Avenue", this, 60, StreetColor.Brown, 60),
                ChanceSquare.Create("Community Chest", this),
                ColoredStreetSquare.Create("Baltic Avenue", this, 60, StreetColor.Brown, 60),
                TaxSquare.Create("Income Tax", this),
                RailRoadSquare.Create("Reading Railroad", this, 200),
                ColoredStreetSquare.Create("Oriental Avenue", this, 100, StreetColor.LightBlue, 100),
                ChanceSquare.Create("Chance", this),
                ColoredStreetSquare.Create("Vermont Avenue", this, 100, StreetColor.LightBlue, 100),
                ColoredStreetSquare.Create("Connecticut Avenue", this, 120, StreetColor.LightBlue, 120),

                JailSquare.Create(this),
                ColoredStreetSquare.Create("St. Charles Place", this, 100, StreetColor.Pink, 140),
                UtilitySquare.Create("Electric Company", this, 150),
                ColoredStreetSquare.Create("States Avenue", this, 140, StreetColor.Pink, 140),
                ColoredStreetSquare.Create("Virginia Avenue", this, 160, StreetColor.Pink, 160),
                RailRoadSquare.Create("Pennsylvania Railroad", this, 200),
                ColoredStreetSquare.Create("St. James Place", this, 180, StreetColor.Orange, 180),
                ChanceSquare.Create("Community Chest", this),
                ColoredStreetSquare.Create("Tennessee Avenue", this, 180, StreetColor.Orange, 180),
                ColoredStreetSquare.Create("New York Avenue", this, 180, StreetColor.Orange, 200),

                FreeParkingSquare.Create(this),
                ColoredStreetSquare.Create("Kentucky Avenue", this, 220, StreetColor.Red, 220),
                ChanceSquare.Create("Chance", this),
                ColoredStreetSquare.Create("Indiana Avenue", this, 220, StreetColor.Red, 220),
                ColoredStreetSquare.Create("Illinois Avenue", this, 240, StreetColor.Red, 240),
                RailRoadSquare.Create("B&O Railroad", this, 200),
                ColoredStreetSquare.Create("Atlantic Avenue", this, 260, StreetColor.Yellow, 260),
                ColoredStreetSquare.Create("Ventnor Avenue", this, 260, StreetColor.Yellow, 260),
                UtilitySquare.Create("Water Works", this, 150),
                ColoredStreetSquare.Create("Marvin Gardens", this, 280, StreetColor.Yellow, 280),

                GoToJailSquare.Create(this),
                ColoredStreetSquare.Create("Pacific Avenue", this, 300, StreetColor.Green, 300),
                ColoredStreetSquare.Create("North Carolina Avenue", this, 300, StreetColor.Green, 300),
                ChanceSquare.Create("Community Chest", this),
                ColoredStreetSquare.Create("Pennsylvania Avenue", this, 320, StreetColor.Green, 320),
                RailRoadSquare.Create("Short Line Railroad", this, 200),
                ChanceSquare.Create("Chance", this),
                ColoredStreetSquare.Create("Park Place", this, 350, StreetColor.DarkBlue, 350),
                TaxSquare.Create("Luxury Tax", this),
                ColoredStreetSquare.Create("Boardwalk", this, 400, StreetColor.DarkBlue, 400)
            };
        }

        public static GameBoard Create(GamePlayer creator)
        {
            return new GameBoard(creator);
        }
    }
}
