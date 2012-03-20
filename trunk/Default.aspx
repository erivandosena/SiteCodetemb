<%@ Page Language="C#" MasterPageFile="~/MasterPagePaginas.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register src="WUC_Links.ascx" tagname="WUC_Links" tagprefix="uc1" %>

<%@ Register src="WUC_Destaque.ascx" tagname="WUC_Destaque" tagprefix="uc2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <asp:Label ID="LabelPublicidade" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

    <div id="banner">

<iframe name="iframe" align="middle" marginwidth="0" marginheight="0" src="Mapa.aspx" 
            frameborder="0" scrolling="auto" onload="iframeAutoHeight(this)" 
            allowTransparency="true" width='565'></iframe>

</div>
<div class="post">
   <h2 class="title">
    <a href='<%= ImageNoticia.PostBackUrl %>'>
    <asp:Label ID="LabelTitulo" runat="server"></asp:Label>
    </a>
   </h2>
	<p class="meta">
     <asp:Label ID="LabelLegenda" runat="server"></asp:Label>
    </p>
	<div class="entry"></div>
</div>
      <asp:Panel ID="PanelNoticia" runat="server">
        <asp:ImageButton ID="ImageNoticia" runat="server" hspace="5" ImageAlign="Left" CausesValidation="False" />
        <asp:Label ID="LabelResumo" runat="server"></asp:Label>
          <br /><a href='<%= ImageNoticia.PostBackUrl %>' class="more">Ler mais</a>
          &nbsp;&nbsp;&nbsp;
        <a href="Nots.aspx" class="comments">Leia outras</a>
      </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <uc1:WUC_Links ID="WUC_Links1" runat="server" />
    <p> </p>
    <uc2:WUC_Destaque ID="WUC_Destaque1" runat="server" />
    <p> </p>

</asp:Content>
