using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
     public interface ITrainService
    {
        void MakeTrain(TrainDTO trainDto);
        TrainDTO GetTrain(int? id);
        IEnumerable<TrainDTO> GetTrains();
        void Dispose();
    }
}
