<%@ Page Language="C#" MasterPageFile="~/MasterPagePaginas.master" AutoEventWireup="true" CodeFile="Not.aspx.cs" Inherits="Not" Title="Untitled Page" %>

<%@ Register src="WUC_Links.ascx" tagname="WUC_Links" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="LabelPublicidade" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

var tam = 15;

function mudaFonte(tipo,elemento){
	if (tipo=="mais") {
		if(tam<24) tam+=1;
		createCookie('fonte',tam,365);
	} else {
		if(tam>10) tam-=1;
		createCookie('fonte',tam,365);
	}
	document.getElementById('txt_home').style.fontSize = tam+'px';

}

function createCookie(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	} else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++)
	{
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
}
</script>


<div id="noticia-1" class="post">
    <h1><asp:Label ID="Lbl_Titulo" runat="server"></asp:Label></h1>
    <br />
    <asp:Label ID="Lbl_DatPub" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Lbl_DatAtualizacao" runat="server"></asp:Label>
    <p></p>
    <asp:Label ID="Lbl_Legenda" runat="server" CssClass="meta"></asp:Label>
    <br />
    <div id="noticia-1-8">
				<div id="noticia-2">
					<div id="noticia-col">
						<div id="noticia-2-1">
						   <asp:Label ID="Lbl_Resumo" runat="server"></asp:Label>
                        </div>
					</div>
					<div id="noticia-col">
						<div id="noticia-2-2"></div>
					</div>
					<div id="noticia-col">
						<div id="noticia-2-3" align="right">
						   <strong><a href="Indicacao.aspx?n=<%= Request.QueryString["n"] %>" title="Indicar notícia">
                           <img alt="Indicar" title="Envie para alguém" src="Images/enviar_mail.gif" border="0" /></a></strong>
                        </div>
						<div id="noticia-2-4" align="right">
						   <strong><a target="_blank" href="Impressao.aspx?n=<%= Request.QueryString["n"] %>" title="Imprimir notícia">
                           <img alt="Imprimir" title="Imprimir" src="Images/imprimir.gif" border="0" /></a></strong>
						</div>
				    </div>
		     </div>
    </div>
    
    <asp:ImageButton ID="ImageNoticia" runat="server" CausesValidation="False" />
    <br />
    <asp:Label ID="LabelImgLegenda" runat="server"></asp:Label>
    <p>&nbsp;</p>
    <asp:Label ID="Lbl_Autor" runat="server"></asp:Label>
    <p align="right">
    Tamanho da fonte:
        <a id="fontemenor" href="javascript:void(0);" title="Diminuir Fonte" Onclick="mudaFonte('menos'); return false">-A</a>
        <a id="fontemaior" href="javascript:void(0);" title="Aumentar Fonte" Onclick="mudaFonte('mais'); return false">+A</a> 
    </p>
    <div id="txt_home">
    <asp:Label ID="Lbl_Noticia" runat="server" CssClass="espacolinhas"></asp:Label>
    </div>
    <p></p>
    <asp:Label ID="Lbl_Fonte" runat="server"></asp:Label>
    <p></p>
    <asp:Label ID="Lbl_Visualizacao" runat="server"></asp:Label>
    <p></p>
    [ <a href="Nots.aspx" title="Clique aqui para listar todas as notícias do site">Outras publicações</a> ]
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_Links ID="WUC_Links1" runat="server" />
</asp:Content>

