using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class Route
    {
        public int Id{get; set;}
        public string Name { get; set; }
        public float CoupeFare { get; set; } // цена за купе
        public float ReservedSeatFare { get; set; }  // цена за плацкарт
        public float generalFare { get; set; }// цена за общий
        /*public ICollection<Station> Stations { get; set; }
        public Route()
        {
            Stations = new List<Station>();
        }*/
    }
}