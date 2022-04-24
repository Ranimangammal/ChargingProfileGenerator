namespace ChargingScheduleApi.Dtos
{
	[Serializable]
	public class ChargingScheduleDto
	{
		public string StartTime { get; set; }

		public string EndTime { get; set; }

		public bool IsCharging { get; set; }
	}
}
