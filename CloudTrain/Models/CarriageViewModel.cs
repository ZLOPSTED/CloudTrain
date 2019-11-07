using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class CarriageViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Type { get; set; }   //coupe, reserved seat, general
        public int TrainId { get; set; }
        public string Description { get; set; }

        public int NumPlaces { get; set; }

        
    }
}