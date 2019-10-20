using CloudTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;




namespace CloudTrain.Controllers
{
    public class HomeController : Controller
    {
        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        RouteContext db = new RouteContext();


        public string Index()
        {

            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = "Ваш логин: " + User.Identity.Name;
            }

            return result;
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            logger.Info("Go to About");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            logger.Info("Go to Contact");

            return View();
        }
    }
}