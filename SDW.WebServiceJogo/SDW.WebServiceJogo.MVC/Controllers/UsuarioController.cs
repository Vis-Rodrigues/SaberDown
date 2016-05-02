using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class UsuarioController : Controller
    {

        private UnitOfWork _unit = new UnitOfWork();

        // GET: Usuario
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            _unit.UsuarioRepository.Cadastrar(usuario);
            _unit.Save();

            TempData["msg"] = "Usuário Cadastrado com Sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {            
            return View(_unit.UsuarioRepository.Listar());
        }

        [HttpGet]
        public ActionResult Buscar(String usuario, String senha)
        {
            var lista = _unit.UsuarioRepository.BuscarPorUsuarioSenha(usuario, senha);
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}