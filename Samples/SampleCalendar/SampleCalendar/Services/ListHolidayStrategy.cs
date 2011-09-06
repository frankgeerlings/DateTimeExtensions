using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DateTimeExtensions;
using DateTimeExtensions.Strategies;
using SampleCalendar.Models;

namespace SampleCalendar.Services {
	public class ListHolidayStrategy : IHolidayStrategy {
		private IList<Holiday> holidayList;

		public ListHolidayStrategy(IList<HolidayDTO> holidayList) {
			this.holidayList = holidayList.Select(h => (Holiday)new FixedHoliday(h.Name, new DayInYear(h.Day.Month, h.Day.Day))).ToList();
		}

		public IEnumerable<Holiday> Holidays {
			get { return holidayList; }
		}

		public bool IsHoliDay(DateTime day) {
			foreach (var holiday in holidayList) {
				if (holiday.IsInstanceOf(day)) {
					return true;
				}
			}
			return false;
		}
	}
}