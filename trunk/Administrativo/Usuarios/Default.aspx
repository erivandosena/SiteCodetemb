<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrativo_Usuarios_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="350" align="center">
    <tr>
    <td valign="top"></td>
    <td valign="top"> 
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
        <td align="center">
        <font color="#666666"><strong>Selecione uma opção:</strong></font></td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td> 
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
        <td align="center" valign="top" width="300">
        <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="/images/cad_usuario.gif" AlternateText="Novo" 
                PostBackUrl="CadUsuario.aspx" CausesValidation="False" Width="37px" /><br />Usuário</td>
        <td align="center" valign="top" width="300">
        <asp:ImageButton ID="ImageButton2" runat="server" 
                ImageUrl="/Images/troca_senha.gif" AlternateText="Alterar" 
                PostBackUrl="Senhas.aspx" CausesValidation="False" /><br />Senha</td>
        <td align="center" valign="top" width="300">
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="/Images/config.gif" 
                AlternateText="Configurar" PostBackUrl="Gerenciamento.aspx" 
                CausesValidation="False" /><br />Gerenciamento</td>
        </tr>
        <tr>
        <td align="center" valign="top" colspan="3"></td>
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

