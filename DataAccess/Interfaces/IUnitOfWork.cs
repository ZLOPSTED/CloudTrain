using DataAccess.Identity;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Route>Routes { get; }
        IRepository<Train> Trains { get; }
        IRepository<Carriage> Carriages { get; }
        IRepository<Place> Places { get; }
        IRepository<Station> Stations { get; }


        void Save();
    }
}
