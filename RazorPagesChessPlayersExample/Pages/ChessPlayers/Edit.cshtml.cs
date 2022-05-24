using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesChessPlayersExample.Models;

namespace RazorPagesChessPlayersExample.Pages_ChessPlayers
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesChessPlayersExampleContext _context;

        public EditModel(RazorPagesChessPlayersExampleContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChessPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChessPlayerExists(ChessPlayer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChessPlayerExists(int id)
        {
            return _context.ChessPlayer.Any(e => e.ID == id);
        }
    }
}
