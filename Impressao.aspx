<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Impressao.aspx.cs" Inherits="Impressao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Impressão</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table cellspacing="0" cellpadding="0" width="555" border="0" align="center">
	<tr>
	  <td>
        <ASP:Label id="LabelTitulo" runat="server" Font-Bold="True" Font-Names="Georgia, Times New Roman, Arial, Times, serif" Font-Size="18pt"></ASP:Label></td>
    </tr>
    <tr>
	  <td><br></td>
    </tr>
    <tr>
      <td>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
              <td>
                <ASP:Label id="LabelPublicado" runat="server" Font-Names="Arial" Font-Size="10pt"></ASP:Label></td>
            </tr>
            <tr>
              <td>
                <ASP:Label id="LabelAtualizado" runat="server" Font-Names="Arial" Font-Size="10pt"></ASP:Label></td>
            </tr>
            <tr>
              <td>
        <ASP:Label id="LabelAutor" runat="server" Font-Names="Arial" Font-Size="10pt"></ASP:Label></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>
          <asp:Label ID="LabelLegenda" runat="server" Font-Names="Arial" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
        </table></td>
    </tr>
    <tr>
      <td>
          <asp:Image ID="ImageNoticia" runat="server" />
        </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>
        <ASP:Label id="LabelTextoResumo" runat="server" Font-Names="Georgia, Times New Roman, Arial, Times, serif"></ASP:Label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>
        <ASP:Label id="LabelTexto" runat="server"></ASP:Label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
	  <td>
        <ASP:Label id="LabelFonte" runat="server" Font-Names="Arial" Font-Size="10pt"></ASP:Label><br></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
