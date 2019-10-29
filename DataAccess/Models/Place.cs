using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Carriage Carriage { get; set; }
        public int CarriageId { get; set; }
        public bool IsFree { get; set; }
        public User User { get; set; }
        
       
    }
}