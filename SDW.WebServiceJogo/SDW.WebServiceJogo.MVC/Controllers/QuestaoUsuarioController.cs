using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class QuestaoUsuarioController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: QuestaoUsuario
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(QuestaoUsuario questaoUsuario)
        {
            _unit.QuestaoUsuarioRepository.Cadastrar(questaoUsuario);
            _unit.Save();
            TempData["msg"] = "Cadastrado com Sucesso!";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.QuestaoUsuarioRepository.Listar());
        }
                
        [HttpGet]
        public ActionResult Buscar(int usuario)
        {
            //Busca as viagens pelo destino
            var lista = _unit.QuestaoUsuarioRepository.BuscarPorUsuario(usuario);
            //Retorna para a página Listar com a lista preenchida
            return View("Listar",lista);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}