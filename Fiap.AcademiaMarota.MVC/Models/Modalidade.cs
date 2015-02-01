using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }

    }
}