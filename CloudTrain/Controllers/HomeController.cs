using CloudTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.DTO;
using AutoMapper;


namespace CloudTrain.Controllers
{
    public class HomeController : Controller
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();



        private IStationService _stationService;
        private ITrainService _trainService;
        private ICarriageService _carriageService;
        private IRouteService _routeService;
        private IRouteStationService _routeStationService;

        public HomeController(IStationService stationservice, IRouteService routeService, ITrainService trainservice, ICarriageService carriageservice, IRouteStationService routeStationService)
        {
            _stationService = stationservice;
            _trainService = trainservice;
            _carriageService = carriageservice;
            _routeService = routeService;
            _routeStationService = routeStationService;
        }

        [HttpGet]
        public ActionResult ShowRoutes()
        {
            IEnumerable<RouteDTO> routeDtos = _routeService.GetRoutes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDTO, RouteViewModel>()).CreateMapper();
            var routes = mapper.Map<IEnumerable<RouteDTO>, List<RouteViewModel>>(routeDtos);



            return View(routes);
        }



        public ActionResult RouteDetails(int? id)
        {
            if(id == 0)
            {
                throw new ValidationException("Не установлено id пути", "");
            }

            var route = _routeService.GetRoute(id);
            /*            var stations = _stationService.GetStations();
                        var s = from st in stations
                                where (from u in st.Routes
                                                  where u.RouteId == route.Id
                                                  select u.RouteId).Contains(route.Id)
                                select st;
            */
            var routeStations = _routeStationService.GetRouteStationsByRoute(route.Id);
            
           


            IEnumerable<RouteDTO> routeDtos = _routeService.GetRoutes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDTO, RouteViewModel>()).CreateMapper();
            var routeView = mapper.Map<RouteDTO, RouteViewModel>(route);

            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<RouteStationDTO, RouteStationViewModel>()).CreateMapper();
            var stationsView = mapper2.Map<IEnumerable<RouteStationDTO>,List< RouteStationViewModel>>(routeStations);

            ViewBag.Stations = stationsView;


            return View(routeView);

            

        }
    }
}

/* public string Index()
        {

            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = "Ваш логин: " + User.Identity.Name;
            }

            return result;

        }*/


//    logger.Info("Go to Contact");

