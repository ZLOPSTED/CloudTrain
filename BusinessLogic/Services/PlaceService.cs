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
    public class PlaceService: IPlaceService
    {
        private IUnitOfWork _Database { get; set; }

        public PlaceService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakePlace(PlaceDTO placeDto)
        {

            Place place = new Place
            {
                Number = placeDto.Number,
                CarriageId = placeDto.CarriageId
            };

            _Database.Places.Create(place);
            _Database.Save();
        }

        public IEnumerable<PlaceDTO> GetPlaces()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(_Database.Places.GetAll());
        }

        public PlaceDTO GetPlace(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id места", "");
            }
               
            var place = _Database.Places.Get(id.Value);
            if (place == null)
            {
                throw new ValidationException("место не найдено", "");
            }
               

            return new PlaceDTO { Id = place.Id, Number = place.Number, CarriageId=place.CarriageId };
        }

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
