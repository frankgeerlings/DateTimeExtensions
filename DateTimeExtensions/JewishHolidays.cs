﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public static class JewishHolidays {

		private static readonly Calendar HebrewCalendar = new HebrewCalendar();

		private static Holiday roshHashanah;
		public static Holiday RoshHashanah {
			get { return roshHashanah ?? (roshHashanah = new FixedHoliday("Rosh Hashanah", new DayInYear(1, 1, HebrewCalendar))); }
		}

		private static Holiday roshHashanahSecondDay;
		public static Holiday RoshHashanahSecondDay {
			get { return roshHashanahSecondDay ?? (roshHashanahSecondDay = new FixedHoliday("Rosh Hashanah", new DayInYear(1, 2, HebrewCalendar))); }
		}

		private static Holiday yomKippur;
		public static Holiday YomKippur {
			get { return yomKippur ?? (yomKippur = new FixedHoliday("Yom Kippur", new DayInYear(1, 10, HebrewCalendar))); }
		}

		private static Holiday sukkot;
		public static Holiday Sukkot {
			get { return sukkot ?? (sukkot = new FixedHoliday("Sukkot", new DayInYear(1, 15, HebrewCalendar))); }
		}

		private static Holiday shminiAtzeret;
		public static Holiday ShminiAtzeret {
			get { return shminiAtzeret ?? (shminiAtzeret = new FixedHoliday("Shmini Atzeret", new DayInYear(1, 22, HebrewCalendar))); }
		}

		private static Holiday shminiTorah;
		public static Holiday ShminiTorah {
			get { return shminiTorah ?? (shminiTorah = new FixedHoliday("Shmini Torah", new DayInYear(1, 23, HebrewCalendar))); }
		}

		private static Holiday pesach;
		public static Holiday Pesach {
			get { return pesach ?? (pesach = new FixedHoliday("Pesach", new DayInYear(7, 15, HebrewCalendar))); }
		}

		private static Holiday shviiShelPesach;
		public static Holiday ShviiShelPesach {
			get { return shviiShelPesach ?? (shviiShelPesach = new FixedHoliday("Shvi'i shel Pesach", new DayInYear(7, 21, HebrewCalendar))); }
		}

		private static Holiday shavuot;
		public static Holiday Shavuot {
			get { return shavuot ?? (shavuot = new FixedHoliday("Shavuot", new DayInYear(9, 6, HebrewCalendar))); }
		}

		private static Holiday tuBishvat;
		public static Holiday TuBishvat {
			get { return tuBishvat ?? (tuBishvat = new FixedHoliday("Tu Bishvat", new DayInYear(5, 15, HebrewCalendar))); }
		}
	}
}
