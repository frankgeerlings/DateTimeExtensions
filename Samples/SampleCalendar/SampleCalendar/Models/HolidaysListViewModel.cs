using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCalendar.Models {
	public class HolidaysListViewModel {
		public IEnumerable<string> Cultures { get; set; }
		public IEnumerable<int> Years { get; set; }

		public int Year { get; set; }
		public string Culture { get; set; }

		public IEnumerable<HolidayDTO> Holidays { get; set; }
	}
}