using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class VestuarioController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Vestuario
        public ActionResult Cadastrar()
        {
            CarregarClassificacao();
            return View();
        }

        private void CarregarClassificacao()
        {
            var lista = _unit.ClassificacaoRepository.Listar();
            ViewBag.classificacoes = new SelectList(lista, "ClassificacaoVestuarioId", "Descricao");
        }

        [HttpPost]
        public ActionResult Cadastrar(Vestuario vestuario)
        {
            _unit.VestuarioRepository.Cadastrar(vestuario);
            _unit.Save();
            TempData["msg"] = "Vestimenta cadastrada com sucesso";

            CarregarClassificacao();
            return RedirectToAction("Listar");

        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.VestuarioRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Buscar(int vestId)
        {
            var lista = _unit.VestuarioRepository.BuscarPorCodigo(vestId);
            return View("Listar", lista);
        }

        [HttpGet]
        public ActionResult BuscarPorClassificacao(int classificacaoId)
        {
            var lista = _unit.VestuarioRepository.BuscarPorClassificacao(classificacaoId);
            return View("Listar", lista);
        }

    }
}