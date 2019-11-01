using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTO;


namespace BusinessLogic.Interfaces
{
    public interface ICarriageService
    {

        void MakeCarriage(CarriageDTO carriageDto);
        CarriageDTO GetCarriage(int? id);
        IEnumerable<CarriageDTO> GetCarriages();
        void Dispose();
    }
}
