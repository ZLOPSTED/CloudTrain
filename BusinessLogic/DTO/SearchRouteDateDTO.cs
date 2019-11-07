using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class SearchRouteDateDTO
    {
        public int StartStationId { get; set; }
        public int FinishStationId { get; set; }

        public DateTime RouteDate { get; set; }
    }
}
