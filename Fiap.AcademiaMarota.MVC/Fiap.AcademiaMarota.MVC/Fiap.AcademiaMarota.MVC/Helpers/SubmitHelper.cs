using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC
{
    public static class SubmitHelper
    {
        public static IHtmlString Submit(string valor, string tipo = "btn-primary", string tamanho = "")
        {
            var tag = "";
            if (valor != null)
            {
                tag = String.Format("<input type='submit' value='{0}' class='btn {1} {2}' />", valor, tipo, tamanho);
            }
            return new HtmlString(tag);
        }
    }
}