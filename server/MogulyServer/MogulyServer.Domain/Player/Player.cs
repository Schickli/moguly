using MogulyServer.Domain.Board;
using MogulyServer.Domain.Square;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Domain.Player
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }    

        public Guid Rkey { get; private set; }

        public ICollection<OwnableSquare> Ownables { get; private set; }

        public GameBoard Board { get; set; }

        private Player(Guid rkey)
        {
            Rkey = rkey;
            Ownables = new List<OwnableSquare>();
        }

        public static Player Create(Guid rkey)
        {
            return new Player(rkey);
        }
    }
}
