using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IRouteService
    {
        void MakeRoute(RouteDTO routeDto);
        RouteDTO GetRoute(int? id);
        IEnumerable<RouteDTO> GetRoutes();
        void Dispose();
    }
}
