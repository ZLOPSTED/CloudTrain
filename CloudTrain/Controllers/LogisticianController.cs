using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using CloudTrain.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudTrain.Controllers
{
    //[Authorize(Roles = "logistician")]
    public class LogisticianController : Controller
    {
        //на список маршрутов добавить список поездов и кнопку добавить и на список вагонов тоже потом показ отсортированых по дате маршрутов



     
        private ITrainService _trainService;
        private ICarriageService _carriageService;
        private IRouteService _routeService;
        private IRouteDateService _routeDateService;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public LogisticianController( IRouteService routeService, ITrainService trainservice, ICarriageService carriageservice, IRouteDateService routedateservice)
        {
           
            _trainService = trainservice;
            _carriageService = carriageservice;
            _routeService = routeService;
            _routeDateService = routedateservice;

        }


        


        [HttpGet]
        public ActionResult AppointCarriageToTrain(int id)
        {
            
            
            SelectList trains = new SelectList(_trainService.GetTrains(), "Id", "Name");
            ViewBag.Trains = trains;
            var carriageDto = _carriageService.GetCarriage(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarriageDTO, CarriageViewModel>()).CreateMapper();
            var carriageView = mapper.Map<CarriageDTO, CarriageViewModel>(carriageDto);
            return View(carriageView);
           
        }

        [HttpPost]
        public ActionResult AppointCarriageToTrain(CarriageViewModel carriageView)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarriageViewModel, CarriageDTO>()).CreateMapper();
            var carriageDto = mapper.Map<CarriageViewModel, CarriageDTO>(carriageView);
            _carriageService.EditCarriage(carriageDto);
            return RedirectToAction("ShowCarriages", "Admin");
            
        }



        [HttpGet]
        public ActionResult CreateRouteDate()
        {

            SelectList routes = new SelectList(_routeService.GetRoutes(), "Id", "Name");
            ViewBag.Routes = routes;
           
            return View();

        }

        [HttpPost]
        public ActionResult CreateRouteDate(RouteDateViewModel routeDateView)
        {

            var routeDateDTO = new RouteDateDTO { RouteId = routeDateView.RouteId , Date= routeDateView.Date };

            _routeDateService.MakeRouteDate(routeDateDTO);
            return Content("Вы успешно создали маршрут");

        }

        [HttpGet]
        public ActionResult ShowRouteDate()
        {

            IEnumerable<RouteDateDTO> routeDateDtos = _routeDateService.GetRouteDates();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDateDTO, RouteDateViewModel>()).CreateMapper();
            var routes = mapper.Map<IEnumerable<RouteDateDTO>, List<RouteDateViewModel>>(routeDateDtos);
            return View(routes);
           

        }


        [HttpGet]
        public ActionResult AppointTrainToRoute(int id)
        {
            

            SelectList trains = new SelectList(_trainService.GetTrains(), "Id", "Name");
            ViewBag.Trains = trains;
            var routeDto = _routeService.GetRoute(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDTO, RouteViewModel>()).CreateMapper();
            var routeView = mapper.Map<RouteDTO, RouteViewModel>(routeDto);
            return View(routeView);

        }

        [HttpPost]
        public ActionResult AppointTrainToRoute(RouteViewModel routeViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteViewModel, RouteDTO>()).CreateMapper();
            var routeDto = mapper.Map<RouteViewModel, RouteDTO>(routeViewModel);
            _routeService.EditRoute(routeDto);
            return RedirectToAction("ShowRoutes", "Admin");

        }

      


        public ActionResult Index()
        {
            return View();
        }
    }
}