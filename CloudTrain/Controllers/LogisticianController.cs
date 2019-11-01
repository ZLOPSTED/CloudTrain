using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudTrain.Controllers
{
    [Authorize(Roles = "logistian")]
    public class LogisticianController : Controller
    {
        // GET: Logistician
        public ActionResult Index()
        {
            return View();
        }
    }
}