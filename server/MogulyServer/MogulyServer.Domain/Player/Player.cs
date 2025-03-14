using MogulyServer.Domain.Board;
using MogulyServer.Domain.Square;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Player
{
    public class Player
    {
        public Guid Id { get; private set; }    

        public Guid Rkey { get; private set; }

        public List<OwnableSquare> Ownables { get; private set; }

        private Player(Guid rkey)
        {
            Id = Guid.NewGuid();
            Rkey = rkey;
            Ownables = new List<OwnableSquare>();
        }

        public static Player Create(Guid rkey)
        {
            return new Player(rkey);
        }
    }
}
