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
using Rwd.Util;

public partial class Filiado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fil = Request.QueryString["filiado"];
        if (!string.IsNullOrEmpty(fil))
        {
            using (DataSet ds = BusinessLogic.SelecionaFiliadosMunicipiosDs(0,fil.ToLower()))
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }
    }
}
