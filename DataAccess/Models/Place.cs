using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Place
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Carriage Carriage { get; set; }
        public int CarriageId { get; set; }
        
        
        
       
    }
}