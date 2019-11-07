using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
   public  class RouteStationDTO
    {
        public int StationId { get; set; }

        public string StationName { get; set; }
        public int RouteId { get; set; }
        public DateTime TimeArrival { get; set; }
        public DateTime TimeDeparture { get; set; }

    }
}
