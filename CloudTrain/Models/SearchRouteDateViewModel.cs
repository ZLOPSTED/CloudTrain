using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class SearchRouteDateViewModel
    {
        public int StartStationId { get; set; }
        public int FinishStationId { get; set; }

        public DateTime RouteDate{ get; set; }
    }
}