using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCalendar.Models {
	public class TestWorkingDayViewModel {
		public DateTime TestDate { get; set; }
		public bool IsWorkingDay { get; set; }
		public DateTime NextWorkingDay { get; set; }
		public DateTime FifthWorkingDay { get; set; }
	}
}