﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class FI_FIHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public FI_FIHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.Epiphany);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(GlobalHolidays.MayDay);
			this.InnerHolidays.Add(ChristianHolidays.Ascension);
			this.InnerHolidays.Add(ChristianHolidays.Pentecost);
			this.InnerHolidays.Add(GlobalHolidays.MidsummerEve);
			this.InnerHolidays.Add(GlobalHolidays.MidsummerDay);
			this.InnerHolidays.Add(AllSaintsDay);
			this.InnerHolidays.Add(IndependanceDay);
			this.InnerHolidays.Add(ChristianHolidays.ChristmasEve);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
		}

		private static Holiday independanceDay;
		public static Holiday IndependanceDay {
			get {
				if (independanceDay == null) {
					independanceDay = new FixedHoliday("Independance Day", 12, 6);
				}
				return independanceDay;
			}
		}

		//All Saints' Day - Saturday between 31 October and 6 November
		// - Same as ChristianHolidays.AllSaints but has diferent ocurrence
		private static Holiday allSaintsDay;
		public static Holiday AllSaintsDay {
			get {
				if (allSaintsDay == null) {
					allSaintsDay = new NthDayOfWeekAfterDayHoliday("All Saint's Day", 1, DayOfWeek.Saturday, 10, 31);
				}
				return allSaintsDay;
			}
		}
	}
}
