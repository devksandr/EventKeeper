using EventKeeper.Models.DTO;
using EventKeeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public IActionResult AddEvent([FromBody] AddEventDTORequest eventDTO)
        {
            bool addEventStatus = _eventService.AddEvent(eventDTO);
            if (!addEventStatus)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetEvent(DateTime startRange, DateTime endRange)
        {
            var events = _eventService.GetEvent(startRange, endRange);
            if (events is null)
            {
                return BadRequest();
            }

            return Ok(events);
        }
    }
}