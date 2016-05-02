using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class ClassificacaoController : Controller
    {
       
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ClassificacaoVestuario classificacaoVestuario)
        {
            _unit.ClassificacaoRepository.Cadastrar(classificacaoVestuario);
            _unit.Save();
            TempData["msg"] = "Cadastrado!";
            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            return View(_unit.ClassificacaoRepository.Listar());
        }

    }
}