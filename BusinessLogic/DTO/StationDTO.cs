using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class StationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Description { get; set; }
        public ICollection<RouteStationDTO> Routes { get; set; }
    }
}
