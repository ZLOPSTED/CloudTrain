using System;

namespace CloudTrain.Models
{
    public class Carriage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }   //coupe, reserved seat, general
    }
}