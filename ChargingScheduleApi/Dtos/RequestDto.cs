namespace ChargingScheduleApi.Dtos
{
	[Serializable]
	public class RequestDto
	{
		public RequestDto()
		{
			UserSettings = new UserSettingsDto();
			CarData = new CarDataDto();
		}
		public string StartingTime { get; set; }

		public UserSettingsDto UserSettings { get; set; }

		public CarDataDto CarData { get; set; }
	}
}
