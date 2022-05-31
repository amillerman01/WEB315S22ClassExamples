using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesChessPlayersExample.Models
{
    public class ChessPlayer
    {
        public int ID { get; set; }
        
        // public string FirstName { get; set; }
        // public  string LastName { get; set; }
        // public string FullName { get() {
        //     return this.FirstName + " " + this.LastName;
        // } }

        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Date Title was Acquired")]
        [DataType(DataType.Date)]
        public DateTime DateOfTitleAcquisition { get; set; }
        [Display(Name = "Player Title")]
        public string CurrentTitle { get; set; }
        [Display(Name = "Rating")]
        public int CurrentRating { get; set; }
        [Display(Name = "Tournament Victories")]
        public int NumberOfTournamentVictories { get; set; }
    }
}