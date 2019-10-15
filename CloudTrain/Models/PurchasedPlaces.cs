using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class PurchasedPlaces
    {
        public Place Place { get; set; }

        [Key, Column(Order = 0)]
        public int PlaceId { get; set; }

        public User User { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }
    }
}             