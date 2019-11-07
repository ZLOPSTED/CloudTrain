using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Infrastructure;

namespace BusinessLogic.Services
{
    public class RouteDateService: IRouteDateService
    {
        private IUnitOfWork _Database { get; set; }

        public RouteDateService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeRouteDate(RouteDateDTO routeDateDto)
        {

            RouteDate routeDate = new RouteDate
            {
                RouteId = routeDateDto.RouteId,
                Date = routeDateDto.Date
            };

            _Database.RouteDates.Create(routeDate);
            _Database.Save();
        }

        public IEnumerable<RouteDateDTO> GetRouteDates()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDate, RouteDateDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<RouteDate>, List<RouteDateDTO>>(_Database.RouteDates.GetAll());
        }



        public IEnumerable<RouteDTO> Search(SearchRouteDateDTO search)
        {
            var routeDatesByDate = from i in _Database.RouteDates.GetAll()
                                  where i.Date == search.RouteDate
                                  select i;

            List<Route> routes = new List<Route>();
            var allroutes = _Database.Routes.GetAll();
            List<Route> routesByStation = new List<Route>();

            foreach (var a in routeDatesByDate)
            {
                foreach(var b in allroutes)
                {
                    if(a.RouteId == b.Id)
                    {
                        routes.Add(b);
                    }
                }
            }


            
            foreach(var t in routes)
            {
                var m = from c in _Database.RouteStations.GetAll()
                        where c.RouteId == t.Id
                        select c;
                t.RouteStations = m as List<RouteStation>;

                if((m.FirstOrDefault(item => item.StationId == search.StartStationId) != null) && (m.FirstOrDefault(item => item.StationId == search.FinishStationId) != null)){
                    routesByStation.Add(t);
                }
            }



            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Route, RouteDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Route>, List<RouteDTO>>(routesByStation);
            

                                
        }




        public RouteDateDTO GetRouteDate(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id маршрута" , "");
            }

            var routeDate = _Database.RouteDates.Get(id.Value);
            if (routeDate == null)
            {
                throw new ValidationException("маршрут с датой не найден", "");
            }


            return new RouteDateDTO { RouteId= routeDate.RouteId , Date=routeDate.Date };
        }


        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
