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

        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfTitleAcquisition { get; set; }
        public string CurrentTitle { get; set; }
        public int CurrentRating { get; set; }
    }
}