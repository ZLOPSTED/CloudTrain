using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudTrain.Controllers
{
    [Authorize(Roles = "logistician")]

    public class LogisticianController : Controller
    {
        //на список маршрутов добавить список поездов и кнопку добавить и на список вагонов тоже потом показ отсортированых по дате маршрутов
        
        public ActionResult Index()
        {
            return View();
        }
    }
}