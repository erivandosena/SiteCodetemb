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

public partial class Administrativo_Usuarios_CadUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina cadusuario.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("Default.aspx");
        }

    }
    //protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    //{
    //    // Criar um perfil vazio para o usuário recém-criado
    //    ProfileCommon p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);
    //    // Save the profile - deve ser feito desde que expressamente criou esta instância perfil 
    //    p.Save();
    //}
    //// Evento é acionado quando o usuário ativar hits "next" no CreateUserWizard 
    //public void AssignUserToRoles_Activate(object sender, EventArgs e)
    //{
    //    // List DataBind de papéis no sistema gerenciador de funções para uma listagem do assistente 
    //    AvailableRoles.DataSource = Roles.GetAllRoles(); ;
    //    AvailableRoles.DataBind();
    //}
    //// Deactivate evento é acionado quando o usuário hits "next" no CreateUserWizard 
    //public void AssignUserToRoles_Deactivate(object sender, EventArgs e)
    //{
    //    // Adicionar usuário a todas as funções selecionadas a partir da listagem papéis 
    //    for (int i = 0; i < AvailableRoles.Items.Count; i++)
    //    {
    //        if (AvailableRoles.Items[i].Selected == true) 
    //            Roles.AddUserToRole(CreateUserWizard1.UserName, AvailableRoles.Items[i].Value);
    //    }

    //}
}
