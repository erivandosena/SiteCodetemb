<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="CadUsuario.aspx.cs" Inherits="Administrativo_Usuarios_CadUsuario" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type='text/javascript'>
function iframeAutoHeight(quem){ 
    if(navigator.appName.indexOf("Internet Explorer")>-1){ //ie sucks
        var func_temp = function(){
            var val_temp = quem.contentWindow.document.body.scrollHeight + 15
            quem.style.height = val_temp + "px";
        }
        setTimeout(function() { func_temp() },100) //ie sucks
    }else{
        var val = quem.contentWindow.document.body.parentNode.offsetHeight + 15
        quem.style.height= val + "px";
    }    
}
</script>

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
        <td valign="top"></td>
        <td valign="top"> 
            <table cellspacing="0" cellpadding="0" border="0" align="center" width="100%">
            <tr>
            <td>&nbsp;</td>
            </tr>
            <tr>
            <td>
            <table border="0" cellpadding="0" cellspacing="0" align="center">
            <tr>
            <td valign="top" colspan="2">
            
            <iframe name="IfNovoUsuario" align="middle" marginwidth="0" marginheight="0" src="NovoUsuario.aspx" frameborder="0" scrolling="auto" onload="iframeAutoHeight(this)" allowtransparency="true" width="900"></iframe>
 
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
        <td valign="top">
        </td>
        </tr>
        </table>
</asp:Content>