using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesChessPlayersExample.Models;

namespace RazorPagesChessPlayersExample.Pages_ChessPlayers
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesChessPlayersExampleContext _context;

        public IndexModel(RazorPagesChessPlayersExampleContext context)
        {
            _context = context;
            // SomeValue = 10;
        }

        public IList<ChessPlayer> ChessPlayer { get; set; }
        public int SomeValue { get; set; } = 10;

        public async Task OnGetAsync()
        {
            ChessPlayer = await _context.ChessPlayer.ToListAsync();
            // SomeValue = 10;
        }
    }
}
