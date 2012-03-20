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

public partial class Administrativo_Usuarios_NovoUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        // Create an empty Profile for the newly created user
        ProfileCommon p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);
        p.Save();
    }

    // Activate event fires when user hits "next" in the CreateUserWizard
    public void AssignUserToRoles_Activate(object sender, EventArgs e)
    {
        // Databind list of roles in the role manager system to listbox
        AvailableRoles.DataSource = Roles.GetAllRoles(); ;
        AvailableRoles.DataBind();
    }

    // Deactivate event fires when user hits "next" in the CreateUserWizard
    public void AssignUserToRoles_Deactivate(object sender, EventArgs e)
    {
        // Add user to all selected roles from the roles listbox
        for (int i = 0; i < AvailableRoles.Items.Count; i++)
        {
            if (AvailableRoles.Items[i].Selected == true)
                Roles.AddUserToRole(CreateUserWizard1.UserName, AvailableRoles.Items[i].Value);
        }
    }
}
