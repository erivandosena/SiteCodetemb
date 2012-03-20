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
using Rwd.BLL;
using Npgsql;

public partial class Administrativo_CadLinks : System.Web.UI.Page
{
    string CodLink = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        CodLink = Request.QueryString["codlink"];

        if (CodLink == string.Empty || CodLink == null)
        {
            Button1.Text = "Salvar";
        }
        else
        {
            if (!IsPostBack)
            {
                CarregaLink();
            }
            Button1.Text = "Atualizar";
            Button3.Visible = true;
        }
    }

    private void CarregaLink()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaUrlsDr(int.Parse(CodLink), null))
        {
            while (dr.Read())
            {
                Label1.Text = dr["url_cod"].ToString();
                TextBoxNome.Text = dr["url_nome"].ToString();
                TextBoxUrl.Text = dr["url_link"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                string url_nome = TextBoxNome.Text;
                string url_link = TextBoxUrl.Text.ToLower();

                if (Label1.Text == string.Empty)
                {
                    //Insere
                    BusinessLogic.InsereUrls(url_nome, url_link);
                    LblMsg.Text = "Link cadastrado com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }
                else
                {
                    //Atualiza
                    BusinessLogic.AtualizaUrls(int.Parse(CodLink), url_nome, url_link);
                    LblMsg.Text = "Link atualizado com sucesso!";
                    CarregaLink();
                }
            }
        }
        catch (NpgsqlException ex)
        {
            LblMsg.Text = "Erro nos dados: " + ex.Message;
        }
        catch (Exception ex)
        {
            LblMsg.Text = "Erro no sistema: " + ex.Message;
        }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Links.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int url_cod = int.Parse(CodLink);

            BusinessLogic.ExcluiUrls(url_cod);

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;

            LblMsg.Text = "Link excluído com sucesso!";

        }
        catch (NpgsqlException ex)
        {
            LblMsg.Text = "Erro nos dados: " + ex.Message;
        }
        catch (Exception ex)
        {
            LblMsg.Text = "Erro no sistema: " + ex.Message;
        }
    }
}
