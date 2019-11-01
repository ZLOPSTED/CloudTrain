using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    interface IPlaceService
    {
        void MakePlace(PlaceDTO placeDto);
        PlaceDTO GetPlace(int? id);
        IEnumerable<PlaceDTO> GetPlaces();
        void Dispose();
    }
}
