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
    public class CarriageService: ICarriageService
    {
        private IUnitOfWork _Database { get; set; }

        public CarriageService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeCarriage(CarriageDTO carriageDto)
        {

            Carriage carriage = new Carriage
            {
                Number = carriageDto.Number,
                Type= carriageDto.Type,
                TrainId = carriageDto.TrainId,
                IsUsed= carriageDto.IsUsed,
                Description=carriageDto.Description
            };

            _Database.Carriages.Create(carriage);
            _Database.Save();
        }

        public IEnumerable<CarriageDTO> GetCarriages()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Carriage, CarriageDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Carriage>, List<CarriageDTO>>(_Database.Carriages.GetAll());
        }

        public CarriageDTO GetCarriage(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id вагона", "");
            }
                
            var carriage = _Database.Carriages.Get(id.Value);
            if (carriage == null)
            {
                throw new ValidationException("вагон не найдено", "");
            }
                

            return new CarriageDTO { Id = carriage.Id, Number=carriage.Number, Description=carriage.Description, IsUsed=carriage.IsUsed, TrainId=carriage.TrainId, Type=carriage.Type};
        }

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
