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

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Address { get; set; }

        public virtual User User { get; set; }

        public Event(string description, DateTime startTime, DateTime endTime, string address, DateTime date = default(DateTime), int id = 0)
        {
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Address = address;
            Date = date;
            Id = id;
        }

        public Event () { }
    }
}
