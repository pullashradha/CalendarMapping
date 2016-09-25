using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMapping.Models;
using Xunit;

namespace CalendarMapping.Tests
{
    public class EventTest
    {
        [Fact]
        public void GetDescription_Event_Test()
        {
            var newEvent = new Event();
            newEvent.Description = "OHS Volunteer Party";
            var resultDescription = newEvent.Description;
            Assert.Equal("OHS Volunteer Party", resultDescription);
        }
    }
}
