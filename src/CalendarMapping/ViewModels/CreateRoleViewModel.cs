﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMapping.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
