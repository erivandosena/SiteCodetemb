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

public partial class Administrativo_Usuarios_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////Permissões de acesso conforme role p/ o botão novo usuario e gerenciar
        //if (Roles.IsUserInRole("Administrador") == true)
        //{
        //    ImageButton1.Enabled = true;
        //    ImageButton3.Enabled = true;
        //}
        //else
        //{
        //    ImageButton1.Enabled = false;
        //    ImageButton3.Enabled = false;
        //}
    }
}
