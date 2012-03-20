<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Senhas.aspx.cs" Inherits="Administrativo_Usuarios_Senhas" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td valign="top"></td>
    <td valign="top"> 
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" align="center">
            <tr>
            <td valign="top" colspan="2">
            <asp:ChangePassword ID="ChangePassword1" runat="server" 
            CancelDestinationPageUrl="/Administrativo/Usuarios/Default.aspx" 
            ContinueDestinationPageUrl="/Administrativo/Usuarios/Default.aspx" 
            CreateUserUrl="/Administrativo/Usuarios/Gerenciamento.aspx" DisplayUserName="True" 
            SuccessPageUrl="/Administrativo/Usuarios/Default.aspx" 
            CancelButtonText="Cancelar" ChangePasswordButtonText="Alterar Senha" 
            ChangePasswordFailureText="Senha incorreta ou Nova Senha inválida. Novo comprimento mínimo de senha: {0}. Caracteres não-alfanuméricos requerido: {1}." 
            ChangePasswordTitleText="&lt;b&gt;Alterar senha&lt;/b&gt;" 
            ConfirmNewPasswordLabelText="Confirmar Nova Senha:" 
            ConfirmPasswordCompareErrorMessage="Confirme a nova senha que deve corresponder à nova entrada de senha." 
            ConfirmPasswordRequiredErrorMessage="É necessário confirmar a nova senha. " 
            NewPasswordLabelText="Nova Senha:" 
            NewPasswordRegularExpressionErrorMessage="Por favor, digite uma senha diferente." 
            NewPasswordRequiredErrorMessage="É necessária nova senha." 
            PasswordLabelText="Senha:" PasswordRequiredErrorMessage="É exigido senha." 
            SuccessText="Sua senha foi alterada!" 
            SuccessTitleText="Alteração de senha completada." 
            UserNameLabelText="Nome de usuário:" 
            UserNameRequiredErrorMessage="É necessário nome de usuário.">
            </asp:ChangePassword>
            </td>
            </tr>
            <tr>
            <td valign="top">&nbsp;</td>
            <td valign="top">&nbsp;</td>
            </tr>
            </table>
        </td>
        </tr>
        </table>
    </td>
    <td valign="top"></td>
    </tr>
    </table>
</asp:Content>