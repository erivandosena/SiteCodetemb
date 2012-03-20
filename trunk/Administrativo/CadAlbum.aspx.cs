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
using System.IO;

public partial class Administrativo_CadAlbum : System.Web.UI.Page
{
    string AlbumCod = null;
    string FotoCod = null;
    string FotoOpcao = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        AlbumCod = Request.QueryString["codalbum"];
        FotoCod = Request.QueryString["codfoto"];
        FotoOpcao = Request.QueryString["opcao"];

        //Permissões de acesso conforme role p/ o botão excluir
        //if (Roles.IsUserInRole("Administrador") == true)
        //{
        //    Button3.Enabled = true;
        //}
        //else
        //{
        //    Button3.Enabled = false;
        //}

        if (!string.IsNullOrEmpty(AlbumCod))
        {
            if (Session["NomeAlbum"] == null)
            {
                CarregaAlbum();
            }
            LabelAlbum.Text = Session["NomeAlbum"].ToString();
        }

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(FotoCod) || !string.IsNullOrEmpty(FotoOpcao))
            {
                FotosAlbum();

                if (FotoOpcao == "atualiza")
                {
                    LblMsg.Text += "Foto atualizada com sucesso!";
                }
                else
                    if (FotoOpcao == "exclui")
                    {
                        LblMsg.Text = "Foto excluída com sucesso!";
                    }
            }
            else
                if (string.IsNullOrEmpty(AlbumCod))
                {
                    Button1.Text = "Salvar";
                    Panel1.Visible = true;
                }
                else
                {
                    CarregaAlbum();
                    Button1.Text = "Atualizar";
                    Button3.Visible = true;
                    Button5.Visible = true;
                    Panel1.Visible = true;
                }
        }

    }

    private void CarregaAlbum()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaAlbumDr(int.Parse(AlbumCod), null))
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LabelCodigo.Text = dr["alb_cod"].ToString();
                    TxtNome.Text = dr["alb_nome"].ToString();
                    Session["NomeAlbum"] = dr["alb_nome"].ToString();
                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Albuns.aspx");
    }

    protected void LimpaControles(Control pai)
    {
        foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0) LimpaControles(ctl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Salvar ou atualizar album
        if (Button1.Text == "Salvar" || Button1.Text == "Atualizar")
        {
            try
            {
                if (IsValid)
                {
                    string alb_cod = LabelCodigo.Text;
                    string alb_nome = TxtNome.Text;

                    if (string.IsNullOrEmpty(LabelCodigo.Text))
                    {
                        //Insere
                        BusinessLogic.InsereAlbum(alb_nome);
                        LblMsg.Text = "Álbum cadastrado com sucesso!";
                        LimpaControles(this);
                        LabelCodigo.Text = string.Empty;
                    }
                    else
                    {
                        //Atualiza
                        BusinessLogic.AtualizaAlbum(int.Parse(AlbumCod), alb_nome);
                        LblMsg.Text = "Álbum atualizado com sucesso!";
                        CarregaAlbum();
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

        if (Button1.Text == "Adiciona")
        {
            ////Rodar javascript
            //String scriptString = "<script type=text/javascript>";
            //scriptString += "showDiv();";
            //scriptString += "</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "scrt", scriptString);

            LblMsg.Text = string.Empty;
            try
            {
                HttpFileCollection hfc = Context.Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    BinaryReader b = new BinaryReader(hpf.InputStream);

                    if (hpf.ContentLength > 0)
                    {
                        int alb_cod = int.Parse(AlbumCod);
                        string fot_legenda = TxtFotoLegenda.Text;
                        byte[] foto_original = b.ReadBytes(hpf.ContentLength);
                        string fot_tipo = hpf.ContentType;

                        BusinessLogic.InsereFotoAlbum(alb_cod, fot_legenda, foto_original, fot_tipo);

                        LblMsg.Text += "Foto <strong>" + hpf.FileName + "</strong> adicionada com sucesso.<br />";
                        TxtFotoLegenda.Text = string.Empty;
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
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int alb_cod = int.Parse(AlbumCod);

            BusinessLogic.ExcluiAlbum(alb_cod);

            LimpaControles(this);
            LabelCodigo.Text = string.Empty;
            Button1.Visible = false;
            Button3.Visible = false;
            Button5.Visible = false;

            LblMsg.Text = "Álbum excluído com sucesso!";

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

    protected void Button5_Click(object sender, EventArgs e)
    {
        FotosAlbum();
    }

    private void FotosAlbum()
    {
        LblMsg.Text = string.Empty;

        if (Button5.Text == "Adicionar e Gerenciar Fotografias")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button5.Visible = true;

            Button5.Text = "Retorna";
            Button1.Text = "Adiciona";
        }
        else
        {
            Response.Redirect("CadAlbum.aspx?codalbum=" + AlbumCod.ToString());
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                byte[] foto_original = null;
                string fot_tipo = string.Empty;
                using (NpgsqlDataReader dr = BusinessLogic.SelecionaFotoAlbumUnitDr(int.Parse(FotoCod)))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            foto_original = (byte[])dr["fot_normal"];
                            fot_tipo = dr["fot_tipo"].ToString();
                        }
                    }
                }

                if (FileUpload1.HasFile)
                {
                    foto_original = FileUpload1.FileBytes;
                    fot_tipo = FileUpload1.PostedFile.ContentType;
                }

                BusinessLogic.AtualizaFotoAlbum(
                    int.Parse(FotoCod),
                    int.Parse(AlbumCod),
                    TxtFotoLegenda.Text,
                    foto_original,
                    fot_tipo);

                LblMsg.Text = "Foto atualizada com sucesso!";
                TxtFotoLegenda.Text = string.Empty;
                Response.Redirect("CadAlbum.aspx?codalbum=" + AlbumCod.ToString() + "&codfoto=" + FotoCod.ToString() + "&opcao=" + FotoOpcao.ToString());
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic.ExcluiFotoAlbum(int.Parse(FotoCod));

            Response.Redirect("CadAlbum.aspx?codalbum=" + AlbumCod.ToString() + "&codfoto=" + FotoCod.ToString() + "&opcao=" + FotoOpcao.ToString());
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
