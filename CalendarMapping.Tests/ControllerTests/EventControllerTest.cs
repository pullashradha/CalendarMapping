using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalendarMapping.Controllers;
using CalendarMapping.Models;
using Xunit;

namespace CalendarMapping.Tests.ControllerTests
{
    public class EventControllerTest
    {
        //[Fact]
        //public void Test_ViewResult_GetIndex()
        //{
        //    EventController controller = new EventController();
        //    var resultView = controller.Index();
        //    Assert.IsType<ViewResult>(resultView);
        //}

        //[Fact]
        //public void Test_Get_ModelList()
        //{
        //    EventController controller = new EventController();
        //    IActionResult actionResult = controller.Index();
        //    ViewResult indexView = controller.Index() as ViewResult;

        //    var result = indexView.ViewData.Model;

        //    Assert.IsType<List<Event>>(result);
        //}

        //[Fact]
        //public void Test_Post_MethodAddsItem()
        //{
        //    EventController controller = new EventController();
        //    Event newEvent = new Event();
        //    newEvent.Description = "OHS Volunteer Party";
        //    newEvent.Date = new DateTime(2016, 10, 1, 0, 0, 0);
        //    newEvent.StartTime = new DateTime(2016, 10, 1, 18, 00, 00);
        //    newEvent.EndTime = new DateTime(2016, 10, 1, 20, 30, 00);
        //    newEvent.Address = "1111 SW Washington St., Portland, OR 97206";

        //    controller.Create(newEvent);
        //    ViewResult indexView = new EventController().Index() as ViewResult;

        //    var collection = indexView.ViewData.Model as IEnumerable<Event>;

        //    Assert.Contains<Event>(newEvent, collection);
        //}
    }
}
