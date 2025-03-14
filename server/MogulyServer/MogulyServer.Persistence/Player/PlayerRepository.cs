using Microsoft.EntityFrameworkCore;
using MogulyServer.Domain.Board;
using MogulyServer.Domain.Player;
using MogulyServer.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GamePlayer = MogulyServer.Domain.Player.Player;

namespace MogulyServer.Persistence.Player
{
    public class PlayerRepository
    {
        private readonly MogulyContext _context;

        public PlayerRepository(MogulyContext context)
        {
            _context = context;
        }

        public async Task<IList<GamePlayer>> GetPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<GamePlayer> GetPlayerByIdAsync(Guid id)
        {
            return await _context.Players
                .Include(player=> player.Board)
                .FirstAsync(board => board.Id == id);
        }

        public async Task<GamePlayer?> GetPlayerByRkeyAsync(Guid rkey)
        {
            return await _context.Players
                .Include(player => player.Board)
                .FirstOrDefaultAsync(player => player.Rkey == rkey);
        }

        public async Task AddPlayerAsync(GamePlayer player)
        {
            await _context.Players.AddAsync(player);
        }
    }
}
