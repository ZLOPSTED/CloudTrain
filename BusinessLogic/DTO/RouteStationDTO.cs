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
        public DateTime DateArrival { get; set; }
        public DateTime DateDeparture { get; set; }

    }
}
