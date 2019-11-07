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
        private IRouteDateService _routeDateService;
        private IRouteStationService _routeStationService;
       

        public HomeController(IStationService stationservice, IRouteService routeService, ITrainService trainservice, IRouteDateService routedateservice, ICarriageService carriageservice, IRouteStationService routestationservice)
        {
            _routeDateService = routedateservice;
            _stationService = stationservice;
            _trainService = trainservice;
            _carriageService = carriageservice;
            _routeService = routeService;
            _routeStationService = routestationservice;
           
        }

        [HttpGet]
        public ActionResult ShowRouteDates()
        {
            SelectList stations = new SelectList(_stationService.GetStations(), "Id", "Name");
            ViewBag.Stations = stations;
            return View();
        }



        [HttpPost]
        public ActionResult ShowRouteDates(SearchRouteDateViewModel searchRouteDateViewModel)
        {

            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<CarriageDTO, CarriageViewModel>();
                cfg.CreateMap<TrainDTO, TrainViewModel>(); cfg.CreateMap<RouteDateDTO, RouteDateViewModel>(); cfg.CreateMap<RouteDTO, RouteViewModel>(); cfg.CreateMap<SearchRouteDateViewModel, SearchRouteDateDTO>();
                cfg.CreateMap<RouteStationDTO, RouteStationViewModel>(); 
            }).CreateMapper();

            var item = mapper.Map<SearchRouteDateViewModel, SearchRouteDateDTO>(searchRouteDateViewModel);

            SelectList stations = new SelectList(_stationService.GetStations(), "Id", "Name");
            ViewBag.Stations = stations;

            ViewBag.RouteStations = mapper.Map<IEnumerable<RouteStationDTO>, List<RouteStationViewModel>>(_routeStationService.GetRouteStations());
            ViewBag.Trains = mapper.Map<IEnumerable<TrainDTO>, List<TrainViewModel>>(_trainService.GetTrains());
            ViewBag.Carriages = mapper.Map<IEnumerable<CarriageDTO>, List<CarriageViewModel>>(_carriageService.GetCarriages());
            ViewBag.Routes = mapper.Map<IEnumerable<RouteDTO>, List<RouteViewModel>>(_routeDateService.Search(item));

            return View(searchRouteDateViewModel);
        }




      

        public ActionResult RouteDetails(int? id)
        {
            if(id == 0)
            {
                throw new ValidationException("Не установлено id пути", "");
            }

            var route = _routeService.GetRoute(id);

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

