using Microsoft.EntityFrameworkCore;
using MogulyServer.Domain.Board;
using MogulyServer.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Persistence.Board
{
    public class BoardRepository
    {
        private readonly MogulyContext _context;

        public BoardRepository(MogulyContext context)
        {
            _context = context;
        }

        public async Task<IList<GameBoard>> GetBoardsAsync()
        {
            return await _context.Boards
                .Include(board => board.Players)
                .Include(board => board.Squares)
                .ToListAsync();
        }

        public async Task<GameBoard> GetBoardByIdAsync(Guid id)
        {
            return await _context.Boards
                .Include(board => board.Players)
                .Include(board => board.Squares)
                .FirstAsync(board => board.Id == id);
        }

        public async Task AddBoardAsync(GameBoard board)
        {
            await _context.Boards.AddAsync(board);
        }
    }
}
