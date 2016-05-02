using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class PontuacaoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Pontuacao
        public ActionResult Cadastrar()
        {
            CarregarUsuarios();
            return View();
        }

        private void CarregarUsuarios()
        {
            var lista = _unit.UsuarioRepository.Listar();
            ViewBag.Usuarios = new SelectList(lista, "UsuarioId", "Descricao");
        }

        [HttpPost]
        public ActionResult Cadastrar(Pontuacao pontuacao)
        {
            _unit.PontuacaoRepository.Cadastrar(pontuacao);
            _unit.Save();

            return View();
        }

        public ActionResult Listar()
        {
            return View(_unit.PontuacaoRepository.Listar());
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var pontuacao = _unit.PontuacaoRepository.BuscarPorUsuario(id);
            return View(pontuacao);
        }

        [HttpPost]
        public ActionResult Editar(Pontuacao pontuacao)
        {
            _unit.PontuacaoRepository.Atualizar(pontuacao);
            _unit.Save();
            TempData["msg"] = "Atualizado!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(int usuarioId)
        {
            var lista = _unit.PontuacaoRepository.BuscarPorUsuario(usuarioId);
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}