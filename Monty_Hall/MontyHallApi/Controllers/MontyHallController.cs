using Microsoft.AspNetCore.Mvc;
using MontyHallApi.Entities;
using MontyHallApi.Services;

namespace MontyHallApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MontyHallController : ControllerBase
    {
        private readonly IMontyHallService _montyHallService;

        public MontyHallController(IMontyHallService montyHallService)
        {
            _montyHallService = montyHallService;
        }

        [HttpPost("simulate")]
        public IActionResult SimulateMontyHall([FromBody] SimulationRequest request)
        {
            try
            {
                var result = _montyHallService.SimulateMontyHall(request.NumSimulations, request.ChangeDoor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
