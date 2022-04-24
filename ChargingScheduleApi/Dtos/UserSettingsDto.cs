namespace ChargingScheduleApi.Dtos
{
	[Serializable]
	public class UserSettingsDto
	{
		public UserSettingsDto()
		{
			Tariffs = Array.Empty<TariffDto>();
		}
		public int DesiredStateOfCharge { get; set; }

		public string LeavingTime { get; set; }

		public int DirectChargingPercentage { get; set; }

		public TariffDto[] Tariffs { get; set; }
	}
}
