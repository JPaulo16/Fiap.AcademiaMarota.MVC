using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
    }
}