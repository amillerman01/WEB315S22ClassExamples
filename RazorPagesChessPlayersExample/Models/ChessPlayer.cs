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
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "{0} must start with a capital letter and only contain letters or spaces")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FullName { get; set; }

        [Display(Name = "Date Title was Acquired")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfTitleAcquisition { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "{0} must start with a capital letter, and can contain letters, numbers, spaces, hyphens and quotes")]
        [Display(Name = "Player Title")]
        [StringLength(10)]
        // [MinimumLength(2)]
        public string CurrentTitle { get; set; }

        [Display(Name = "Rating")]
        [Range(0, 3000)]
        [Required]
        public int CurrentRating { get; set; }

        [Display(Name = "Tournament Victories")]
        [Required]
        public int NumberOfTournamentVictories { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The value of {0} must be greater than {1}.")]
        [Required]
        public decimal AnnualWageAsChessPlayer { get; set; }
    }
}