using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class RouteTrain
    {
        public Train Train { get; set; }

        [Key, Column(Order = 0)]
        public int TrainId { get; set; }
        public Route Route{ get; set; }

        [Key, Column(Order = 1)]
        public int RouteId { get; set; }
        public DateTime Date { get; set; }
    }
}