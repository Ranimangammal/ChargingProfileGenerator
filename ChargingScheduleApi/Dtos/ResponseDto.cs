namespace ChargingScheduleApi.Dtos
{
	[Serializable]
	public class ResponseDto
	{
		public ResponseDto()
		{
			Items = Array.Empty<ChargingScheduleDto>();
		}

		public ChargingScheduleDto[] Items { get; set; }
	}
}
