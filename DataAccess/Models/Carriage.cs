using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Carriage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Type { get; set; }   //coupe, reserved seat, general
        public Train Train { get; set; }
        public int? TrainId { get; set; }

        public bool IsUsed { get; set; }

        public string Description { get; set; }
        public ICollection<Place> Places { get; set; }
        public Carriage()
        {
            Places = new List<Place>();
        }
    }
}