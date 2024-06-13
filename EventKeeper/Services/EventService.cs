using EventKeeper.Models.DTO;

namespace EventKeeper.Services
{
    public class EventService : IEventService
    {
        public bool AddEvent(AddEventDTORequest eventDTO)
        {
            // TODO

            return true;
        }

        public List<GetEventDTOResponse>? GetEvent(DateTime startRange, DateTime endRange)
        {
            var events = new List<GetEventDTOResponse>();
            // TODO

            return events;
        }
    }
}
