﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class PT_BRNaturalTimeStrategy  : NaturalTimeStrategyBase{
		protected override string YearText {
			get {
				return "ano";
			}
		}

		protected override string MonthText {
			get {
				return "mes";
			}
		}

		protected override string DayText {
			get {
				return "dia";
			}
		}

		protected override string HourText {
			get {
				return "hora";
			}
		}

		protected override string MinuteText {
			get {
				return "minuto";
			}
		}

		protected override string SecondText {
			get {
				return "segundo";
			}
		}

		protected override string Pluralize(string text) {
			if (text.EndsWith("s")) {
				return text + "es";
			}
			return base.Pluralize(text);
		}
	}
}
