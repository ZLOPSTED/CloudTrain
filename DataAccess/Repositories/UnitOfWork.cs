using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private DbContext _db;

        private GenericRepository<Route> _routeRepository;

        private GenericRepository<Train> _trainRepository;

        private GenericRepository<Carriage> _carriageRepository;

        private GenericRepository<Place> _placeRepository;

        private GenericRepository<Station> _stationRepository;


        public UnitOfWork()
        {
            _db = new RouteContext();
            _routeRepository = new GenericRepository<Route>(_db);
            _trainRepository = new GenericRepository<Train>(_db);
            _carriageRepository = new GenericRepository<Carriage>(_db);
            _placeRepository = new GenericRepository<Place>(_db); 
            _stationRepository = new GenericRepository<Station>(_db);
        }
        public IRepository<Route> Routes
        {
            get
            {
                if (_routeRepository == null)
                    _routeRepository = new GenericRepository<Route>(_db);
                return _routeRepository;
            }
        }

        public IRepository<Train> Trains
        {
            get
            {
                if (_trainRepository == null)
                    _trainRepository = new GenericRepository<Train>(_db);
                return _trainRepository;
            }
        }

        public IRepository<Carriage> Carriages
        {
            get
            {
                if (_carriageRepository == null)
                    _carriageRepository = new GenericRepository<Carriage>(_db);
                return _carriageRepository;
            }
        }

        public IRepository<Place> Places
        {
            get
            {
                if (_placeRepository == null)
                    _placeRepository = new GenericRepository<Place>(_db);
                return _placeRepository;
            }
        }

        public IRepository<Station> Stations
        {
            get
            {
                if (_stationRepository == null)
                    _stationRepository = new GenericRepository<Station>(_db);
                return _stationRepository;
            }
        }



        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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
