using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CalendarMapping.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
