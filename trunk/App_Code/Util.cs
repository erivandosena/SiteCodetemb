using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Text;


/// <summary>
/// Summary description for Util
/// </summary>
/// 

namespace Rwd.Util
{

    public class Util
    {
        //Valida controles
        public static string valida(string controle)
        {
            string mensagem = string.Empty;
            if (controle.Trim() == string.Empty)
            {
                mensagem = "<b>Campo requerido.</b>";
            }
            else
            {
                mensagem = string.Empty;
            }

            return mensagem;
        }
        //Remove acentos
        public static string RemoveAcento(string palavra)
        {
            string palavraSemAcento = null;
            string caracterComAcento = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ";
            string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

            for (int i = 0; i < palavra.Length; i++)
            {
                if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                {
                    int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                    palavraSemAcento += caracterSemAcento.Substring(car, 1);
                }
                else
                {
                    palavraSemAcento += palavra.Substring(i, 1);
                }
            }

            return palavraSemAcento;
        }
        //Envio de e-mail
        public static void EnviaEmail(string De, string Para, string Assunto, string Mensagem)
        {
            using(MailMessage email = new MailMessage())
            {
                email.From = new MailAddress(De);
                email.To.Add(Para);
                email.Subject = Assunto;
                email.IsBodyHtml = true;
                email.Body = Mensagem;
                email.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("iso-8859-1");
                SmtpClient smtp = new SmtpClient();
                smtp.Send(email);
            }
        }

        public Util()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}
