using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Imagem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CodImagem = Request.QueryString["i"];
        if (!string.IsNullOrEmpty(CodImagem))
        {
            Label1.Text = "<img src='../HandlerImgs.ashx?Tamanho=A&Img=" + CodImagem.ToString() + "' alt='Imagem ampliada' border='0' />";
        }
        else
        {
            Label1.Text = "<img src='../images/logo.gif' alt='Logomarca' border='0' />";
        }
    }

}