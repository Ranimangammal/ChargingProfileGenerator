using ChargingScheduleApi.Dtos;
using ChargingScheduleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChargingScheduleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/json")]
	public class ChargingController : ControllerBase
	{
		private readonly IChargingService _chargingService;
		private readonly ILogger<ChargingController> _logger;

		public ChargingController(
			ILogger<ChargingController> logger,
			IChargingService chargingService)
		{
			_logger = logger;
			_chargingService = chargingService;
		}

		[HttpPost]
		public ResponseDto GetChargingSchedule([FromBody]RequestDto request)
		{
			_logger.LogInformation("request received : {request}", request);

			return _chargingService.GenerateChargingScheduler(request);
		}

	}
}
