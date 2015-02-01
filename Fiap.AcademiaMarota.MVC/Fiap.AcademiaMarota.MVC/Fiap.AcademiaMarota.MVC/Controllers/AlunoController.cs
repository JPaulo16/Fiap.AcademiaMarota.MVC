using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.AcademiaMarota.MVC.Models;
using Fiap.AcademiaMarota.MVC.DataAccess;
using System.Data.Entity;

namespace Fiap.AcademiaMarota.MVC.Controllers
{
    public class AlunoController : Controller
    {
        private AcademiaContext _context;
        private List<string> _planos = new List<string>();
        //
        // GET: /Aluno/
        public AlunoController()
        {
            _context = new AcademiaContext();
            _planos.Add("Musculação");
            _planos.Add("Natação");
            _planos.Add("Lutas");
            _planos.Add("Completo");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_context.Alunos.ToList());
        }
        [HttpGet]
        public ActionResult Cadastrar()
        {
            ViewBag.Modalidades = new SelectList(_planos);
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            TempData["msg"] = "Aluno Cadastrado!";
            ViewBag.Modalidades = new SelectList(_planos);
            return View();
        }
        [HttpGet]
        public ActionResult Listar()
        {
            return View(_context.Alunos.ToList());
        }
        public ActionResult Editar(int id)
        {
            var aluno = _context.Alunos.Find(id);
            ViewBag.Modalidades = new SelectList(_planos);
            return View(aluno);
        }
        [HttpGet]
        public ActionResult Editar()
        {
            ViewBag.Modalidades = new SelectList(_planos);
            return View();
        }
        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();
            ViewBag.msg = "Registro atualizado";
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Excluir(int id)
        {
            Aluno aluno = _context.Alunos.Find(id);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            TempData["msg"] = "Aluno Removido";
            return RedirectToAction("Listar");
        }
    }
}