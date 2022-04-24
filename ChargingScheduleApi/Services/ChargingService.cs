using ChargingScheduleApi.Common;
using ChargingScheduleApi.Dtos;

namespace ChargingScheduleApi.Services
{
	public class ChargingService : IChargingService
	{
		private readonly ILogger<ChargingService> _logger;

		public ChargingService(ILogger<ChargingService> logger)
		{
			_logger = logger;
		}

		public ResponseDto GenerateChargingScheduler(RequestDto input)
		{
			return GenerateInternal(input);
		}

		#region private

		private ResponseDto GenerateInternal(RequestDto input)
		{
			try
			{
				DateTime startingDateTime = DateTimeOffset.Parse(input.StartingTime).UtcDateTime;
				var offPeakHourStartDateTimeInUtc = new DateTimeOffset(new DateTime(
					startingDateTime.Year,
					startingDateTime.Month,
					startingDateTime.Day,
					23, 0, 0));
				var peakHourStartDateTimeInUtc = new DateTimeOffset(new DateTime(
																		startingDateTime.Year,
																		startingDateTime.Month,
																		startingDateTime.Day,
																		7, 0, 0));
				var chargingHours = Utils.CalculateChargingHours(
					input.CarData.BatteryCapacity,
					input.CarData.CurrentBatteryLevel,
					input.CarData.ChargePower);

				var chargingSchedule = GetChargingSchedule(
					peakHourStartDateTimeInUtc,
					offPeakHourStartDateTimeInUtc,
					chargingHours);

				// If Current Battery > 11 KW
				if (input.CarData.CurrentBatteryLevel >= 11)
				{
					return new ResponseDto
					{
						Items = chargingSchedule
					};
				}

				if (input.CarData.CurrentBatteryLevel < 11)
				{
					bool isPeakHours = Utils.IsTimeOfDayBetween(
						startingDateTime,
						new TimeSpan(7, 0, 0),
						new TimeSpan(23, 0, 0));
					if (isPeakHours)

					{
						//get minimum battery level during peak hours
						//first direct charge to minimum 11 battery capacity

						var directChargingHours = Utils.CalculateChargingHours(
							input.UserSettings.DirectChargingPercentage,
							input.CarData.CurrentBatteryLevel,
							input.CarData.ChargePower);
						var directChargeStartTime = new DateTimeOffset(new DateTime(
																			startingDateTime.Year,
																			startingDateTime.Month,
																			startingDateTime.Day,
																			startingDateTime.Hour,
																			startingDateTime.Minute,
																			startingDateTime.Second));
						var directChargeEndTime = Utils.ConvertDateTimeToString(directChargeStartTime
																				.AddHours(directChargingHours));
						var batteryLevel = (input.UserSettings.DirectChargingPercentage * input.CarData.BatteryCapacity / 100) - input.CarData.CurrentBatteryLevel;
						input.CarData.CurrentBatteryLevel += batteryLevel;

						var result = GetChargingScheduleDuringPeakHours(
							directChargeStartTime,
							directChargeEndTime,
							offPeakHourStartDateTimeInUtc,
							chargingHours);

						return new ResponseDto
						{
							Items = result
						};

					}
					else
					{
						return new ResponseDto
						{
							Items = chargingSchedule
						};
					}

				}
			}
			catch (Exception e)
			{
				_logger.LogError("An Exception occurred while getting result. {@ex}", e);
			}
			return new ResponseDto();

		}

		private ChargingScheduleDto[] GetChargingSchedule(
			DateTimeOffset peakHourStartDateTimeInUtc,
			DateTimeOffset offPeakHourStartDateTimeInUtc,
			double chargingHours)
		{
			var result = new List<ChargingScheduleDto>
			{
				new ChargingScheduleDto
				{
					StartTime =Utils.ConvertDateTimeToString(peakHourStartDateTimeInUtc),
					EndTime =Utils.ConvertDateTimeToString(offPeakHourStartDateTimeInUtc),
					IsCharging = false

				},
				new ChargingScheduleDto
				{
					StartTime =Utils.ConvertDateTimeToString(offPeakHourStartDateTimeInUtc),
					EndTime =Utils.ConvertDateTimeToString( offPeakHourStartDateTimeInUtc
					.AddHours(chargingHours)),
					IsCharging = true

				}
			};
			return result.ToArray();
		}

		private ChargingScheduleDto[] GetChargingScheduleDuringPeakHours(
			DateTimeOffset directChargeStartTime,
			string directChargeEndTime,
			DateTimeOffset offPeakHourStartDateTimeInUtc,
			double chargingHours)
		{
			var result = new List<ChargingScheduleDto>
			{
				new ChargingScheduleDto
				{
					StartTime = Utils.ConvertDateTimeToString(directChargeStartTime),
					EndTime = directChargeEndTime,
					IsCharging = true

				},
				new ChargingScheduleDto
				{
					StartTime = directChargeEndTime,
					EndTime = Utils.ConvertDateTimeToString(offPeakHourStartDateTimeInUtc),
					IsCharging = false

				},
				new ChargingScheduleDto
				{
					StartTime = Utils.ConvertDateTimeToString(offPeakHourStartDateTimeInUtc),
					EndTime = Utils.ConvertDateTimeToString(offPeakHourStartDateTimeInUtc.AddHours(chargingHours)),
					IsCharging = true

				}
			};

			return result.ToArray();
		}


		#endregion
	}
}
