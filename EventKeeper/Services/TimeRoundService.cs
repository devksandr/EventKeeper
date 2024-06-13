using EventKeeper.Services.Interfaces;

namespace EventKeeper.Services
{
    public class TimeRoundService : ITimeRoundService
    {
        public DateTime RoundMinuteDown(DateTime date) => 
            new DateTime(
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                0,
                date.Kind);

        public DateTime RoundMinuteUp(DateTime date) => 
            date
                .AddMinutes(1)
                .AddSeconds(-date.Second)
                .AddMilliseconds(-date.Millisecond);
    }
}
