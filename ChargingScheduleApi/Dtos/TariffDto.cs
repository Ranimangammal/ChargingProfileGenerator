namespace ChargingScheduleApi.Dtos
{
	[Serializable]
	public class TariffDto
	{
		public string StartTime { get; set; }

		public string EndTime { get; set; }

		public decimal EnergyPrice { get; set; }
	}
}
