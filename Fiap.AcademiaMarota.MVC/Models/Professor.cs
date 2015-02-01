using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public string Email { get; set; }

        #region Relações
        public virtual ICollection<Modalidade> Modalidades { get; set; }
        //criar um modalidadeid
        public int EnderecoId { get; set; }
        public virtual Endereco EnderecoContato { get; set; }
        #endregion
    }
}