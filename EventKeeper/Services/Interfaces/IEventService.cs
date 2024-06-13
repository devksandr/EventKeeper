using EventKeeper.Models.DTO;

namespace EventKeeper.Services.Interfaces
{
    public interface IEventService
    {
        public bool AddEvent(AddEventDTORequest eventDTO);
        public List<GetEventDTOResponse>? GetEvent(DateTime startRange, DateTime endRange);
    }
}