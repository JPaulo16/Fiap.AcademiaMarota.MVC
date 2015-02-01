using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.AcademiaMarota.MVC.ViewModel
{
    public class AlunoViewModel
    {
        public string Mensagem { get; set; }
        public SelectList Modalidades { get; set; }
        public SelectList Estados { get; set; }

        #region Propriedades Aluno
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "Preencha o Nome"), StringLength(30, MinimumLength = 2, ErrorMessage = "Nome deve conter entre 2 e 30 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CPF"), Required(ErrorMessage = "Preencha o CPF"), RegularExpression(@"(^\d{3}\x2E\d{3}\x2E\d{3}\x2D\d{2}$)", ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento"), DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime? DataNascimento { get; set; }
        public bool Especial { get; set; }
        public string Obs { get; set; }

        [Display(Name = "Modalidade"), Required(ErrorMessage = "Selecione uma modalidade")]
        public int? ModalidadeId { get; set; }
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