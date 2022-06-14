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

        /***************************
        This was the version before we added any search
        ***************************/
        // public async Task OnGetAsync()
        // {
        //     ChessPlayer = await _context.ChessPlayer.ToListAsync();
        //     // SomeValue = 10;
        // }

        /***************************
        This was the version after we added the ability to search the names
        ***************************/
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


        /***************************
        This was the version after we completed both searches
        ***************************/
        // public async Task OnGetAsync()
        // {
        //     // Use LINQ to get list of genres.
        //     IQueryable<string> currentTitleQuery = from c in _context.ChessPlayer
        //                                     orderby c.CurrentTitle
        //                                     select c.CurrentTitle;

        //     var chessPlayers = from c in _context.ChessPlayer
        //                 select c;

        //     if (!string.IsNullOrEmpty(SearchString))
        //     {
        //         chessPlayers = chessPlayers.Where(s => s.FullName.ToLower().Contains(SearchString.ToLower()));
        //     }

        //     if (!string.IsNullOrEmpty(ChessPlayerCurrentTitle))
        //     {
        //         chessPlayers = chessPlayers.Where(x => x.CurrentTitle == ChessPlayerCurrentTitle);
        //     }
        //     CurrentTitles = new SelectList(await currentTitleQuery.Distinct().ToListAsync());
        //     ChessPlayer = await chessPlayers.ToListAsync();
        // }

        /***************************
        This was the version after we completed both searches, with comments breaking it down step by step
        ***************************/
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> currentTitleQuery = from c in _context.ChessPlayer
                                            orderby c.CurrentTitle
                                            select c.CurrentTitle;
            /* in sql is would be something like:
                select c.currentTitle from ChessPlayer as c
                    order by c.currentTitle
            */


            var chessPlayers = from c in _context.ChessPlayer
                                select c;
            /* in sql is would be something like:
                select * from ChessPlayer as c
            */

            if (!string.IsNullOrEmpty(SearchString))
            {
                // don't want a function definition if we're just using it once
                // chessPlayers = chessPlayers.Where(getPlayersByFullName);

                // don't need all this extra syntax for declaring an inline function necessarily
                //  chessPlayers = chessPlayers.Where(
                //     function(s){ return s.FullName.ToLower().Contains(SearchString.ToLower()) }
                // );

                chessPlayers = chessPlayers.Where(
                    // super simplified method definition, using a lambda method (or arrow function in javascript)
                        chessPlayerBeingProcessed => chessPlayerBeingProcessed.FullName.ToLower().Contains(SearchString.ToLower())
                    );
                /* in sql, we are just adding this to our selection above:
                    where LOWER(c.fullName) = LOWER(searchString)
                */

                /* 
                    The end result of the sql is:
                        select * from ChessPlayer as c
                            where LOWER(c.fullName) = LOWER(searchstring)
                */

            }

            if (!string.IsNullOrEmpty(ChessPlayerCurrentTitle))
            {
                chessPlayers = chessPlayers.Where(c => c.CurrentTitle == ChessPlayerCurrentTitle);

                /* in sql, we are just adding this to our selection above:
                    where c.currentTitle = chessPlayerCurrentTitle
                */

                /* 
                    The end result of the sql is this if we had a search string where clause added as well:
                        select * from ChessPlayer as c
                            where LOWER(c.fullName) = LOWER(searchstring)
                            AND c.currentTitle = chessPlayerCurrentTitle
                */

                /* 
                    The end result of the sql is this if we had a search string where clause was NOT added:
                        select * from ChessPlayer as c
                            where c.currentTitle = chessPlayerCurrentTitle
                */
            }


            // execute the query to get all the tables, and only return the list of titles that are distinct (no duplicates)
            CurrentTitles = new SelectList(await currentTitleQuery.Distinct().ToListAsync());
            
            // execute the query against the database and return the values that match the query
            // this will return all the chess players that match our select statement and where clauses
            ChessPlayer = await chessPlayers.ToListAsync(); 
        }

        /***************************
        This is an example method we would potentially use instead of the lambda method in the searchString
        ***************************/
        // this would be wasteful because we only need the functionality behind this method once, so we instead use a lambda method
        // public IQueryable<ChessPlayer> getPlayersByFullName(ChessPlayer chessPlayer) // approximately what the lambda method does in the search if statement
        // {
        //     if (chessPlayer.FullName.ToLower().Contains(SearchString.ToLower()))
        //         return chessPlayer;
        // }

    }
}
