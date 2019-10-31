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



        IRouteService routeService;
        public HomeController(IRouteService serv)
        {
            routeService = serv;
        }

       

       
        public ActionResult Index()
        {
            IEnumerable<RouteDTO> routeDtos = routeService.GetRoutes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RouteDTO, RouteViewModel>()).CreateMapper();
            var routes = mapper.Map<IEnumerable<RouteDTO>, List<RouteViewModel>>(routeDtos);
            return View(routes);
        }


        [HttpGet]
        public ActionResult MakeRoute()
        {
            return View();
        }



        [HttpPost]
        public ActionResult MakeRoute(RouteViewModel route)
        {
            try
            {
                var routeDto = new RouteDTO { Description = route.Description, CoupeFare =route.CoupeFare, GeneralFare=route.GeneralFare, ReservedSeatFare=route.ReservedSeatFare };
                routeService.MakeRoute(routeDto);
                return Content("Вы успешно создали маршрут");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(route);
        }
        protected override void Dispose(bool disposing)
        {
            routeService.Dispose();
            base.Dispose(disposing);
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

