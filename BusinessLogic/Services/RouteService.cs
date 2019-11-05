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
    public class RouteService: IRouteService
    {
        private IUnitOfWork _Database { get; set; }

        public RouteService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeRoute(RouteDTO routeDto)
        {

           


            Route route = new Route
            {

                Description = routeDto.Description,
                CoupeFare = routeDto.CoupeFare,
                ReservedSeatFare = routeDto.ReservedSeatFare,
                GeneralFare = routeDto.GeneralFare,
                Name= routeDto.Name

            };


          

            _Database.Routes.Create(route);
            _Database.Save();
        }

        public IEnumerable<RouteDTO> GetRoutes()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Route, RouteDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Route>, List<RouteDTO>>(_Database.Routes.GetAll());
        }








        public RouteDTO GetRoute(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id маршрута", "");
            }
              
            var route = _Database.Routes.Get(id.Value);
            if (route == null)
            {
                throw new ValidationException("маршрут не найден", "");
            }
               

            return new RouteDTO { Description = route.Description, Id = route.Id, CoupeFare=route.CoupeFare, GeneralFare=route.GeneralFare, ReservedSeatFare= route.ReservedSeatFare, Name=route.Name };
        }


        public void DeleteRoute(int id)
        {
            _Database.Routes.Delete(id);
        }

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}

