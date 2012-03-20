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

public partial class _Default : System.Web.UI.Page
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

    string NoticiaCod = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaDadosWebsite();
            CarregaManchete();
            CarregaInfosImagem();
        }
    }

    private void CarregaManchete()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaNoticiasUltimaDr())
        {
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    LabelTitulo.Text = dr["not_titulo"].ToString();
                    LabelLegenda.Text = dr["not_legenda"].ToString();
                    LabelResumo.Text = dr["not_sumario"].ToString();
                    ImageNoticia.AlternateText = dr["not_legenda"].ToString();
                    NoticiaCod = dr["not_cod"].ToString();
                    ImageNoticia.PostBackUrl = "../Not.aspx?n=" + dr["not_cod"].ToString();
                }
            }
            else
            {
                PanelNoticia.Visible = false;
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

                    //Adiciona description Meta control 
                    MetaDescription = dr["web_fantasia"].ToString() + " - " + dr["web_slogan"].ToString();

                    using (DataSet ds = BusinessLogic.SelecionaFiliadosNomesDs())
                    {
                        //Adiciona keywords Meta control 
                        MetaKeywords = DatasetToString(ds,BusinessLogic.SelecionaPaginasNomesDs());
                    }

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
                if (ds != null && ds.Tables[0].Rows.Count >= 1)
                {
                    ImageNoticia.ImageUrl = "../HandlerImgs.ashx?Tamanho=M&img=" + dt.Rows[0][0].ToString();
                }
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    ImageNoticia.Visible = false;
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
}
