using System;

namespace CloudTrain.Models
{
    class Carriage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }   //coupe, reserved seat, general
    }
}