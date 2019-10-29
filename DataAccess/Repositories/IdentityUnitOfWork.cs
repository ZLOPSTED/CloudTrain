using DataAccess.Identity;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private RouteContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        

        public IdentityUnitOfWork(string connectionString)
        {
            db = new RouteContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<User>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<Role>(db));
           
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    
                }
                this.disposed = true;
            }
        }
    }
}
