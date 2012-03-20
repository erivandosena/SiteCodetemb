<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Filiado.aspx.cs" Inherits="Filiado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maciço de Baturité</title>
    <link href="stylepaginas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
        <ul>
        <h3><%= Request.QueryString["filiado"] %> - Representação Municipal</h3>
        <asp:DataList ID="DataList1" runat="server" ShowFooter="False" ShowHeader="False" RepeatColumns="1" Width="564px" >
        <ItemTemplate>
		    <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top">
                    <li><strong><%# Eval("fil_responsavel")%></strong> (<i><%# Eval("fil_tipo")%></i>)</li>
                    <li><a href='FiliadoDetalhe.aspx?f=<%# Eval("fil_cod")%>' target="_parent"><%# Eval("fil_nome")%></a></li>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        
		</ItemTemplate>
        </asp:DataList>	
	</ul>
	<p></p>   
         <p align="left"><a href="../Mapa.aspx" target="iframe"><strong>Retornar</strong></a> | <a href="../Filiados.aspx" target="_parent">Visualizar todos</a></p>
    </form>
    
</body>
</html>
