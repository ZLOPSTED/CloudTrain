using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IStationService
    {
        void MakeStation(StationDTO stationDto);
        StationDTO GetStation(int? id);
        IEnumerable<StationDTO> GetStations();
        void EditStation(StationDTO stationDto);
        void DeleteStation(int id);
        void Dispose();
    }
}
