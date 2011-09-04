using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleCalendar.Models;

namespace SampleCalendar.Controllers
{
    public class CustomCalendarController : Controller
    {
		IList<HolidayDTO> holidays;

		public CustomCalendarController() : base() {
			holidays = new List<HolidayDTO>();
		}

        //
        // GET: /CustomCalendar/

        public ActionResult Index()
        {
			var model = new CustomCalendarViewModel() {
				AddHoliday = new HolidayDTO(),
				Holidays = holidays
			};
			return View(model);
        }

		[HttpPost]
		public ActionResult AddHoliday(CustomCalendarViewModel newHoliday) {
			holidays.Add(newHoliday.AddHoliday);
			return PartialView("HolidayList", holidays);
		}
    }
}
