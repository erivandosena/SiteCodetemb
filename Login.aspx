<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ÁREA ADMINISTRATIVA de <%= Request.Url.Authority %> :: Login ::</title>
<style type="text/css">
* { 
    margin: 0;
    padding: 0;
}
body {
    margin: 0 auto;
    color: #595959;
    background-color: #fff;
    text-align: center;
    font: normal 12px arial, helvetica, sans-serif;
	background-image: url(images/logo_fundo.gif);
	background-repeat: no-repeat;
	background-position: 615px 50px;
}
a 
{
    text-decoration: underline;
}

a:hover 
{
    text-decoration: none;
}
#formWrapper {
    width: 450px;
    margin: 0 auto;
    min-width: inherit;
    padding: 0px 20px 10px 20px;
    text-align: left;  
}
.ajuda 
{
    font-size: 8pt;
}
#formCasing {
    background: url("images/login/login-case.png") no-repeat top left;
    padding: 20px 35px 1px 27px;
    /* Give content layout to fix IE7 bug with 100% width tables  */
    zoom: 1.0;
}
#formFooter {
    background: url("images/login/login-footer.png") no-repeat top left;
    height: 18px;
}
#additional {
    width: 500px;
    margin: 100px auto 0 auto;
}
form dl {
    margin: 15px 0;
}
form dt {
    float: left;
    width: 80px;
    font-size: 14px;
    line-height: 24px;
    color: #a5a5a5;
    padding-top: 5px;
}
form dd {
    margin: 0 0 10px 90px;
    font-size: 12px;
    line-height: 24px;
    color: #a5a5a5;
    margin-left: 80px;
}
dd span {
    color: #ccc;
}
h1 {
    font-size: 24px;
    margin: 7px 0 8px 0;
    padding: 0 0 12px 0;
    text-align: left;
    line-height: 26px;
    padding: 12px 0 12px 0 !ie;
}
h2 {
    font-size: 14px;
    color: #2ba02c;
}

.input_username {
    font-size: 14px;
    padding: 8px 5px;
    font: normal 14px arial, helvetica, sans-serif;
    border: 1px solid #dcdcdc;
    color: #444;
    -moz-border-radius:4px;
    border-radius:4px;
    -webkit-border-radius:4px;
    width: 240px;
}
.input_password {
    font-size: 14px;
    padding: 8px 5px;
    font: normal 14px arial, helvetica, sans-serif;
    border: 1px solid #dcdcdc;
    color: #444;
    -moz-border-radius:4px;
    border-radius:4px;
    -webkit-border-radius:4px;
    width: 120px;
    margin-right: 5px;
}
input.input:focus {
    border: 1px solid #bfbfbf;
    outline: none;
}
input.button {
    padding: 0;
    vertical-align: middle;
}
input#username {
    width: 280px;
}
input#password {
    width: 150px;
    margin-right: 5px;
}
input#emailpassword {
    vertical-align: middle;
    margin-right: 5px;
}
input#forgot {
    width: 280px;
}
input.checkbox {
    border: 0;
    padding: 0;
}
p {	
    margin-bottom: 18px;
    text-align: left;
    font-size: 14px;
    line-height: 18px;
}
p em {
    font-style: italic;
    color: #a1a1a1;
}
p.success {
    color: #12863b;
    padding-bottom: 5px;
}
p.error {
    color: #cc2a2a;
    padding-bottom: 5px;
    background: url("images/login/alert-failure.gif") no-repeat 14px 14px;
    padding: 14px 14px 0px 35px;
    font-size: 8pt;
}
p.extraPad {
    margin-bottom: 30px;
}
#successBig {
    background: #e1ffd1;
    border-top: 1px solid #c5f8ac;
    border-bottom: 1px solid #c5f8ac;
    margin: 0 0 50px 0;
    padding: 5px 20px 15px 20px;
    text-align: left;
}
#successBig h1 {
    padding: 10px 0 3px 0;
    text-align: left;
    font-size: 20px;
    color: #000;
}
#successBig h2 {
    font-size: 16px;
    padding: 8px 10px;
    margin: 5px 0 15px 0;
    text-align: left;
    background: #c4edaf;
}
#successBig p {
    color: #535e51;
    padding: 0 0 10px 0;
    margin: 0;
}
#failure {
    background: #ffd1d1 url("alert-failure.gif") no-repeat 13px 11px;
    border-top: 1px solid #f8acac;
    border-bottom: 1px solid #f8acac;
    margin: 0;
    padding: 10px 10px 10px 35px;
}
#failure h3 {
    color: #8d3f3f;	
    font-size: 14px;
    font-weight: normal;
    margin: 0;
    padding: 0;
    text-align: left;
}
#desenvolvedor 
{
    text-align: center;
}
.failureMessage {
    background: #fff1f1;
    border-bottom: 1px solid #fddcdc;
    padding: 15px 20px 5px 20px;
    color: #664b4b;
    margin-bottom: 30px;
}
.clearButton {
    clear: both; 
    height: 1px;
    text-overflow: none;
}
span.formcancel {
    display: block;
    width: 60px;
    padding-top: 8px;
    float: left;
    color: #999;
}
.website 
{
	margin-top: -18px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
     
    <div id="additional"></div>
    <div id="formWrapper">
        <div id="formCasing">
        <h1>Login de acesso</h1>
        <p class="website"><a href="Default.aspx" style="text-decoration: none; color: #000"; title="Visitar o site"><%= Request.Url.Authority %></a></p>
            <div id="loginForm">
                <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Administrativo/Default.aspx" FailureText="Informe seus dados corretamente e tente novamente." LoginButtonText="Entrar" PasswordLabelText="Senha:" PasswordRequiredErrorMessage="Senha requerida." TextLayout="TextOnTop" UserNameLabelText="Usuário:" UserNameRequiredErrorMessage="Usuário requerido." onloginerror="Login1_LoginError">
                <LayoutTemplate>
                    <dl>
                        <dt><label for="username">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário</asp:Label></label>
                        </dt>
                        <dd>
                        <asp:TextBox ID="UserName" runat="server" CssClass="input_username" MaxLength="20" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Usuário requerido." ToolTip="Usuário requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                        </dd>
                        <dt><label for="password">
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha</asp:Label></label>
                        </dt>
                        <dd>
                        <asp:TextBox ID="Password" runat="server" CssClass="input_password" MaxLength="15" TextMode="Password" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Senha requerida." ToolTip="Senha requerida." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                        <span class="ajuda">&nbsp;<a href="LembraSenha.aspx">Esqueci minha senha</a></span>
                        </dd>
                        <dd>
                        <label for="remember_me">&nbsp;&nbsp;<asp:CheckBox ID="RememberMe" runat="server" Visible="False" CssClass="checkbox" TabIndex="3" Text="Lembrar de mim neste computador" /></label>
                        </dd>
                        <dd>
                        <asp:ImageButton ID="LoginButton" runat="server" AlternateText="Entrar" CommandName="Login" ImageUrl="images/login/login.gif" ValidationGroup="Login1"  TabIndex="4"/>
                        </dd>
                        <p class="error"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></p>
                    </dl>
                </LayoutTemplate>
                </asp:Login> 
            </div>
        </div>
    <div id="formFooter"></div>
    </div>
    
    <p id="desenvolvedor">Desenvolvido por: <a href='<%= ConfigurationManager.AppSettings["AdminSite"].ToString() %>' title='RAMOS Web Designer - Criação de Sites' target='_blank'>RAMOS Web Designer</a></p>
    
    </form>
</body>
</html>