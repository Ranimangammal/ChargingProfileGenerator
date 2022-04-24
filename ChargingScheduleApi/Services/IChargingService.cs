using ChargingScheduleApi.Dtos;

namespace ChargingScheduleApi.Services
{
	public interface IChargingService
	{
		ResponseDto GenerateChargingScheduler(RequestDto input);
	}
}
