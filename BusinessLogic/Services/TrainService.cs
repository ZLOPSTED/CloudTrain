using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class TrainService: ITrainService
    {
        private IUnitOfWork _Database { get; set; }

        public TrainService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeTrain(TrainDTO trainDto)
        {

           Train train = new Train
           {
                Description = trainDto.Description,
                Name = trainDto.Name
           };

            _Database.Trains.Create(train);
            _Database.Save();
        }

        public IEnumerable<TrainDTO> GetTrains()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Train, TrainDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Train>, List<TrainDTO>>(_Database.Trains.GetAll());
        }

        public TrainDTO GetTrain(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id поезда", "");
            }
               
            var train = _Database.Trains.Get(id.Value);
            if (train == null)
            {
                throw new ValidationException("поезд не найден", "");
            }
                

            return new TrainDTO { Description = train.Description, Id = train.Id, Name=train.Name };
        }

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
