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
                Name = carriageDto.Name,
                Type= carriageDto.Type,
                Description=carriageDto.Description
            };
            _Database.Carriages.Create(carriage);
            

            for (int i=1; i<= carriageDto.NumPlaces; i++)
            {
                Place place = new Place { CarriageId = carriage.Id, Number = i };
                _Database.Places.Create(place);
            }

            _Database.Save();

        }

        public IEnumerable<CarriageDTO> GetCarriagesWithoutTrain()
        {
            var carriagesWithoutTrain = from a in _Database.Carriages.GetAll()
                                     where a.TrainId == null
                                     select a;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Carriage, CarriageDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Carriage>, List<CarriageDTO>>(carriagesWithoutTrain);
        }



        public IEnumerable<CarriageDTO> GetCarriages()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Carriage, CarriageDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Carriage>, List<CarriageDTO>>(_Database.Carriages.GetAll());
        }

        public IEnumerable<CarriageDTO> GetFreeCarriages()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Carriage, CarriageDTO>()).CreateMapper();
            var items =mapper.Map<IEnumerable<Carriage>, List<CarriageDTO>>(_Database.Carriages.GetAll());
            return from a in items
                   where a.TrainId == null 
                   select a;
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
                

            return new CarriageDTO { Id = carriage.Id, Number=carriage.Number, Description=carriage.Description, TrainId=carriage.TrainId, Type=carriage.Type, Name=carriage.Name};
        }




        public void EditCarriage(CarriageDTO carriageDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarriageDTO, Carriage>()).CreateMapper();
            var item = mapper.Map<CarriageDTO, Carriage>(carriageDto);
            _Database.Carriages.Update(item);
        }


        public void DeleteCarriage(int id)
        {
            _Database.Carriages.Delete(id);
        }



        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
