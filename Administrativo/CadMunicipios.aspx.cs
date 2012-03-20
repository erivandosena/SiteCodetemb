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

public partial class Administrativo_CadMunicipios : System.Web.UI.Page
{
    string CodMunicipio = null;
    byte[] logo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        CodMunicipio = Request.QueryString["codmunicipio"];

        if (string.IsNullOrEmpty(CodMunicipio))
        {
            Button1.Text = "Salvar";
        }
        else
        {
            if (!IsPostBack)
            {
                CarregaMunicipio();
            }
            Button1.Text = "Atualizar";
            Button3.Visible = true;
        }
    }

    private void CarregaMunicipio()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaMunicipiosDr(int.Parse(CodMunicipio), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["mun_cod"].ToString();
                    TextBoxCidade.Text = dr["mun_nome"].ToString();
                    TextBoxCep.Text = dr["mun_cep"].ToString();
                    TextBoxGestor.Text = dr["mun_gestor"].ToString();
                    TextBoxEstado.Text = dr["mun_estado"].ToString();
                    TextBoxSite.Text = dr["mun_site"].ToString();
                    FCKeditorMapa.Value = dr["mun_mapa"].ToString();
                    Image1.ImageUrl = "../HandlerImgs.ashx?imgmun=" + CodMunicipio.ToString();
                   
                    logo = dr["mun_logo"] as byte[];
                    if (logo != null)
                    {
                        Button4.Visible = true;
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                string mun_nome = TextBoxCidade.Text;
                string mun_cep = TextBoxCep.Text;
                string mun_gestor = TextBoxGestor.Text;
                string mun_estado = TextBoxEstado.Text;
                string mun_site = TextBoxSite.Text.ToLower();
                string mun_mapa = FCKeditorMapa.Value;

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
                    BusinessLogic.InsereMunicipios(
                        mun_nome,
                        mun_gestor,
                        mun_estado,
                        mun_cep,
                        mun_site,
                        mun_mapa,
                        logo);
                    LblMsg.Text = "Cidade cadastrada com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }
                else
                {
                    //Atualiza
                    if (FileUpload1.HasFile)
                    {
                        logo = FileUpload1.FileBytes;
                        BusinessLogic.AtualizaMunicipiosImagem(int.Parse(CodMunicipio), logo);
                    }
                    BusinessLogic.AtualizaMunicipios(
                        int.Parse(CodMunicipio),
                        mun_nome,
                        mun_gestor,
                        mun_estado,
                        mun_cep,
                        mun_site,
                        mun_mapa);
                    LblMsg.Text = "Cidade atualizada com sucesso!";
                    CarregaMunicipio();
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
        foreach (Control ctl in pai.Controls) if (ctl is FredCK.FCKeditorV2.FCKeditor) ((FredCK.FCKeditorV2.FCKeditor)ctl).Value = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Municipios.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int mun_cod = int.Parse(CodMunicipio);

            BusinessLogic.ExcluiMunicipios(mun_cod);

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;

            LblMsg.Text = "Ciadade excluída com sucesso!";

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
        BusinessLogic.AtualizaMunicipiosImagem(int.Parse(CodMunicipio), logo);
        Button4.Visible = false;
        LblMsg.Text = "Imagem removida com sucesso!";
    }
}
