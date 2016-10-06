using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarMapping.Models
{
    [Table("Calendars")]
    public class Calendar
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool PrivacyStatus { get; set; }
        public virtual User User { get; set; }

        public Calendar() { }

        public Calendar(string name, bool privacyStatus, int id = 0)
        {
            Name = name;
            PrivacyStatus = privacyStatus;
            Id = id;
        }

        public override bool Equals(System.Object otherCalendar)
        {
            if (otherCalendar is Calendar)
            {
                Calendar newCalendar = (Calendar)otherCalendar;
                return this.Id.Equals(newCalendar.Id);
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

    [Table("FavoriteCalendars")]
    public class FavoriteCalendar
    {
        [Key]
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Calendar Calendar { get; set; }

        public FavoriteCalendar() { }

        public FavoriteCalendar(User user, Calendar calendar, int id = 0)
        {
            user = User;
            calendar = Calendar;
            Id = id;
        }

        public override bool Equals(System.Object otherFavoriteCalendar)
        {
            if (otherFavoriteCalendar is FavoriteCalendar)
            {
                FavoriteCalendar newFavoriteCalendar = (FavoriteCalendar)otherFavoriteCalendar;
                return this.Id.Equals(newFavoriteCalendar.Id);
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
