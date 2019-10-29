using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Role : IdentityRole
    {
        public Role() { }

        public string Description { get; set; }
    }
}