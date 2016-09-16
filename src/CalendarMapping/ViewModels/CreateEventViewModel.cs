using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMapping.ViewModels
{
    public class CreateEventViewModel
    {
        [Required]
        [Display(Name = "Description")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
