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
using Rwd.Util;


public partial class Indicacao : System.Web.UI.Page
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
    //Para o e-mail
    string web_nome = "";
    string web_slogan = "";
    string web_fantasia = "";
    string not_sumario = "";
    string noticia_imagem = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        NoticiaCod = Request.QueryString["n"];

        if (string.IsNullOrEmpty(NoticiaCod))
        {
            Response.Redirect("Default.aspx");
        }
        else
            CarregaDadosWebsite();
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
                    Page.Header.Title = Page.Title + " - Indicação";
                    Lbl_Titulo.Text = dr["not_titulo"].ToString();
                    Lbl_Resumo.Text = dr["not_sumario"].ToString();
                    //Adiciona description Meta control 
                    MetaDescription = dr["not_sumario"].ToString();

                    //Para o e-mail
                    not_sumario = dr["not_sumario"].ToString();
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

                    //Para o e-mail
                    web_nome = dr["web_nome"].ToString();
                    web_slogan = dr["web_slogan"].ToString();
                    web_fantasia = dr["web_fantasia"].ToString();
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Not.aspx?n=" + NoticiaCod.ToString());
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CarregaInfosImagem();

        //Valida campos
        LblMsg.Text = "";
        if (Util.valida(TxtBoxNome.Text) != string.Empty)
        {
            LblMsg.Text = "Seu nome - " + Util.valida(TxtBoxNome.Text);
            TxtBoxNome.Focus();
        }
        else
            if (Util.valida(TxtBoxEmail.Text) != string.Empty)
            {
                LblMsg.Text = "Seu e-mail - " + Util.valida(TxtBoxEmail.Text);
                TxtBoxEmail.Focus();
            }
            else
                if (Util.valida(TxtBoxEmailDest.Text) != string.Empty)
                {
                    LblMsg.Text = "E-mail do(a) Amigo(a) - " + Util.valida(TxtBoxEmailDest.Text);
                    TxtBoxEmailDest.Focus();
                }
                else

                    if (Page.IsValid)
                    {
                        try
                        {
                            string UrlSite = string.Concat("http://", Request.Url.Authority.ToString());
                            string CorpoEmail = "<font face='Georgia, Times New Roman, Times, serif'>" +
                                "<table width='600' border='0' align='center' cellpadding='0' cellspacing='0' class='fonte'><tr><td><a href='" + UrlSite.ToString() + "' target='_blank'>" +
                                "<img src='" + string.Concat(UrlSite.ToString(), "/images/logo.gif") + "' alt='" + web_fantasia.ToString() + "' width='160' hspace='10' border='0' align='left' />" +
                                "</a><font size='5'><strong>" + web_nome.ToString() + "</strong></font><br /><br /><font size='2'>" + web_slogan.ToString() + "</font><br /></td>" +
                                "</tr><tr><td><br />Olá!<br /><br />" + TxtBoxNome.Text + " visitou nosso site " + Request.Url.Authority.ToString() + " e está lhe indicando esta notícia:<br /><br /></td>" +
                                "</tr><tr><td><a href='" + string.Concat(UrlSite.ToString(), "/Not.aspx?n=" + NoticiaCod.ToString()) + "' target='_blank'>" +
                                noticia_imagem.ToString() + not_sumario.ToString() + "</a><br /></td></tr><tr><td><br />" + TxtBoxNome.Text + " escreveu: " +
                                TextBoxMenOpc.Text + "<br /><br />Clique no link acima e leia a matéria completa!<br />" +
                                "Também veja e acompanhe outras notícias publicadas frequentemente neste website.</td>" +
                                "</tr><tr><td><br /><a href='" + UrlSite.ToString() + "' target='_blank'>" + Request.Url.Authority.ToString() + "</a><br /><br /><br /></td></tr><tr><td align='center'>" +
                                "<font face='Arial, Helvetica, sans-serif' size='2'>Copyright © " + DateTime.Now.Year + " " + web_nome.ToString() + "</font>" +
                                "</td></tr></table></font>";
                            Util.EnviaEmail(
                                TxtBoxNome.Text + "<" + TxtBoxEmail.Text.ToLower() + ">",
                                TxtBoxEmailDest.Text.ToLower(),
                                TxtBoxNome.Text + " fez esta indicação para você!",
                                CorpoEmail.ToString());
                            LimpaControles(this);
                            LblMsg.Text = "Enviado com sucesso!";
                        }
                        catch (Exception)
                        {
                            string Erro = "Falha no envio.";
                            LblMsg.Text = Erro;
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
                    noticia_imagem = "<img src='" + string.Concat("http://" + Request.Url.Authority.ToString(), "/HandlerImgs.ashx?Tamanho=M&img=" + dt.Rows[0][0].ToString()) + "' alt='" + dt.Rows[0][5].ToString() + "' hspace='10' border='0' align='left' />";
                }
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    noticia_imagem = "";
                }
            }
        }
    }
}
