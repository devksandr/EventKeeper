namespace EventKeeper.Services.Interfaces
{
    public interface ITimeRoundService
    {
        public DateTime RoundMinuteUp(DateTime date);
        public DateTime RoundMinuteDown(DateTime date);
    }
}
