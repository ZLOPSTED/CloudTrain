using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserPlaceService
    {
       void MakeUserPlace(UserPlaceDTO userPlaceDto);
       UserPlaceDTO GeUserPlace(int? id);
       IEnumerable<UserPlaceDTO> GetUserPlaces();

        void Dispose();
    }
}
