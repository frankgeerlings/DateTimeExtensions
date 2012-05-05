using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NSubstitute;

namespace DateTimeExtensions.Tests {
	[TestFixture]
	public class GenericWorkingDayCultureInfoTests {

		[Test]
		public void can_locate_default_strategies() {
			string name = "foo";
			WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo(name);
			Assert.IsTrue(name == workingdayCultureInfo.Name);
			Assert.IsInstanceOf<DefaultHolidayStrategy>(workingdayCultureInfo.LocateHolidayStrategy(name));
			Assert.IsInstanceOf<DefaultWorkingDayOfWeekStrategy>(workingdayCultureInfo.LocateWorkingDayOfWeekStrategy(name));
		}

		[Test]
		public void can_provide_custom_locator_holiday_dayOfWeek_strategy() {
			var mockHolidayStrategy = Substitute.For<IHolidayStrategy>();
			mockHolidayStrategy.IsHoliDay(Arg.Any<DateTime>()).Returns(true);
			var mockDayOfWeekStartegy = Substitute.For<IWorkingDayOfWeekStrategy>();
			mockDayOfWeekStartegy.IsWorkingDay(Arg.Any<DayOfWeek>()).Returns(true);

			WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo() {
				LocateHolidayStrategy = (n) => {
					return mockHolidayStrategy;
				},
				LocateWorkingDayOfWeekStrategy = (n) => {
					return mockDayOfWeekStartegy;
				}
			};

			DateTime marchFirst = new DateTime(1991, 3, 1);
			Assert.IsTrue(marchFirst.IsHoliday(workingdayCultureInfo));
			Assert.IsFalse(marchFirst.IsWorkingDay(workingdayCultureInfo));
			mockHolidayStrategy.Received().IsHoliDay(marchFirst);
			mockDayOfWeekStartegy.Received().IsWorkingDay(marchFirst.DayOfWeek);
		}

		[Test]
		public void can_provide_custom_locator_dayOfWeek_strategy() {
			var mockDayOfWeekStartegy = Substitute.For<IWorkingDayOfWeekStrategy>();
			mockDayOfWeekStartegy.IsWorkingDay(Arg.Any<DayOfWeek>()).Returns(false);

			WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo() {
				LocateWorkingDayOfWeekStrategy = (n) => {
					return mockDayOfWeekStartegy;
				}
			};

			DateTime aThursday = new DateTime(2011, 5, 12);
			Assert.IsFalse(aThursday.IsWorkingDay(workingdayCultureInfo));
			Assert.IsFalse(aThursday.IsHoliday(workingdayCultureInfo));
			mockDayOfWeekStartegy.Received().IsWorkingDay(aThursday.DayOfWeek);
		}

	}
}
