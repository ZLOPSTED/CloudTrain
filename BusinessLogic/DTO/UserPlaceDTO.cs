using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class UserPlaceDTO
    {

        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public DateTime TimeStartTrip { get; set; }
        public DateTime TimeFinishTrip { get; set; }
        public string ClientName { get; set; }
        public bool WithBed { get; set; }
        public bool Drink { get; set; }
        public bool Child { get; set; }
    }
}
