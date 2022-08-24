using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunilMVC.Models;
using System.Net;

namespace FunilMVC.Controllers
{
    public class EtapaController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bd.ETAPA.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAPA eta = bd.ETAPA.Find(id);
            if (eta == null)
            {
                return HttpNotFound();
            }
            return View(eta);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ETAPA eta = bd.ETAPA.ToList().Where(x => x.ETAID == id).First();
            return View(eta);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int? id)
        {
            ETAPA eta = bd.ETAPA.ToList().Where(x => x.ETAID == id).First();

            bd.ETAPA.Remove(eta);

            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Erro", "Home");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string descricao, int seq)
        {
            ETAPA eta = new ETAPA();

            eta.ETADESCRICACAO = descricao;
            eta.ETASEQ = seq;

            bd.ETAPA.Add(eta);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAPA eta = bd.ETAPA.Find(id);
            if (eta == null)
            {
                return HttpNotFound();
            }
            return View(eta);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string descricao, int seq)
        {
            ETAPA eta = bd.ETAPA.ToList().Where(x => x.ETAID == id).First();

            eta.ETADESCRICACAO = descricao;
            eta.ETASEQ = seq;

            bd.Entry(eta).State = System.Data.EntityState.Modified;

            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Erro", "Home");
            }

            return RedirectToAction("Index");
        }
    }
}