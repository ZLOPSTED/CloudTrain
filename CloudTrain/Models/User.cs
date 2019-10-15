using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class User
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public ICollection<UserPlace> Places { get; set; }
        public User()
        {
            Places = new List<UserPlace>();
        }
    }
}