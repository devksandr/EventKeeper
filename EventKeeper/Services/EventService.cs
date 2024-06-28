using EventKeeper.Database;
using EventKeeper.Models.DTO;
using EventKeeper.Models.Entities;
using EventKeeper.Services.Interfaces;

namespace EventKeeper.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationContext _db;
        private readonly ITimeRoundService _timeRoundService;

        public EventService(ApplicationContext db, ITimeRoundService timeRoundService)
        {
            (_db, _timeRoundService) = (db, timeRoundService);
        }

        public bool AddEvent(AddEventDTORequest eventDTO)
        {
            var eventEntity = new Event()
            {
                Name = eventDTO.Name,
                Value = eventDTO.Value,
                Timestamp = DateTime.UtcNow
            };

            try
            {
                _db.Add(eventEntity);
                _db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<GetEventDTOResponse>? GetEvent(GetEventDTORequest eventDTO)
        {
            var eventsDTO = new List<GetEventDTOResponse>();

            DateTime startRangeRounded = _timeRoundService.RoundMinuteDown(eventDTO.StartRange);
            DateTime endRangeRounded = _timeRoundService.RoundMinuteUp(eventDTO.EndRange);

            try
            {
                var filteredEvents = _db.Events
                    .Where(e => e.Timestamp >= startRangeRounded && e.Timestamp < endRangeRounded)
                    .OrderBy(e => e.Timestamp)
                    .ToList();

                eventsDTO = filteredEvents
                    .GroupBy(fe => _timeRoundService.RoundMinuteDown(fe.Timestamp))
                    .Select(gfe => new GetEventDTOResponse
                    {
                        StartRange = eventDTO.ConvertToLocal ? gfe.Key.ToLocalTime() : gfe.Key,
                        EndRange = eventDTO.ConvertToLocal ? gfe.Key.AddMinutes(1).ToLocalTime() : gfe.Key.AddMinutes(1),
                        ValueSum = gfe.Sum(e => e.Value)
                    })
                    .ToList();
            }
            catch
            {
                return null;
            }

            return eventsDTO;
        }
    }
}