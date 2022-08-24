using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FunilMVC.Models;

namespace FunilMVC.Controllers
{
    public class VagaController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bd.VAGA.ToList());
        }

        [HttpGet]
        public ActionResult VagaCandidato(int? id)
        {
            CANDIDATOVAGA candi = new CANDIDATOVAGA();

            try
            {
                return View(bd.GrupoCandidatoVaga.ToList().Where(x => x.CodigoV == id));
            }
            catch
            {
                return RedirectToAction("ErroNull", "Home");
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VAGA vagas = bd.VAGA.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nome, string descricao, string atribuicao, double salario, string requisito, DateTime data)
        {
            VAGA vagaCriar = new VAGA();

            vagaCriar.VAINOME = nome;
            vagaCriar.VAIDESCRICAO = descricao;
            vagaCriar.VAIATRIBUICAO = atribuicao;
            vagaCriar.VAISALARIO = Convert.ToDecimal(salario);
            vagaCriar.VAIREQUISITO = requisito;
            vagaCriar.VAIDATACADASTRO = data;

            bd.VAGA.Add(vagaCriar);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            VAGA vaga = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(vaga);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int? id)
        {
            VAGA vagaDeletar = bd.VAGA.ToList().Where(x => x.VAIID == id).First();

            bd.VAGA.Remove(vagaDeletar);

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
            VAGA vagas = bd.VAGA.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string nome, string descricao, string atribuicao, double salario, string requisito, DateTime data)
        {
            VAGA vagaEdit = bd.VAGA.ToList().Where(x => x.VAIID == id).First();

            vagaEdit.VAINOME = nome;
            vagaEdit.VAIDESCRICAO = descricao;
            vagaEdit.VAIATRIBUICAO = atribuicao;
            vagaEdit.VAISALARIO = Convert.ToDecimal(salario);
            vagaEdit.VAIREQUISITO = requisito;
            vagaEdit.VAIDATACADASTRO = data;

            bd.Entry(vagaEdit).State = System.Data.EntityState.Modified;

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