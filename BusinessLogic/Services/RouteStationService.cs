using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class RouteStationService: IRouteStationService
    {

        private IUnitOfWork _Database { get; set; }
        

        public RouteStationService(IUnitOfWork uow)
        {
            _Database = uow;
        }
        public void MakeRouteStation(RouteStationDTO routeStationDto)
        {

            RouteStation routeStation = new RouteStation
            {
                TimeArrival =  routeStationDto.TimeArrival,
                TimeDeparture= routeStationDto.TimeDeparture,
                RouteId = routeStationDto.RouteId,
                StationId= routeStationDto.StationId,
               

            };


            _Database.RouteStations.Create(routeStation);
            _Database.Save();
        }

        public IEnumerable<RouteStationDTO> GetRouteStations()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteStation, RouteStationDTO>()).CreateMapper();
            var a = mapper.Map<IEnumerable<RouteStation>, List<RouteStationDTO>>(_Database.RouteStations.GetAll());
            return a;
        }

        public RouteStationDTO GetRouteStation(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id станции");
            }

            var routeStation = _Database.RouteStations.Get(id.Value);
            if (routeStation == null)
            {
                throw new ValidationException("станция не найдена");
            }


            return new RouteStationDTO { TimeDeparture= routeStation.TimeDeparture , TimeArrival = routeStation.TimeArrival, RouteId=routeStation.RouteId, StationId=routeStation.StationId };
        }


        public IEnumerable<RouteStationDTO> GetRouteStationsByRoute(int id)
        {
            var routestations = _Database.RouteStations.GetAll();
            var routes = from r in routestations
                         where r.RouteId == id
                         select r;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteStation, RouteStationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<RouteStation>, List<RouteStationDTO>>(routes);
        }




        public void EditRouteStation(RouteStationDTO routeStationDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteStationDTO, RouteStation>()).CreateMapper();
            var item = mapper.Map<RouteStationDTO, RouteStation>(routeStationDto);
            _Database.RouteStations.Update(item);
        }


        public void DeleteRouteStation(int id)
        {
            _Database.RouteStations.Delete(id);
        }

        public void Dispose()
        {
            _Database.Dispose();
        }

    }
}
