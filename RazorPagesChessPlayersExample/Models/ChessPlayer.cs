using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FullName { get; set; }

        [Display(Name = "Date Title was Acquired")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfTitleAcquisition { get; set; }

        [Display(Name = "Player Title")]
        public string CurrentTitle { get; set; }

        [Display(Name = "Rating")]
        [Required]
        public int CurrentRating { get; set; }

        [Display(Name = "Tournament Victories")]
        [Required]
        public int NumberOfTournamentVictories { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal AnnualWageAsChessPlayer { get; set; }
    }
}