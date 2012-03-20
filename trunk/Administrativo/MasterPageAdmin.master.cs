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

public partial class Administrativo_MasterPageAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Área Administrativa";
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
                    Label1.Text = dr["web_fantasia"].ToString();
                    Label2.Text = dr["web_nome"].ToString();
                    Label3.Text = dr["web_slogan"].ToString();
                    Page.Title = Page.Title + " - " + dr["web_nome"].ToString();
                }
            }
        }
    }
}
