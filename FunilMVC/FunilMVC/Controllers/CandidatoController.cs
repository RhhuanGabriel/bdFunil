using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FunilMVC.Models;

namespace FunilMVC.Controllers
{
    public class CandidatoController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bd.CANDIDATO.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATO candidato = bd.CANDIDATO.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nome, string formacao)
        {
            CANDIDATO criar = new CANDIDATO();

            criar.CANNOME = nome;
            criar.CANFORMACAO = formacao;

            bd.CANDIDATO.Add(criar);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            CANDIDATO can = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();
            return View(can);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int? id)
        {
            CANDIDATO can = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();

            bd.CANDIDATO.Remove(can);

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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATO can = bd.CANDIDATO.Find(id);
            if (can == null)
            {
                return HttpNotFound();
            }
            return View(can);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string nome, string formacao)
        {
            CANDIDATO can = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();

            can.CANNOME = nome;
            can.CANFORMACAO = formacao;

            bd.Entry(can).State = System.Data.EntityState.Modified;

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