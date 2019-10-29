using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{

    public class RouteRepository : IRepository<Route>
    {

        private RouteContext db;

        public RouteRepository(RouteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Route> GetAll()
        {
            return db.Routes;
        }

        public Route Get(int id)
        {
            return db.Routes.Find(id);
        }

        public void Create(Route route)
        {
            db.Routes.Add(route);
        }

        public void Update(Route route)
        {
            db.Entry(route).State = EntityState.Modified;
        }
        public IEnumerable<Route> Find(Func<Route, Boolean> predicate)
        {
            return db.Routes.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Route route = db.Routes.Find(id);
            if (route != null)
                db.Routes.Remove(route);
        }
    }
}
