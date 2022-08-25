using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunilMVC.Models;
using System.Net;

namespace FunilMVC.Controllers
{
    public class DashboardController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bd.QuantidadeVaiid.ToList());
        }
    }
}