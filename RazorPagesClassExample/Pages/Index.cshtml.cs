using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesClassExample.Models;

namespace RazorPagesClassExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        enum Colors { 
            Red = 1, 
            Green = 2, 
            Blue = 4, 
            Yellow = 8 
        };

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var someColourFromTheUser = 2; // Green

            // if (someColourFromTheUser == 1) 
            if (someColourFromTheUser == (int)Colors.Red) 
            {
                // do something specific when it's red
            }
            else if (someColourFromTheUser == (int)Colors.Green) 
            {
                // something specific when it's green
            }
            else if (someColourFromTheUser == 4)
            {
                // something specific when it's blue
            }
            else if (someColourFromTheUser == 8)
            {
                // something specific when it's yellow
            }

            // switch(someColourFromTheUser){
            //     case (int)Colors.Red:
            //     {

            //     }
            //     case (int)Colors.Green:{

            //     }
            // }
        }
/**
* param(somevalue) - it does something
*/
        public void doAThing(string somevalue){
            // will do something
        }
    }
}
