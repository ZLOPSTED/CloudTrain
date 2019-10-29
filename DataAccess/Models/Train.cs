using System;
using System.Collections.Generic;


namespace DataAccess.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Carriage> Carriages { get; set; }

        public Train()
        {
            
            Carriages = new List<Carriage>();
        }
       
       
    }
}