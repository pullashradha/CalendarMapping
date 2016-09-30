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
    [Table("Events")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartingDateTime { get; set; }
        public DateTime EndingDateTime { get; set; }
        public string Address { get; set; }
        public virtual User User { get; set; }
        public virtual Calendar Calendar { get; set; }

        public Event() { }

        public Event(string description, DateTime startingDateTime, DateTime endingDateTime, string address, int id = 0)
        {
            Description = description;
            StartingDateTime = startingDateTime;
            EndingDateTime = endingDateTime;
            Address = address;
            Id = id;
        }

        public override bool Equals (System.Object otherEvent)
        {
            if (otherEvent is Event)
            {
                Event newEvent = (Event)otherEvent;
                return this.Id.Equals(newEvent.Id);
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
