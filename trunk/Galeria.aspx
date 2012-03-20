<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Galeria.aspx.cs" Inherits="Galeria" Title="Untitled Page" %>

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

		<div class="gts-1">
			<div class="gts-1-1" align="center">
			
	    <asp:DataList ID="DlImagnes" runat="server" CellSpacing="3" DataKeyField="ima_cod" 
                    DataSourceID="DsImagens" EnableViewState="False" RepeatColumns="8" 
                    RepeatDirection="Horizontal" Width="700px" Height="100%">
            <ItemTemplate>
	            <div class="imgts-1">
		            <div align="center" class="imgts-1-1">
		            <a href="<%# Eval("ima_cod", "../Imagem.aspx?i={0}") %>" target="If_imagem" class="imggen-2">
		            <img title="Clique para ampliar visualização" alt="Imagem reduzida" src="../HandlerImgs.ashx?Img=<%# Eval("ima_cod") %>&amp;Tamanho=M" width="60" class="imggen-3"></img></a> 
		            </div>
	            </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="DsImagens" runat="server" SelectMethod="SelecionaImagensnoticiaDs" TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
           <SelectParameters>
               <asp:QueryStringParameter DefaultValue="0" Name="not_cod" QueryStringField="n" Type="String" />
           </SelectParameters>
        </asp:ObjectDataSource>
			
			</div>
			<div class="gts-1-2">&nbsp;</div>
			<div class="gts-1-2">
            <p align="center">
            <iframe name='If_imagem' align='middle' marginwidth='0' marginheight='0' src='Imagem.aspx?i=<%= Request.QueryString["i"] %>' frameborder='0' scrolling='auto' onload='iframeAutoHeight(this)' allowtransparency='true' width='900'></iframe>
            </p>
			</div>
			<div class="gts-1-2">&nbsp;</div>
<p align="center"><input onclick="history.go(-1)" type="button" value="Voltar" /></p>
		</div>
</asp:Content>