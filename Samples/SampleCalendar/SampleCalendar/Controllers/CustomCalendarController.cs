using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleCalendar.Models;

using DateTimeExtensions;
using SampleCalendar.Services;

namespace SampleCalendar.Controllers
{
    public class CustomCalendarController : Controller
    {

		//poor man's persistence
		private IList<HolidayDTO> Holidays{
			get{
				IList<HolidayDTO> holidays = (IList<HolidayDTO>)HttpContext.Session["holidays"];
				if (holidays == null) {
					holidays = new List<HolidayDTO>();
					HttpContext.Session["holidays"] = holidays;
				}
				return holidays;
			}
		}

        //
        // GET: /CustomCalendar/

        public ActionResult Index()
        {
			var model = new CustomCalendarViewModel() {
				AddHoliday = new HolidayDTO { Day = DateTime.Today },
				Holidays = Holidays
			};
			return View(model);
        }

		[HttpPost]
		public ActionResult AddHoliday(CustomCalendarViewModel newHoliday) {
			Holidays.Add(newHoliday.AddHoliday);
			return PartialView("HolidayList", Holidays);
		}

		public ActionResult TestWorkingDay() {
			return TestWorkingDay(new TestWorkingDayViewModel { TestDate = DateTime.Now });
		}

		[HttpPost]
		public ActionResult TestWorkingDay(TestWorkingDayViewModel model) {
			if (!ModelState.IsValid)
				return PartialView(model);

			var listWorkingDayCultureInfo = new WorkingDayCultureInfo {
				LocateHolidayStrategy = (name) => new ListHolidayStrategy(Holidays)
			};

			var date = model.TestDate;
			model.IsWorkingDay = date.IsWorkingDay(listWorkingDayCultureInfo);
			model.NextWorkingDay = date.AddWorkingDays(1, listWorkingDayCultureInfo);
			model.FifthWorkingDay = date.AddWorkingDays(5, listWorkingDayCultureInfo);
			return PartialView(model);
		}
    }
}
