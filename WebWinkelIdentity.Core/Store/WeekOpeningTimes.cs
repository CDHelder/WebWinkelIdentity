using System.Collections.Generic;

namespace WebWinkelIdentity.Core
{
    public class WeekOpeningTimes
    {
        public int Id { get; set; }
        public List<DayOpeningTime> DayOpeningTimes { get; set; }
    }
}
