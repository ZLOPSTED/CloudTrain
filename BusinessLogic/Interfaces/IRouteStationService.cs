using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRouteStationService
    {
        void MakeRouteStation(RouteStationDTO routeStationDto );
        RouteStationDTO GetRouteStation(int? id);
        IEnumerable<RouteStationDTO> GetRouteStations();

        IEnumerable<RouteStationDTO> GetRouteStationsByRoute(int id);
        void DeleteRouteStation(int id);
        void Dispose();
    }
}
