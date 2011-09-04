using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateTimeExtensions;
using SampleCalendar.Models;

namespace SampleCalendar.Controllers
{
    public class HolidaysController : Controller
    {
        //
        // GET: /Holidays/

        public ActionResult Index(string culture, int year)
        {
			var model = BuildViewModelDefaults();
			var workingDayCultureInfo = new WorkingDayCultureInfo(culture);
			model.Year = year;
			model.Culture = culture;
			model.Holidays = workingDayCultureInfo.Holidays
				.Select((h) => new HolidayDTO { Day = h.GetInstance(year), Name = h.Name });

			return View(model);
        }

		private HolidaysListViewModel BuildViewModelDefaults() {
			var model = new HolidaysListViewModel() {
				Years = new List<int> { 2010, 2011, 2012, 2013, 2014, 2015 },
				Cultures = new List<string> { "pt-PT", "en-GB", "en-US", "es-ES", "fr-FR", "de-DE" }
			};
			return model;
		}
    }
}
