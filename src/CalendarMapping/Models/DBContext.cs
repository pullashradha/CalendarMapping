﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CalendarMapping.Models
{
    public class DBContext : IdentityDbContext<User>
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<FavoriteCalendar> FavoriteCalendars { get; set; }

        public DBContext(DbContextOptions options) : base(options) { }
    }
}
