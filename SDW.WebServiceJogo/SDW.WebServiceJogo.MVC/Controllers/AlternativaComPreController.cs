using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class AlternativaComPreController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: AlternativaComPre
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(AlternativaComPreMon alternativa)
        {
            _unit.AlternativaComPreRepository.Cadastrar(alternativa);
            _unit.Save();
            TempData["msg"] = "Alternativa Cadastrada com Sucesso!";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.AlternativaComPreRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Buscar(int questaoId)
        {
            var lista = _unit.AlternativaComPreRepository.BuscarPorQuestao(questaoId);
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}