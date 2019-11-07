using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class RouteDate
    {
        
        public Route Route{ get; set; }

       
        public int RouteId { get; set; }

        [Key, Column(Order = 1)]
        public DateTime Date { get; set; }
    }
}