using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banco.Controllers
{
    public class CloseController : Controller
    {
        public ActionResult Logoff()
        {
            Session["user"] = null;
            return RedirectToAction("Index","Access");
        }
    }
}