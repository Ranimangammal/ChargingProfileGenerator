using ChargingScheduleApi.Dtos;

namespace ChargingScheduleApi.Common
{
	public static class SampleRequestDto
	{
		private const decimal EnergyPriceDuringOffPeakHours = 0.22M;
		private const decimal EnergyPriceDuringPeakHours = 0.25M;
		private const decimal ChargePower = 9.6M;

		public static string GetSampleDataForTesting()
		{

			var tariffs = new[] {
				new TariffDto()
				{
					StartTime="0:00",
					EndTime = "7:00",
					EnergyPrice = EnergyPriceDuringOffPeakHours
				}, new TariffDto()
				{
					StartTime = "7:15",
					EndTime = "22:59",
					EnergyPrice = EnergyPriceDuringPeakHours
				}, new TariffDto()
				{
					StartTime = "23:00",
					EndTime = "23:59",
					EnergyPrice = EnergyPriceDuringOffPeakHours
				} };
			var userSettings = new UserSettingsDto
			{
				DesiredStateOfCharge = 100,
				DirectChargingPercentage = 20,
				LeavingTime = DateTime.UtcNow.AddHours(24).Hour.ToString(),
				Tariffs = tariffs
			};

			var requestDto = new RequestDto
			{
				StartingTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ "),
				UserSettings = userSettings,
				CarData = new CarDataDto
				{
					ChargePower = ChargePower,
					BatteryCapacity = 55,
					CurrentBatteryLevel = 25//lets assume battery level in Kw
				}

			};
			var response = Newtonsoft.Json.JsonConvert.SerializeObject(requestDto);
			return response;
		}
	}
}
