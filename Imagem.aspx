<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imagem.aspx.cs" Inherits="Imagem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Imagem</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <!-- <a href='Ampliado.aspx?i=<%= Request.QueryString["i"] %>' target='_parent' style="text-decoration: none"> --> 
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <!-- </a> -->
    </div>
    </form>
</body>
</html>
