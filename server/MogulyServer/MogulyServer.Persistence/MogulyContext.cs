using Microsoft.EntityFrameworkCore;
using MogulyServer.Domain.Board;
using MogulyServer.Domain.Player;
using MogulyServer.Domain.Square;
using MogulyServer.Domain.Square.ColoredStreets;
using MogulyServer.Domain.Square.EventSquares;
using MogulyServer.Domain.Square.Railroad;
using MogulyServer.Domain.Square.Utility;

namespace MogulyServer.Persistence
{
    public class MogulyContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<GameBoard> Boards { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<ColoredStreetSquare> ColoredStreetSquares { get; set; }
        public DbSet<ChanceSquare> ChanceSquares { get; set; }
        public DbSet<FreeParkingSquare> FreeParkingSquares { get; set; }
        public DbSet<GoSquare> GoSquares { get; set; }
        public DbSet<GoToJailSquare> GoToJailSquares { get; set; }
        public DbSet<JailSquare> JailSquares { get; set; }
        public DbSet<TaxSquare> TaxSquares { get; set; }
        public DbSet<RailRoadSquare> RailroadSquares { get; set; }
        public DbSet<UtilitySquare> UtilitySquares { get; set; }
        public DbSet<EventSquare> EventSquares { get; set; }
        public DbSet<OwnableSquare> OwnableSquares { get; set; }

        public MogulyContext(DbContextOptions<MogulyContext> options)
            : base(options)
        {
            
        }
    }
}
