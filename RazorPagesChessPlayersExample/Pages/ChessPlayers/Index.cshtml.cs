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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesChessPlayersExampleContext _context;

        public IndexModel(RazorPagesChessPlayersExampleContext context)
        {
            _context = context;
            // SomeValue = 10;
        }
        public int SomeValue { get; set; } = 10;

        public IList<ChessPlayer> ChessPlayer { get; set; }

        // adding a string we can search for
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList CurrentTitles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ChessPlayerCurrentTitle { get; set; }

        // public async Task OnGetAsync()
        // {
        //     ChessPlayer = await _context.ChessPlayer.ToListAsync();
        //     // SomeValue = 10;
        // }

        // public async Task OnGetAsync()
        // {
        //     var chessPlayers = from c in _context.ChessPlayer
        //                         select c;

        //     if (!string.IsNullOrEmpty(SearchString))
        //     {
        //         chessPlayers = chessPlayers.Where(s => s.FullName.Contains(SearchString));
        //     }

        //     ChessPlayer = await chessPlayers.ToListAsync();
        // }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> currentTitleQuery = from c in _context.ChessPlayer
                                            orderby c.CurrentTitle
                                            select c.CurrentTitle;

            var chessPlayers = from c in _context.ChessPlayer
                        select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                chessPlayers = chessPlayers.Where(s => s.FullName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ChessPlayerCurrentTitle))
            {
                chessPlayers = chessPlayers.Where(x => x.CurrentTitle == ChessPlayerCurrentTitle);
            }
            CurrentTitles = new SelectList(await currentTitleQuery.Distinct().ToListAsync());
            ChessPlayer = await chessPlayers.ToListAsync();
        }
    }
}
