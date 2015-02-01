using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC.Models
{
    [Table("TAB_ALUNO")]
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        public bool Especial { get; set; }
        [Display(Name = "Observação")]
        public string Obs { get; set; }

        #region Relações
        public int? ModalidadeId { get; set; }
        public virtual Modalidade Modalidade { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco EnderecoCobranca { get; set; }
        #endregion

    }
}