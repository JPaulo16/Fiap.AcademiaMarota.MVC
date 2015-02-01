using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Fiap.AcademiaMarota.MVC.Models;

namespace Fiap.AcademiaMarota.MVC.DataAccess
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
    }
}