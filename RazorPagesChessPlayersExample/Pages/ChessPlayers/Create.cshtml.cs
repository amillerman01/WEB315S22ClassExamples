using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesChessPlayersExample.Models;

namespace RazorPagesChessPlayersExample.Pages_ChessPlayers
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesChessPlayersExampleContext _context;

        public CreateModel(RazorPagesChessPlayersExampleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChessPlayer ChessPlayer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ChessPlayer.Add(ChessPlayer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
