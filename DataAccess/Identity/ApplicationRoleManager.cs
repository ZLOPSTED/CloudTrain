using DataAccess;
using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Identity
{
    public class ApplicationRoleManager : RoleManager<Role>
    {
       
        
        public ApplicationRoleManager(RoleStore<Role> store)
                    : base(store)
        {
           
        }
       /* public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                IOwinContext context)
        {
            return new ApplicationRoleManager(new
                    RoleStore<Role>(context.Get<RouteContext>()));
        }*/
    }
}