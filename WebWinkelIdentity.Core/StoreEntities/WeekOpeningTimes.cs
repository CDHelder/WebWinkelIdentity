using System.Collections.Generic;

namespace WebWinkelIdentity.Core.StoreEntities
{
    public class WeekOpeningTimes
    {
        public int Id { get; set; }
        public List<DayOpeningTime> DayOpeningTimes { get; set; }
    }
}
