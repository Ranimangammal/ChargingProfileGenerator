namespace ChargingScheduleApi.Common
{
	public static class Utils
	{
		public static double CalculateChargingHours(decimal batteryCapacity, decimal currentBatteryLevel, decimal chargePower)
		{
			var noOfHours = (batteryCapacity - currentBatteryLevel) / chargePower;
			return (double)noOfHours;
		}

		public static bool IsTimeOfDayBetween(DateTime time,
			TimeSpan startTime, TimeSpan endTime)
		{
			if (endTime == startTime)
			{
				return true;
			}
			else if (endTime < startTime)
			{
				return time.TimeOfDay <= endTime ||
					time.TimeOfDay >= startTime;
			}
			else
			{
				return time.TimeOfDay >= startTime &&
					time.TimeOfDay <= endTime;
			}

		}

		public static string ConvertDateTimeToString(DateTimeOffset dateTime)
		{
			return dateTime.ToString("yyyy - MM - ddTHH:mm: ssZ ");
		}

	}
}
