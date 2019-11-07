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
    public class UserPlaceService: IUserPlaceService
    {
        private IUnitOfWork _Database { get; set; }

        public UserPlaceService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeUserPlace(UserPlaceDTO userPlaceDto)
        {

            UserPlace userPlace = new UserPlace 
            {
                UserId = userPlaceDto.UserId,
                Child = userPlaceDto.Child,
                ClientName = userPlaceDto.ClientName,
                Drink = userPlaceDto.Drink,
                PlaceId = userPlaceDto.PlaceId,
                TimeFinishTrip = userPlaceDto.TimeFinishTrip,
                TimeStartTrip = userPlaceDto.TimeStartTrip,
                WithBed = userPlaceDto.WithBed
                

             };

            _Database.UserPlaces.Create(userPlace);
            _Database.Save();
        }

        public IEnumerable<UserPlaceDTO> GetUserPlaces()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserPlace, UserPlaceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserPlace>, List<UserPlaceDTO>>(_Database.UserPlaces.GetAll());
        }

        public UserPlaceDTO GeUserPlace(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id места пользователя", "");
            }

            var userPlace = _Database.UserPlaces.Get(id.Value);
            if (userPlace == null)
            {
                throw new ValidationException("место пользователя не найдено", "");
            }


            return new UserPlaceDTO { Child =  userPlace.Child , WithBed = userPlace.WithBed, TimeStartTrip= userPlace.TimeStartTrip, TimeFinishTrip= userPlace.TimeFinishTrip , PlaceId = userPlace.PlaceId , Drink= userPlace.Drink , ClientName= userPlace.ClientName , UserId= userPlace.UserId};
        }



      

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
