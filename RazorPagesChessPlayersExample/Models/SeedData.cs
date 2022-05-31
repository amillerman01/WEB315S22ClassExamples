using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// using RazorPagesChessPlayersExample.Data;
using System;
using System.Linq;

namespace RazorPagesChessPlayersExample.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesChessPlayersExampleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesChessPlayersExampleContext>>()))
            {
                // Look for any movies.
                if (context.ChessPlayer.Any())
                {
                    return;   // DB has been seeded
                }

                context.ChessPlayer.AddRange(
                    new ChessPlayer
                    {
                        FullName = "Magnus Carlson",
                        DateOfTitleAcquisition = DateTime.Parse("1989-2-12"),
                        CurrentTitle = "GM",
                        CurrentRating = 2800,
                        NumberOfTournamentVictories = 1200,
                        AnnualWageAsChessPlayer = 8000000
                    },
                    new ChessPlayer
                    {
                        FullName = "Hikaru Nikamura",
                        DateOfTitleAcquisition = DateTime.Parse("1990-2-12"),
                        CurrentTitle = "GM",
                        CurrentRating = 2799,
                        NumberOfTournamentVictories = 1000,
                        AnnualWageAsChessPlayer = 1000000
                    },
                    new ChessPlayer
                    {
                        FullName = "Ben Finegold",
                        DateOfTitleAcquisition = DateTime.Parse("1970-2-12"),
                        CurrentTitle = "GM",
                        CurrentRating = 2400,
                        NumberOfTournamentVictories = 600,
                        AnnualWageAsChessPlayer = 100000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}