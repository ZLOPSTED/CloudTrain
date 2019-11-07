using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRouteDateService
    {
        void MakeRouteDate(RouteDateDTO routeDateDto);
        RouteDateDTO GetRouteDate(int? id);
        IEnumerable<RouteDateDTO> GetRouteDates();
        IEnumerable<RouteDTO> Search(SearchRouteDateDTO search);
        void Dispose();
    }
}
