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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesChessPlayersExampleContext _context;

        public DeleteModel(RazorPagesChessPlayersExampleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChessPlayer ChessPlayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChessPlayer = await _context.ChessPlayer.FirstOrDefaultAsync(m => m.ID == id);

            if (ChessPlayer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChessPlayer = await _context.ChessPlayer.FindAsync(id);

            if (ChessPlayer != null)
            {
                _context.ChessPlayer.Remove(ChessPlayer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
