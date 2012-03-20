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
using Npgsql;
using Rwd.BLL;

public partial class Impressao : System.Web.UI.Page
{
    string NoticiaCod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        NoticiaCod = Request.QueryString["n"];

        if (string.IsNullOrEmpty(NoticiaCod))
        {
            Response.Redirect("Default.aspx");
        }
        else

            CarregaInfosImagem();
        CarregaNoticia();
    }

    private void CarregaNoticia()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaNoticiasDr(int.Parse(NoticiaCod), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Page.Title = "Versão Impressa - " + dr["not_titulo"].ToString();
                    LabelTitulo.Text = dr["not_titulo"].ToString();
                    LabelPublicado.Text = string.Format("Publicado, {0:D}", dr["not_data"]);
                    LabelAtualizado.Text = string.Format("Atualizado: {0:d}", dr["not_dataalteracao"]);
                    LabelAutor.Text = "Por " + dr["not_autor"].ToString();
                    LabelLegenda.Text = dr["not_legenda"].ToString();
                    LabelTextoResumo.Text = dr["not_sumario"].ToString();
                    LabelTexto.Text = dr["not_noticia"].ToString();
                    LabelFonte.Text = "Fonte: " + dr["not_fonte"].ToString();
                }
            }
        }
    }

    protected void CarregaInfosImagem()
    {
        using (DataSet ds = BusinessLogic.SelecionaImagensnoticiaDs(int.Parse(NoticiaCod)))
        {
            using (DataTable dt = ds.Tables[0])
            {
                if (ds != null && ds.Tables[0].Rows.Count > 1)
                {
                    ImageNoticia.ImageUrl = "../HandlerImgs.ashx?Tamanho=N&img=" + dt.Rows[0][0].ToString();
                }
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    ImageNoticia.ImageUrl = "../HandlerImgs.ashx?Tamanho=N&img=" + dt.Rows[0][0].ToString();
                }
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    ImageNoticia.Visible = false;
                }
            }
        }
    }
}
