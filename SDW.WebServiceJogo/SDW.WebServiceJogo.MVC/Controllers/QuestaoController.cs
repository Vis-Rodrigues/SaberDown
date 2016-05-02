using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class QuestaoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Questao
        public ActionResult Cadastrar()
        {
            CarregarCategoria();
            return View();
        }

        private void CarregarCategoria()
        {
            var lista = _unit.CategoriaRepository.Listar();
            ViewBag.categorias = new SelectList(lista, "CategoriaId", "Descricao");
        }

        [HttpPost]
        public ActionResult Cadastrar(Questao questao)
        {
            _unit.QuestaoRepository.Cadastrar(questao);
            _unit.Save();
            TempData["msg"] = "Questão Cadastrada com Sucesso";

            CarregarCategoria();
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.QuestaoRepository.Listar());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}