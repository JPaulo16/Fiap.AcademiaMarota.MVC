using Fiap.AcademiaMarota.MVC.Models;
using Fiap.AcademiaMarota.MVC.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.AcademiaMarota.MVC.Controllers
{
    public class ModalidadeController : Controller
    {
        private UnitOfWork _unit;
        public ModalidadeController()
        {
            _unit = new UnitOfWork();
        }
        private void CarregarModalidades()
        {
            ViewBag.Modalidades = _unit.ModalidadeRepository.List();
        }


        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregarModalidades();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Modalidade modalidade)
        {
            _unit.ModalidadeRepository.Add(modalidade);
            _unit.Save();
            TempData["msg"] = "Modalidade Cadastrada";
            CarregarModalidades();
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
	}
}