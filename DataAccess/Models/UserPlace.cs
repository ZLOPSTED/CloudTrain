using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class UserPlace
    {
        public User User { get; set; }

        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public DateTime TimeStartTrip { get; set; }
        public DateTime TimeFinishTrip { get; set; }
        public string ClientName { get; set; }
        public bool WithBed { get; set; }
        public bool  Drink { get; set; }
        public bool  Child { get; set; }


}
}