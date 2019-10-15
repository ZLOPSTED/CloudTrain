using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class RouteContext: DbContext
    {
        public RouteContext() : base("DbConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RouteContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<RouteContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways< RouteContext > ());

        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Route> Routes{ get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<UserPlace> UserPlaces { get; set; }
        public DbSet<PurchasedPlaces> PurchasedPlaces { get; set; }
        public DbSet<RouteTrain> RouteTrains{ get; set; }
    }
}