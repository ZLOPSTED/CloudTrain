
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Models
{
    public class User : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public ICollection<UserPlace> Places { get; set; }
        public User()
        {
            Places = new List<UserPlace>();
        }
       
    }
}