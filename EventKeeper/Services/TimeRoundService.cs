using EventKeeper.Services.Interfaces;
using System;

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

        public DateTime RoundMinuteUp(DateTime date)
        {
            var ticksToWholeMinute = TimeSpan.TicksPerMinute - (date.Ticks % TimeSpan.TicksPerMinute);
            return date.AddTicks(ticksToWholeMinute);
        }
    }
}
