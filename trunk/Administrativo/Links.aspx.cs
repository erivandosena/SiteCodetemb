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

public partial class Administrativo_Links : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaLinks();
        }
    }

    protected void CarregaLinks()
    {
        using (DataSet ds = BusinessLogic.SelecionaUrlsDs(0, "%"))
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                LblMsg.Text = "Ainda não existem cadastros.";
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        CarregaLinks();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadLinks.aspx");
    }
}
