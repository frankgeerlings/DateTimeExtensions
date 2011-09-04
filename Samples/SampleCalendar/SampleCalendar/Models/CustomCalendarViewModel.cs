using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCalendar.Models {
	public class CustomCalendarViewModel {
		public HolidayDTO AddHoliday { get; set; }
		public IEnumerable<HolidayDTO> Holidays { get; set;}
	}
}