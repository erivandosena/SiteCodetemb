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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
       // http://www.4guysfromrolla.com/articles/050306-1.aspx

        ////Definir os parâmetros para InvalidCredentialsLogDataSource
        //InvalidCredentialsLogDataSource.InsertParameters("ApplicationName").DefaultValue = Membership.ApplicationName;
        //InvalidCredentialsLogDataSource.InsertParameters("UserName").DefaultValue = Login1.UserName;
        //InvalidCredentialsLogDataSource.InsertParameters("IPAddress").DefaultValue = Request.UserHostAddress;

        ////The password is only supplied if the user enters an invalid username or invalid password - set it to Nothing, by default
        //InvalidCredentialsLogDataSource.InsertParameters("Password").DefaultValue = null;

        //// Houve um problema ao efetuar o login do usuário
        //// Veja se este usuário existe no banco de dados
        //MembershipUser userInfo = Membership.GetUser(Login1.UserName);

        //if (userInfo == null)
        //{
        //    //	O usuário digitou um nome de usuário inválido ...
        //    Label2.Text = "Não há nenhum usuário no banco de dados com o nome de usuário " + Login1.UserName;
        //}
        //else
        //{
        //    //Veja se o usuário está bloqueado ou não aprovados
        //    if (!userInfo.IsApproved)
        //    {
        //        Label2.Text = "Sua conta ainda não foi aprovada pelos administradores do site. Por favor, tente novamente mais tarde.";
        //    }
        //    else if (userInfo.IsLockedOut)
        //    {
        //        Label2.Text = "Sua conta foi bloqueada por causa de um número máximo de tentativas de login incorretas. Você NÃO será capaz de login até entrar em contato com o administrador do site e ter sua conta desbloqueada.";
        //    }
        //    else
        //    {
        //        //A senha foi incorreta (não mostram nada, o controle Login já descreve o problema)
        //        Label2.Text = string.Empty;
                  ////A senha é fornecido apenas se o usuário digitar um nome de usuário inválido ou senha inválida
                  //InvalidCredentialsLogDataSource.InsertParameters("Password").DefaultValue = Login1.Password;
        //    }
        //}

        ////Adicionar um novo registro para a tabela InvalidCredentialsLog
        //InvalidCredentialsLogDataSource.Insert();
    }
}
