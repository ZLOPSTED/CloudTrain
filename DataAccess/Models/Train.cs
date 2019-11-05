using System;
using System.Collections.Generic;


namespace DataAccess.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Carriage> Carriages { get; set; }
        public ICollection<Route> Routes { get; set; }

        public Train()
        {
            Routes = new List<Route>();
            Carriages = new List<Carriage>();
        }
       
       
    }
}