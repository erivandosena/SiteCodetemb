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

public partial class Administrativo_CadFiliados : System.Web.UI.Page
{
    string CodFiliado = null;
    string CodMunicipio = null;
    byte[] logo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        CodFiliado = Request.QueryString["codfiliado"];
        CodMunicipio = Request.QueryString["codmunicipio"];

        if (string.IsNullOrEmpty(CodFiliado))
        {
            Button1.Text = "Salvar";
            if (!IsPostBack)
            {
                RelacionaCidades();
            }
        }
        else
        {
            if (!IsPostBack)
            {
                RelacionaCidades();
                CarregaFiliado();
            }
            Button1.Text = "Atualizar";
            Button3.Visible = true;
        }
    }

    private void RelacionaCidades()
    {
        using (DataSet ds = BusinessLogic.SelecionaMunicipiosDs(0, "%"))
        {
            DDListCidades.DataSource = ds;
            DDListCidades.DataMember = ds.Tables[0].TableName;
            DDListCidades.DataTextField = "mun_nome";
            DDListCidades.DataValueField = "mun_cod";
            DDListCidades.DataBind();
            DDListCidades.Items.Add(new ListItem("", "0"));
            DDListCidades.SelectedValue = "0";
        }
    }

    private void CarregaFiliado()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaFiliadosDr(int.Parse(CodFiliado), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["fil_cod"].ToString();

                    DDListCidades.SelectedValue = dr["mun_cod"].ToString();
                    TextBoxFiliado.Text = dr["fil_nome"].ToString();
                    DDListTipo.SelectedValue = dr["fil_tipo"].ToString();
                    TextBoxResp.Text = dr["fil_responsavel"].ToString();
                    TextBoxEndereco.Text = dr["fil_endereco"].ToString();
                    TextBoxTel.Text = dr["fil_telefone"].ToString();
                    TextBoxEmail.Text = dr["fil_email"].ToString();
                    TextBoxSite.Text = dr["fil_site"].ToString();
                    Image1.ImageUrl = "../HandlerImgs.ashx?imgfil=" + CodFiliado.ToString();

                    logo = dr["fil_logo"] as byte[];
                    if (logo != null)
                    {
                        Button4.Visible = true;
                    }
                }
            }
        }
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        foreach (Control ctl in pai.Controls) if (ctl is DropDownList) ((DropDownList)ctl).SelectedItem.Text = "";
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                int mun_cod = int.Parse(DDListCidades.SelectedValue);
                string fil_nome = TextBoxFiliado.Text;
                string fil_responsavel = TextBoxResp.Text;
                string fil_endereco = TextBoxEndereco.Text;
                string fil_telefone = TextBoxTel.Text;
                string fil_email = TextBoxEmail.Text.ToLower();
                string fil_site = TextBoxSite.Text.ToLower();
                string fil_tipo = DDListTipo.SelectedValue;

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
                    BusinessLogic.InsereFiliados(
                        mun_cod,
                        fil_nome,
                        fil_responsavel,
                        fil_endereco,
                        fil_site,
                        fil_telefone,
                        fil_email,
                        logo,
                        fil_tipo);
                    LblMsg.Text = "Filiado cadastrado com sucesso!";
                    LimpaControles(this);
                    Label1.Text = string.Empty;
                }
                else
                {
                    //Atualiza
                    if (FileUpload1.HasFile)
                    {
                        logo = FileUpload1.FileBytes;
                        BusinessLogic.AtualizaFiliadosImagem(int.Parse(CodFiliado), logo);
                    }
                    BusinessLogic.AtualizaFiliados(
                        int.Parse(CodFiliado),
                        mun_cod,
                        fil_nome,
                        fil_responsavel,
                        fil_endereco,
                        fil_site,
                        fil_telefone,
                        fil_email,
                        fil_tipo);
                    LblMsg.Text = "Filiado atualizado com sucesso!";
                    CarregaFiliado();
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Filiados.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int fil_cod = int.Parse(CodFiliado);

            BusinessLogic.ExcluiFiliados(fil_cod);

            LimpaControles(this);
            Label1.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;

            LblMsg.Text = "Filiado excluído com sucesso!";

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
        BusinessLogic.AtualizaFiliadosImagem(int.Parse(CodFiliado), logo);
        Button4.Visible = false;
        LblMsg.Text = "Imagem removida com sucesso!";
    }
}
