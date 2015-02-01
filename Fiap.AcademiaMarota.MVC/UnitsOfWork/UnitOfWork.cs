using Fiap.AcademiaMarota.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fiap.AcademiaMarota.MVC.Repositories;
using Fiap.AcademiaMarota.MVC.Models;

namespace Fiap.AcademiaMarota.MVC.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private AcademiaContext _context = new AcademiaContext();
        #region Aluno
        private IGenericRepository<Aluno> _alunoRepository;
        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
        }
        #endregion

        #region Professor
        private IGenericRepository<Professor> _professorRepository;
        public IGenericRepository<Professor> ProfessorRepository
        {
            get
            {
                if (_professorRepository == null)
                {
                    _professorRepository = new GenericRepository<Professor>(_context);
                }
                return _professorRepository;
            }
        }
        #endregion

        #region Modalidade
        private IGenericRepository<Modalidade> _modalidadeRepository;
        public IGenericRepository<Modalidade> ModalidadeRepository
        {
            get {
                if (_modalidadeRepository == null)
                {
                    _modalidadeRepository = new GenericRepository<Modalidade>(_context);
                }
                return _modalidadeRepository;
            }
        }
        #endregion

        #region Endereco
        private IGenericRepository<Endereco> _enderecoRepository;
        public IGenericRepository<Endereco> EnderecoRepository
        {
            get
            {
                if (_enderecoRepository == null)
                {
                    _enderecoRepository = new GenericRepository<Endereco>(_context);
                }
                return _enderecoRepository;
            }
        }
        #endregion

        public void Save()
        {
            _context.SaveChanges();
        }

        #region LiberaRecurso
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        private void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                _context.Dispose();
            }
            disposed = true;
        }
        #endregion
    }
}