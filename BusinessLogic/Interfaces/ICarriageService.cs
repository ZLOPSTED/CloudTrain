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

        IEnumerable<CarriageDTO> GetFreeCarriages();
        void MakeCarriage(CarriageDTO carriageDto);
        CarriageDTO GetCarriage(int? id);
        IEnumerable<CarriageDTO> GetCarriages();

        IEnumerable<CarriageDTO> GetCarriagesWithoutTrain();
        void EditCarriage(CarriageDTO carriageDto);
        void DeleteCarriage(int id);
        void Dispose();
    }
}
