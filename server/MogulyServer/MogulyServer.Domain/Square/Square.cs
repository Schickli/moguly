using MogulyServer.Domain.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Square
{
    public abstract class Square
    {
        public Guid Id { get; private set; }
        public string Name { get; init; }
        public GameBoard Board { get; set; }

        protected Square()
        {

        }

        protected Square(string name, GameBoard board)
        {
            Id = Guid.NewGuid();
            Name = name;
            Board = board;
        }
    }
}
