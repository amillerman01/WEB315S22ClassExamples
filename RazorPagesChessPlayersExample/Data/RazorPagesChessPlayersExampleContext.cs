using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesChessPlayersExample.Models;

    public class RazorPagesChessPlayersExampleContext : DbContext
    {
        public RazorPagesChessPlayersExampleContext (DbContextOptions<RazorPagesChessPlayersExampleContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesChessPlayersExample.Models.ChessPlayer> ChessPlayer { get; set; }
    }
