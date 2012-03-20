using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Npgsql;
using Rwd.BLL;

public partial class MasterPage : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaDadosWebsite();
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
                    LabelTituloSite.Text = dr["web_nome"].ToString();
                    ImageLogo.ImageUrl = "../HandlerImgs.ashx?imgweb=" + dr["web_cod"].ToString();
                    LabelBase.Text = dr["web_publicidade2"].ToString();
                    LabelCopyright.Text = DateTime.Now.Year + " " + dr["web_nome"].ToString();

                    byte[] logo = dr["web_logo"] as byte[];
                    if (logo == null)
                    {
                        ImageLogo.Visible = false;
                    }
                }
            }
        }
    }


}


