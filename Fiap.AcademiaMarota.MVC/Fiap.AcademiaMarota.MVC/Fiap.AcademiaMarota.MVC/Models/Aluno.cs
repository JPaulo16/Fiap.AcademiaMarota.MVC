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
        public int ALunoId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Modalidade { get; set; }
        public bool Especial { get; set; }
        [Display(Name = "Observação")]
        public string Obs { get; set; }

    }
}