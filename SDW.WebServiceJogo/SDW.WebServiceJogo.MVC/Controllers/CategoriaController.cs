using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class CategoriaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Categoria
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Categoria categoria)
        {
            _unit.CategoriaRepository.Cadastrar(categoria);
            _unit.Save();
            TempData["msg"] = "Cadastrado!";
            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            return View(_unit.CategoriaRepository.Listar());
        }

    }
}