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
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        private IStationService _stationService;
        private ITrainService _trainService;
        private ICarriageService _carriageService;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AdminController(IStationService stationservice , ITrainService trainservice , ICarriageService carriageservice )
        {
            _stationService = stationservice;
            _trainService = trainservice;
            _carriageService = carriageservice;
        }


        public ActionResult Index()
        {
            IEnumerable<StationDTO> stationDtos = _stationService.GetStations();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StationDTO, StationViewModel>()).CreateMapper();
            var routes = mapper.Map<IEnumerable<StationDTO>, List<StationViewModel>>(stationDtos);
            return View(routes);
        }


        [HttpGet]
        public ActionResult MakeStation()
        {
            return View();
        }



        [HttpPost]
        public ActionResult MakeStation(StationViewModel station)
        {
            try
            {
                var stationDto = new StationDTO { Name = station.Name };
                _stationService.MakeStation(stationDto);
                return Content("Вы успешно создали станцию");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(station);
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