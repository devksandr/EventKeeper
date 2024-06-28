namespace EventKeeper.Models.DTO
{
    public class GetEventDTORequest
    {
        public DateTime StartRange { get; set; }
        public DateTime EndRange { get; set; }
        public bool ConvertToLocal { get; set; } = false;
    }
}
