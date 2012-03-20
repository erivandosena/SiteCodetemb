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

public partial class Administrativo_Cadastro : System.Web.UI.Page
{
    byte[] logo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ os botoes: salvar, excluir, remove
        if (Roles.IsUserInRole("Administrador") == true)
        {
            Button1.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
        }
        else
        {
            Button1.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
        }

        if (!IsPostBack)
        {
            CarregaCadastro();
        }
    }

    private void CarregaCadastro()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaWebsiteDr())
        {
            while (dr.Read())
            {
                
                Label1.Text = dr["web_cod"].ToString();

                TextBoxNome.Text = dr["web_nome"].ToString();
                TextBoxFantasia.Text = dr["web_fantasia"].ToString();
                TextBoxSlogan.Text = dr["web_slogan"].ToString();
                TextBoxResp.Text = dr["web_contato"].ToString();
                TextBoxCNPJ.Text = dr["web_cpf_cnpj"].ToString();
                TextBoxEndereco.Text = dr["web_endereco"].ToString();
                TextBoxCidade.Text = dr["web_cidade"].ToString();
                TextBoxEstado.Text = dr["web_estado"].ToString();
                TextBoxCEP.Text = dr["web_cep"].ToString();
                TextBoxSite.Text = dr["web_site"].ToString();
                TextBoxTel1.Text = dr["web_telefone1"].ToString();
                TextBoxTel2.Text = dr["web_telefone2"].ToString();
                TextBoxEmail1.Text = dr["web_email1"].ToString();
                TextBoxEmail2.Text = dr["web_email2"].ToString();
                TextBoxSkype.Text = dr["web_skype"].ToString();
                FCKeditorMapa.Value = dr["web_mapa"].ToString();
                FCKeditorPub1.Value = dr["web_publicidade1"].ToString();
                FCKeditorPub2.Value = dr["web_publicidade2"].ToString();
                Image1.ImageUrl = "../HandlerImgs.ashx?imgweb=" + Label1.Text;

                logo = dr["web_logo"] as byte[];
                if (logo != null)
                {
                    Button4.Visible = true;
                }

                Button1.Text = "Atualizar";
                Button3.Visible = true;
            }
        }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {

                string web_nome = TextBoxNome.Text;
                string web_fantasia = TextBoxFantasia.Text;
                string web_slogan = TextBoxSlogan.Text;
                string web_contato = TextBoxResp.Text;
                string web_cpf_cnpj = TextBoxCNPJ.Text;
                string web_endereco = TextBoxEndereco.Text;
                string web_cidade = TextBoxCidade.Text;
                string web_estado = TextBoxEstado.Text;
                string web_cep = TextBoxCEP.Text;
                string web_site = TextBoxSite.Text.ToLower();
                string web_telefone1 = TextBoxTel1.Text;
                string web_telefone2 = TextBoxTel2.Text;
                string web_email1 = TextBoxEmail1.Text;
                string web_email2 = TextBoxEmail2.Text;
                string web_skype = TextBoxSkype.Text;
                string web_mapa = FCKeditorMapa.Value;
                string web_publicidade1 = FCKeditorPub1.Value;
                string web_publicidade2 = FCKeditorPub2.Value;

                if (FileUpload1.HasFile)
                {
                    logo = FileUpload1.FileBytes;
                }
                else
                {
                    logo = null;
                }

                if (Label1.Text == string.Empty)
                {
                    //Insere
                    BusinessLogic.InsereWebsite(
                        web_nome,
                        web_slogan,
                        web_contato,
                        web_fantasia,
                        web_cpf_cnpj,
                        web_endereco,
                        web_cidade,
                        web_estado,
                        web_cep,
                        web_site,
                        logo,
                        web_telefone1,
                        web_telefone2,
                        web_email1,
                        web_email2,
                        web_skype,
                        web_publicidade1,
                        web_publicidade2,
                        web_mapa);
                    LblMsg.Text = "Cadastrado com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }
                else
                {
                    //Atualiza
                    if (FileUpload1.HasFile)
                    {
                        logo = FileUpload1.FileBytes;
                        BusinessLogic.AtualizaWebsiteImagem(int.Parse(Label1.Text), logo);
                    }
                    BusinessLogic.AtualizaWebsite(
                        int.Parse(Label1.Text),
                        web_nome,
                        web_slogan,
                        web_contato,
                        web_fantasia,
                        web_cpf_cnpj,
                        web_endereco,
                        web_cidade,
                        web_estado,
                        web_cep,
                        web_site,
                        web_telefone1,
                        web_telefone2,
                        web_email1,
                        web_email2,
                        web_skype,
                        web_publicidade1,
                        web_publicidade2,
                        web_mapa);
                    LblMsg.Text = "Cadastro atualizado com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }

                CarregaCadastro();
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic.ExcluiWebsite(int.Parse(Label1.Text));

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Text = "Salvar";
            Button3.Visible = false;

            LblMsg.Text = "Cadastro excluído com sucesso!";

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
    protected void Button4_Click(object sender, EventArgs e)
    {
        logo = null;
        BusinessLogic.AtualizaWebsiteImagem(int.Parse(Label1.Text), logo);
        Button4.Visible = false;
        LblMsg.Text = "Imagem removida com sucesso!";
    }
}
