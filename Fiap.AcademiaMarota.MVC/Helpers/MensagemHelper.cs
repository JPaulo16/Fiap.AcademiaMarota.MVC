using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.AcademiaMarota.MVC
{
    public static class MensagemHelper
    {
        public static IHtmlString Mensagem(string msg, string tipo){
            var tag = "";
            if (msg != null)
            {
                tag = String.Format("<div class='alert alert-{0}'>{1}</div>", tipo, msg);
            }
            return new HtmlString(tag);
        }
    }
}