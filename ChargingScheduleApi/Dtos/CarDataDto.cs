namespace ChargingScheduleApi.Dtos
{
	[Serializable]
	public class CarDataDto
	{
		public decimal ChargePower { get; set; }

		public decimal BatteryCapacity { get; set; }

		public decimal CurrentBatteryLevel { get; set; }
	}
}
