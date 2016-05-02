using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class GuardaRoupaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: GuardaRoupa
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(GuardaRoupa guardaRoupa)
        {
            _unit.GuardaRoupaRepository.Cadastrar(guardaRoupa);
            _unit.Save();
            TempData["msg"] = "Guarda Roupa Cadastrado!";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.GuardaRoupaRepository.Listar());
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var guarda = _unit.GuardaRoupaRepository.BuscarPorCodigo(id);
            return View(guarda);
        }

        [HttpPost]
        public ActionResult Editar(GuardaRoupa guardaRoupa)
        {
            _unit.GuardaRoupaRepository.Atualizar(guardaRoupa);
            _unit.Save();
            TempData["msg"] = "Guarda Roupa Atualizado com Sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(int usuarioId)
        {
            var lista = _unit.GuardaRoupaRepository.BuscarPorUsuario(usuarioId);
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}