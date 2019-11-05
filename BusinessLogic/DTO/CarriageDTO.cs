using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class CarriageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Type { get; set; }   //coupe, reserved seat, general
        public int? TrainId { get; set; }
        public bool IsUsed { get; set; }
        public string Description { get; set; }

        public int NumPlaces { get; set; }

        


    }
}
