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
    public class AlunoController : Controller
    {
        private UnitOfWork _unit;
        private List<string> _estados;

        public AlunoController()
        {
            _unit = new UnitOfWork();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_unit.AlunoRepository.List());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var viewModel = new AlunoViewModel
            {
                Modalidades = CarregarModalidades(),
                Estados = CarregarEstados()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var aluno = new Aluno
                {
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    DataNascimento = model.DataNascimento,
                    Especial = model.Especial,
                    Obs = model.Obs,
                    ModalidadeId = model.ModalidadeId,
                    EnderecoCobranca = new Endereco
                    {
                        Logradouro = model.Logradouro,
                        Cep = model.Cep,
                        Cidade = model.Cidade,
                        Estado = model.Estado,
                        Celular = model.Celular,
                        Telefone = model.Telefone
                    }
                };
                _unit.AlunoRepository.Add(aluno);
                _unit.Save();
                var viewModel = new AlunoViewModel
                {
                    Mensagem = "Aluno cadastrado com sucesso!",
                    Modalidades = CarregarModalidades(),
                    Estados = CarregarEstados()
                };
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
            return View(_unit.AlunoRepository.List());
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var aluno = _unit.AlunoRepository.SearchById(id);
            var viewModel = new AlunoViewModel
            {
                AlunoId = aluno.AlunoId,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                DataNascimento = aluno.DataNascimento,
                Especial = aluno.Especial,
                Obs = aluno.Obs,
                ModalidadeId = aluno.ModalidadeId,
                EnderecoId = aluno.EnderecoId,
                Logradouro = aluno.EnderecoCobranca.Logradouro,
                Cep = aluno.EnderecoCobranca.Cep,
                Cidade = aluno.EnderecoCobranca.Cidade,
                Estado = aluno.EnderecoCobranca.Estado,
                Celular = aluno.EnderecoCobranca.Celular,
                Telefone = aluno.EnderecoCobranca.Telefone,
                Modalidades = CarregarModalidades(),
                Estados = CarregarEstados()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Editar(AlunoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var aluno = new Aluno
                {
                    AlunoId = model.AlunoId,
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    DataNascimento = model.DataNascimento,
                    Especial = model.Especial,
                    Obs = model.Obs,
                    ModalidadeId = model.ModalidadeId,
                    EnderecoId = model.EnderecoId,
                };
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
                _unit.AlunoRepository.Update(aluno);
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

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            _unit.AlunoRepository.Delete(id);
            _unit.Save();
            return Json(new { msg = "Aluno removido" });
        }

        [HttpGet]
        public ActionResult ValidarCpf(string cpf)
        {
            var alunos =
                _unit.AlunoRepository.SearchFor(c => c.Cpf == cpf);
            return Json(new { valido = !alunos.Any() }
                , JsonRequestBehavior.AllowGet);
        }

        private SelectList CarregarEstados()
        {
            _estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            return new SelectList(_estados);
        }
        private SelectList CarregarModalidades()
        {
            return new SelectList(_unit.ModalidadeRepository.List(), "ModalidadeId", "Titulo");
        }
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}