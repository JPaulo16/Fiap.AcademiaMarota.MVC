using Fiap.AcademiaMarota.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.AcademiaMarota.MVC.ViewModel
{
    public class ProfessorViewModel
    {
        public string Mensagem { get; set; }
        public SelectList Estados { get; set; }
        public IEnumerable<Modalidade> ListaModalidade { get; set; }

        #region Propriedades Professor
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome"), StringLength(30, MinimumLength = 2, ErrorMessage = "Nome deve conter entre 2 e 30 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de Admissão"), DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime? DataAdmissao { get; set; }
        [RegularExpression(@"[\w-]+@([\w-]+\.)+[\w-]+", ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        public IEnumerable<Modalidade> Modalidades { get; set; }
        #endregion

        #region Propriedades Endereco
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Preencha o logradouro")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Preencha o CEP")]
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        #endregion
    }
}