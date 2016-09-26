using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CalendarMapping.Models
{
    public class Role : IdentityRole
    {
        public override bool Equals(System.Object otherRole)
        {
            if (otherRole is Role)
            {
                Role newRole = (Role)otherRole;
                return this.Id.Equals(newRole.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
