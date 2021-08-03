using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Core.StoreEntities
{
    public class DayOpeningTime
    {
        public int Id { get; set; }
        public int WeekOpeningTimesId { get; set; }
        public string Day { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }
        public bool IsClosed { get; set; }
    }
}
