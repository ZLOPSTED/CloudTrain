using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private RouteContext db;

        private RouteRepository routeRepository;

        public UnitOfWork()
        {
            db = new RouteContext();
            routeRepository = new RouteRepository(db);
        }
        public IRepository<Route> Routes
        {
            get
            {
                if (routeRepository == null)
                    routeRepository = new RouteRepository(db);
                return routeRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
