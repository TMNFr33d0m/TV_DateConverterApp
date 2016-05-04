using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketVista_Eval.Models
{
    public class DT_Conv
    {
                    // Because I used Entity framework to gen out the views and controller, I must designate a Key. 
            [Key] public int DTKey { get; set; }

        // Create a simple DateTime method (type prop, hit tab twice, fill in the necessary) 
        // Let's make it a required field using MVC validation:   
        [Required(ErrorMessage = "Uh Oh! You need to enter a date and time to convert!")]
        // Let's also change the display name, so it looks nice: 
            [DisplayName("Date: ")]
        // Lets set the watermark display filter 
            [Display(Prompt ="mm/dd/yyyy --:--:--")]

        // And some Regular Expression for validation. Alter web.config to add JQUERY validation and Unobtrusive w/ custom error msg.
            [RegularExpression(@"^(((((0[13578])|([13578])|(1[02]))[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9])|(3[01])))|((([469])|(11))[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9])|(30)))|((02|2)[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9]))))[\-\/\s]?\d{4})(\s(((0[1-9])|([1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$",
            ErrorMessage = "Date Format Invalid")]
        // And here, we're actually creating the field...
        public DateTime LocalTimeField { get; set; }

    }
}
