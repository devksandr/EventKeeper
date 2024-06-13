using EventKeeper.Models.DTO;

namespace EventKeeper.Services
{
    public interface IEventService
    {
        public bool AddEvent(AddEventDTORequest eventDTO);
        public List<GetEventDTOResponse>? GetEvent(DateTime startRange, DateTime endRange);
    }
}