namespace EventKeeper.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}