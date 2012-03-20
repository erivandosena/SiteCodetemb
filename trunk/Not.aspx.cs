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

public partial class Not : System.Web.UI.Page
{
    public string MetaDescription
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "description";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    public string MetaKeywords
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "keywords";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    string NoticiaCod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        NoticiaCod = Request.QueryString["n"];

        if (string.IsNullOrEmpty(NoticiaCod))
        {
            Response.Redirect("Default.aspx");
        }
        else
        if (!IsPostBack)
        {
            CarregaDadosWebsite();
            CarregaInfosImagem();
            AtualizaContador();
            CarregaNoticia();
        }
    }

    private void CarregaNoticia()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaNoticiasDr(int.Parse(NoticiaCod), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Page.Header.Title = dr["not_legenda"].ToString() + " - " + dr["not_titulo"].ToString();
                    Lbl_Titulo.Text = dr["not_titulo"].ToString();
                    Lbl_DatPub.Text = string.Format("Publicado, {0:D}", dr["not_data"]);
                    Lbl_DatAtualizacao.Text = string.Format("Atualizado: {0:d}", dr["not_dataalteracao"]);
                    Lbl_Legenda.Text = dr["not_legenda"].ToString();
                    Lbl_Resumo.Text = dr["not_sumario"].ToString();
                    Lbl_Autor.Text = "Por " + dr["not_autor"].ToString();
                    Lbl_Noticia.Text = dr["not_noticia"].ToString();
                    Lbl_Fonte.Text = "Fonte: " + dr["not_fonte"].ToString();
                    Lbl_Visualizacao.Text = "Número de exibições: "+dr["not_visualizacao"].ToString();
                    ImageNoticia.AlternateText = dr["not_legenda"].ToString();
                    //Adiciona description Meta control 
                    MetaDescription = dr["not_sumario"].ToString();
                }
            }
        }
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaWebsiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = dr["web_nome"].ToString();

                    //Adiciona keywords Meta control 
                    MetaKeywords = DatasetToString(BusinessLogic.SelecionaFiliadosNomesDs(), BusinessLogic.SelecionaPaginasNomesDs());

                    LabelPublicidade.Text = dr["web_publicidade1"].ToString();
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
                    LabelImgLegenda.Text = dt.Rows[0][5].ToString() + "<br /><a href='Galeria.aspx?n=" + NoticiaCod.ToString() + "' class='imagens'>Veja outras imagens</a>";
                    ImageNoticia.ImageUrl = "../HandlerImgs.ashx?Tamanho=N&img=" + dt.Rows[0][0].ToString();
                    ImageNoticia.PostBackUrl = "../Galeria.aspx?n=" + NoticiaCod.ToString() + "&i=" + dt.Rows[0][0].ToString();
                }
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    LabelImgLegenda.Text = dt.Rows[0][5].ToString();
                    ImageNoticia.ImageUrl = "../HandlerImgs.ashx?Tamanho=N&img=" + dt.Rows[0][0].ToString();
                    ImageNoticia.PostBackUrl = "../Ampliado.aspx?i=" + dt.Rows[0][0].ToString();
                }
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    ImageNoticia.Visible = false;
                    LabelImgLegenda.Visible = false;
                }
            }
        }
    }

    private string DatasetToString(DataSet ds, DataSet ds2)
    {
        Int32 i = 0;
        String str = "RWD_Sites";
        using (DataTable dt = ds.Tables[0])
        {
            while (i < dt.Rows.Count)
            {
                str += ", " + dt.Rows[i][0].ToString() + ", " + dt.Rows[i][1].ToString();
                i++;
            }
        }

        i = 0;
        String str2 = "";
        using (DataTable dt2 = ds2.Tables[0])
        {
            while (i < dt2.Rows.Count)
            {
                str2 += ", " + dt2.Rows[i][0].ToString();
                i++;
            }
        }

        return (str + str2);
    }

    protected void AtualizaContador()
    {
        if (!string.IsNullOrEmpty(NoticiaCod))
        {
            BusinessLogic.AtualizaNoticiasVisualizao(int.Parse(NoticiaCod));
        }

    }
}
