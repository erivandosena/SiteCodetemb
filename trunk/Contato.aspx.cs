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

public partial class Contato : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaDadosWebsite();
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
                    Page.Header.Title = dr["web_nome"].ToString() + " - Contato";
                    LblEndereco.Text = dr["web_endereco"].ToString();
                    LblCep.Text = dr["web_cep"].ToString();
                    LblCidade.Text = dr["web_cidade"].ToString();
                    LblEstado.Text = dr["web_estado"].ToString();
                    LblTel1.Text = dr["web_telefone1"].ToString();
                    LblTel2.Text = dr["web_telefone2"].ToString();
                    LblMail1.Text = "<a href='mailto:" + dr["web_email1"].ToString() + "'>" + dr["web_email1"].ToString() + "</a>";
                    LblMail2.Text = dr["web_email2"].ToString();
                    LblSkype.Text = "<a href='callto://" + dr["web_skype"].ToString() + "'>" + dr["web_skype"].ToString() + "</a>";
                    LblMapa.Text = dr["web_mapa"].ToString();
                    //Adiciona keywords Meta control 
                    MetaKeywords = DatasetToString(BusinessLogic.SelecionaFiliadosNomesDs(), BusinessLogic.SelecionaPaginasNomesDs());
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

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is DropDownList) ((DropDownList)ctl).SelectedIndex = -1;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Valida campos
        LblMsg.Text = "";
        if (Util.valida(TextBoxNome.Text) != string.Empty)
        {
            LblMsg.Text = "Nome - " + Util.valida(TextBoxNome.Text);
            TextBoxNome.Focus();
        }
        else
            if (Util.valida(TextBoxEmail.Text) != string.Empty)
            {
                LblMsg.Text = "E-mail - " + Util.valida(TextBoxEmail.Text);
                TextBoxEmail.Focus();
            }
            else
                if (Util.valida(DropDownListAss.SelectedValue) != string.Empty)
                {
                    LblMsg.Text = "Assunto - " + Util.valida(DropDownListAss.SelectedValue);
                    DropDownListAss.Focus();
                }
                else
                    if (Util.valida(TextBoxMens.Text) != string.Empty)
                    {
                        LblMsg.Text = "Mensagem - " + Util.valida(TextBoxMens.Text);
                        TextBoxMens.Focus();
                    }
                    else

                        if (Page.IsValid)
                        {
                            try
                            {
                                string SiteEmail = ConfigurationManager.AppSettings["SiteEmail"];
                                string UrlSite = string.Concat("http://", Request.Url.Authority.ToString());

                                string CorpoEmail = "<table width='600' border='0' cellspacing='0' cellpadding='0' align='center'>" +
                                                 "<tr><td colspan='2' align='center' bgcolor='#F4F4F4'><strong>" + Request.Url.Authority + " - FORMULÁRIO DE CONTATO</strong></td>" +
                                                 "</tr><tr><td>&nbsp;</td><td>&nbsp;</td></tr><tr>" +
                                                 "<td bgcolor='#FBFBFB'>Nome:</td><td bgcolor='#F9F9F9'>" + TextBoxNome.Text.ToUpper() + "</td></tr><tr>" +
                                                 "<td bgcolor='#FBFBFB'>E-mail:</td><td bgcolor='#F9F9F9'>" + TextBoxEmail.Text.ToLower() + "</td></tr><tr>" +
                                                 "<td bgcolor='#FBFBFB'>Telefone:</td><td bgcolor='#F9F9F9'>" + TextBoxTelefone.Text + "</td></tr><tr>" +
                                                 "<td bgcolor='#FBFBFB'>Assunto:</td><td bgcolor='#F9F9F9'>" + DropDownListAss.SelectedItem.Value + "</td></tr><tr>" +
                                                 "<td bgcolor='#FBFBFB'>Mensagem:</td><td valign='top' bgcolor='#F9F9F9'>" + TextBoxMens.Text + "</td></tr><tr>" +
                                                 "<td bgcolor='#FBFBFB'>IP do computador remoto:</td><td bgcolor='#F9F9F9'>" + Request.UserHostAddress + "</td></tr>" +
                                                 "<tr><td colspan='2'>&nbsp;</td></tr><tr><td colspan='2' align='center'>" +
                                                 "Desenvolvido por: <a href='" + ConfigurationManager.AppSettings["AdminSite"].ToString() + "' title='RAMOS Web Designer - Criação de Sites' target='_blank'>RAMOS Web Designer</a></td></tr></table>";
                                Util.EnviaEmail(
                                    TextBoxNome.Text + "<" + TextBoxEmail.Text.ToLower() + ">",
                                    SiteEmail,
                                    "Proveniente do site - " + DropDownListAss.SelectedItem.Value,
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
}