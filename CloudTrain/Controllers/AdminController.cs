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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        private IStationService _stationService;
        private ITrainService _trainService;
        private ICarriageService _carriageService;
        private IRouteService _routeService;
        private IRouteStationService _routeStationService;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AdminController(IStationService stationservice, IRouteService routeService, ITrainService trainservice , ICarriageService carriageservice, IRouteStationService routeStationService)
        {
            _stationService = stationservice;
            _trainService = trainservice;
            _carriageService = carriageservice;
            _routeService = routeService;
            _routeStationService = routeStationService;
        }


        [HttpGet]
        public ActionResult ShowStations()
        {
            IEnumerable<StationDTO> stationDtos = _stationService.GetStations();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StationDTO, StationViewModel>()).CreateMapper();
            var routes = mapper.Map<IEnumerable<StationDTO>, List<StationViewModel>>(stationDtos);
            return View(routes);
        }


        [HttpGet]
        public ActionResult CreateStation()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateStation(StationViewModel station)
        {
            try
            {
                var stationDto = new StationDTO { Name = station.Name, Locality=station.Locality, Description=station.Description };
                _stationService.MakeStation(stationDto);
                return Content("Вы успешно создали станцию");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(station);
        }


        public ActionResult DeleteStation(int id)
        {
            _stationService.DeleteStation(id);
            return ShowStations();
        }



        [HttpGet]
        public ActionResult EditStation(int? id)
        {
            StationDTO stationDto = _stationService.GetStation(id);

            if (stationDto == null)
            {
                throw new ValidationException("Не установлено id станции", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap< StationDTO , StationViewModel > ()).CreateMapper();
            var stationView = mapper.Map<StationDTO, StationViewModel>(stationDto);
            return View(stationView);
            
        }


        [HttpPost]
        public ActionResult EditStation(StationViewModel stationView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StationViewModel, StationDTO>()).CreateMapper();
            var stationDto = mapper.Map<StationViewModel, StationDTO>(stationView);
            _stationService.EditStation(stationDto);
            return RedirectToAction("ShowStations");
        }


        [HttpGet]
        public ActionResult ShowTrains() 
        {
            IEnumerable<TrainDTO> trainDtos = _trainService.GetTrains();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TrainDTO, TrainViewModel>()).CreateMapper();
            var trains = mapper.Map<IEnumerable<TrainDTO>, List<TrainViewModel>>(trainDtos);
            return View(trains);
        }


        [HttpGet]
        public ActionResult CreateTrain()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateTrain(TrainViewModel train)
        {
            try
            {
                var trainDto = new TrainDTO { Name=train.Name, Description= train.Description };
                _trainService.MakeTrain(trainDto);
                return Content("Вы успешно создали поезд");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(train);
        }



        public ActionResult DeleteTrain(int id)
        {
            _trainService.DeleteTrain(id);
            return RedirectToAction("ShowTrains");
        }



        [HttpGet]
        public ActionResult EditTrain(int? id)
        {
            TrainDTO trainDto = _trainService.GetTrain(id);

            if (trainDto == null)
            {
                throw new ValidationException("Не установлено id поезда", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TrainDTO, TrainViewModel>()).CreateMapper();
            var trainView = mapper.Map<TrainDTO, TrainViewModel>(trainDto);
            return View(trainView);

        }


        [HttpPost]
        public ActionResult EditTrain(TrainViewModel trainView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TrainViewModel, TrainDTO>()).CreateMapper();
            var trainDto = mapper.Map<TrainViewModel, TrainDTO>(trainView);
            _trainService.EditTrain(trainDto);
            return RedirectToAction("ShowTrains");
        }




        public ActionResult ShowCarriages()
        {
            IEnumerable<CarriageDTO> carriageDtos = _carriageService.GetCarriages();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarriageDTO, CarriageViewModel>()).CreateMapper();
            var trains = mapper.Map<IEnumerable<CarriageDTO>, List<CarriageViewModel>>(carriageDtos);
            return View(trains);
        }


        [HttpGet]
        public ActionResult CreateCarriage()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateCarriage(CarriageViewModel carriage)
        {
            try
            {
                var carriageDto = new CarriageDTO {Name = carriage.Name, Description= carriage.Description,  IsUsed = false , Type= carriage.Type , NumPlaces= carriage.NumPlaces };
                _carriageService.MakeCarriage(carriageDto);
                return Content("Вы успешно создали вагон");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(carriage);
        }



        public ActionResult DeleteCarriage(int id)
        {
            _carriageService.DeleteCarriage(id);
            return RedirectToAction("ShowCarriages");
        }



        [HttpGet]
        public ActionResult EditCarriage(int? id)
        {
            CarriageDTO carriageDto = _carriageService.GetCarriage(id);

            if (carriageDto == null)
            {
                throw new ValidationException("Не установлено id вагона", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarriageDTO, CarriageViewModel>()).CreateMapper();
            var carriageView = mapper.Map<CarriageDTO, CarriageViewModel>(carriageDto);
            return View(carriageView);

        }


        [HttpPost]
        public ActionResult EditCarriage(CarriageViewModel carriageView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarriageViewModel, CarriageDTO>()).CreateMapper();
            var carriageDto = mapper.Map<CarriageViewModel, CarriageDTO>(carriageView);
            _carriageService.EditCarriage(carriageDto);
            return RedirectToAction("ShowCarriages");
        }







        [HttpGet]
        public ActionResult CreateRoute()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoute(RouteViewModel route)
        {
            try
            {

                var routeDto = new RouteDTO { Description = route.Description, CoupeFare = route.CoupeFare, ReservedSeatFare = route.ReservedSeatFare, GeneralFare = route.GeneralFare, Name = route.Name };

                _routeService.MakeRoute(routeDto);
                return Content("Вы успешно создали маршрут");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(route);
        }





        [HttpGet]
        public ActionResult CreateRouteStation(int? id)
        {
            SelectList stations = new SelectList(_stationService.GetStations(), "Id", "Name");
            ViewBag.Stations = stations;
            ViewBag.RouteId = id;


            return View();
        }



        [HttpPost]
        public ActionResult CreateRouteStation(RouteStationViewModel route)
        {
            try
            {
                DateTime xDateDeparture = route.DateDeparture.AddHours(route.TimeDeparture.Hour);
                xDateDeparture= xDateDeparture.AddMinutes(route.TimeDeparture.Minute);

                DateTime xDateArrival= route.DateArrival.AddHours(route.TimeArrival.Hour);
                xDateArrival= xDateArrival.AddMinutes(route.TimeArrival.Minute);

                
                var routeStationDTO = new RouteStationDTO { DateArrival= xDateArrival, DateDeparture= xDateDeparture , RouteId = route.RouteId , StationId= route.StationId, StationName = _stationService.GetStation(route.StationId).Name };

                _routeStationService.MakeRouteStation(routeStationDTO);
                return Content("Вы успешно создали маршрут");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(route);
        }




        [HttpGet]
        public ActionResult ShowRoutes()
        {
            IEnumerable<RouteDTO> routeDtos = _routeService.GetRoutes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDTO, RouteViewModel>()).CreateMapper();
            var routes = mapper.Map<IEnumerable<RouteDTO>, List<RouteViewModel>>(routeDtos);
            return View(routes);
        }


        public ActionResult DeleteRoute(int id)
        {
            _routeService.DeleteRoute(id);
            return RedirectToAction("ShowRoutes");
        }





        protected override void Dispose(bool disposing)
        {
            _stationService.Dispose();
            _trainService.Dispose();
            _carriageService.Dispose();
            base.Dispose(disposing);
        }

    }
}