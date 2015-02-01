using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.AcademiaMarota.MVC.Models;
using Fiap.AcademiaMarota.MVC.DataAccess;
using System.Data.Entity;
using Fiap.AcademiaMarota.MVC.UnitsOfWork;
using Fiap.AcademiaMarota.MVC.ViewModel;

namespace Fiap.AcademiaMarota.MVC.Controllers
{
    public class ProfessorController : Controller
    {
        private UnitOfWork _unit;
        private List<string> _estados;
        public ProfessorController()
        {
            _unit = new UnitOfWork();
        }
        [HttpGet]
        public ActionResult Cadastrar()
        {
            var viewModel = new ProfessorViewModel
            {
                Estados = CarregarEstados(),
                ListaModalidade = CarregarModalidades()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Cadastrar(ProfessorViewModel model, List<bool> CheckBox)
        {
            if (ModelState.IsValid)
            {
                

            var viewModel = new ProfessorViewModel
            {
                Mensagem = "Professor cadastrado com sucesso!",
                Estados = CarregarEstados(),
                ListaModalidade = CarregarModalidades()
            };
            var professor = new Professor
            {
                Nome = model.Nome,
                DataAdmissao = model.DataAdmissao,
                Email = model.Email,
                EnderecoContato = new Endereco
                {
                    Logradouro = model.Logradouro,
                    Cep = model.Cep,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    Celular = model.Celular,
                    Telefone = model.Telefone
                }
            };
            professor.Modalidades = new List<Modalidade>();
            for (int i = 0; i < viewModel.ListaModalidade.Count(); i++)
            {
                if (CheckBox[i])
                {
                    CheckBox.RemoveAt(i + 1);
                    var modalidade = _unit.ModalidadeRepository.SearchById(i + 1);
                    professor.Modalidades.Add(modalidade);
                }
            }
            _unit.ProfessorRepository.Add(professor);
            _unit.Save();
            return View(viewModel);
            }
            else
            {
                model.Modalidades = CarregarModalidades();
                model.Estados = CarregarEstados();
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.ProfessorRepository.List());
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var prof = _unit.ProfessorRepository.SearchById(id);
            var viewModel = new ProfessorViewModel
            {
                ProfessorId = prof.ProfessorId,
                Nome = prof.Nome,
                DataAdmissao = prof.DataAdmissao,
                Email = prof.Email,
                Modalidades = new List<Modalidade>(prof.Modalidades),
                EnderecoId = prof.EnderecoId,
                Logradouro = prof.EnderecoContato.Logradouro,
                Cep = prof.EnderecoContato.Cep,
                Cidade = prof.EnderecoContato.Cidade,
                Estado = prof.EnderecoContato.Estado,
                Celular = prof.EnderecoContato.Celular,
                Telefone = prof.EnderecoContato.Telefone,
                Estados = CarregarEstados(),
                ListaModalidade = CarregarModalidades()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Editar(ProfessorViewModel model, List<bool> CheckBox)
        {
            if (ModelState.IsValid)
            {

            var viewModel = new ProfessorViewModel
            {
                Mensagem = "Registro Atualizado!",
                ListaModalidade = CarregarModalidades()
            };
            var professor = new Professor
            {
                ProfessorId = model.ProfessorId,
                Nome = model.Nome,
                DataAdmissao = model.DataAdmissao,
                Email = model.Email,
                EnderecoId = model.EnderecoId
            };
            professor.Modalidades = new List<Modalidade>();
            for (int i = 0; i < viewModel.ListaModalidade.Count(); i++)
            {
                if (CheckBox[i])
                {
                    CheckBox.RemoveAt(i + 1);
                    var modalidade = _unit.ModalidadeRepository.SearchById(i + 1);
                    professor.Modalidades.Add(modalidade);
                }
            }
            var endereco = new Endereco
            {
                EnderecoId = model.EnderecoId,
                Logradouro = model.Logradouro,
                Cep = model.Cep,
                Cidade = model.Cidade,
                Estado = model.Estado,
                Celular = model.Celular,
                Telefone = model.Telefone
            };
            _unit.EnderecoRepository.Update(endereco);
            _unit.ProfessorRepository.Update(professor);
            _unit.Save();
            return RedirectToAction("Listar");
            }
            else
            {
                model.Modalidades = CarregarModalidades();
                model.Estados = CarregarEstados();
                return View(model);
            }
        }
        private IEnumerable<Modalidade> CarregarModalidades()
        {
            return _unit.ModalidadeRepository.List();
        }
        private SelectList CarregarEstados()
        {
            _estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            return new SelectList(_estados);
        }
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}