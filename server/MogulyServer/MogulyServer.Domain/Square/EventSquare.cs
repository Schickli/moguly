using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square
{
    public abstract class EventSquare : Square
    {
        protected EventSquare(string name, GameBoard board) : base(name, board)
        {
        }
    }
}
