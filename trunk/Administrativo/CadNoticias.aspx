<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="CadNoticias.aspx.cs" Inherits="Administrativo_CadNoticias" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <p><strong>Cadastro da Notícia</strong></p>
       <asp:Panel ID="Panel1" runat="server" Visible="False">
        <b>NOTÍCIA</b><br />
        <p>Código: &nbsp;<asp:Label ID="LabelCodigo" runat="server"></asp:Label></p>
        <p>Legenda da notícia:<br />
        <asp:TextBox ID="TxtLegenda" runat="server" Width="150px" MaxLength="30"></asp:TextBox></p>
        <p>Título:<br />
        <asp:TextBox ID="TxtTitulo" runat="server" Width="583px" MaxLength="100"></asp:TextBox></p>
        <p>Resumo:<br />
            <asp:TextBox ID="TextResumo" runat="server" Height="130px" Width="100%" 
                TextMode="MultiLine"></asp:TextBox></p>
            <p>Texto da Notícia:<br />
            <FCKeditorV2:FCKeditor ID="FCKeditorNoticia" runat="server" BasePath="~/fckeditor/" 
                    Height="600px" Width="100%">
            </FCKeditorV2:FCKeditor></p>
                <p>Autor:<br />
                    <asp:TextBox ID="TxtAutor" runat="server" MaxLength="50" Width="200px"></asp:TextBox></p>
                <p>E-mail do autor:<br />
                    <asp:TextBox ID="TxtEmailAutor" runat="server" MaxLength="100" Width="300px"></asp:TextBox></p>
                <p>Fonte da Publicação:<br />
                    <asp:TextBox ID="TxtFonte" runat="server" MaxLength="100" Width="200px">Website CODETEMB</asp:TextBox></p>
                <p>&nbsp;</p>
        </asp:Panel>
       
        <asp:Panel ID="Panel2" runat="server" Visible="False">
        <p>Selecione a notícia:
                <asp:DropDownList ID="DropDownListNot" runat="server" Width="585px">
                </asp:DropDownList></p>
        </asp:Panel>
        
        <asp:Panel ID="Panel5" runat="server" Visible="False">
        <p><asp:Label ID="LabelNoticia" runat="server" Font-Bold="True" Font-Size="12pt"></asp:Label></p>
        </asp:Panel>
        
        <asp:Panel ID="Panel3" runat="server" Visible="False">
        <b>IMAGEM</b><br />
        <p>Localizar imagem:<br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            &nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label></p>
            <p>Legenda da imagem:<br />
            <asp:TextBox ID="TxtImgLegenda" runat="server" MaxLength="100" Width="500px"></asp:TextBox></p>
        <p><asp:Label ID="LblMsgNot" runat="server"></asp:Label></p>
        <p>Imagens da notícia:</p>
        <p>
        <asp:DataList ID="DlImagnes" runat="server" CellSpacing="10" DataKeyField="IMA_COD" DataSourceID="DsImagens" EnableViewState="False" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
            <ItemTemplate>
                <table align="center" bgcolor="#E9E9E9" border="0" cellpadding="0" cellspacing="5" width="139">
                <tr>
                <td bgcolor="#FFFFFF" valign="top">
                <img alt="" border="0" src='../HandlerImgs.ashx?Img=<%# Eval("ima_cod") %>&Tamanho=M'></img>
                </td>
                </tr>
                <tr>
                <td bgcolor="#E9E9E9" valign="top">
                <%# Eval("ima_legenda") %>
                <br /><br />
                <p align="center">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# "CadNoticias.aspx?codnoticia=" + Request.QueryString["codnoticia"] + "&codimg=" + Eval("ima_cod") + "&opcao=atualiza" %>' onclick="LinkButton1_Click">Atualizar</asp:LinkButton>
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# "CadNoticias.aspx?codnoticia=" + Request.QueryString["codnoticia"] + "&codimg=" + Eval("ima_cod") + "&opcao=exclui" %>' onclick="LinkButton2_Click" OnClientClick="return confirm('Tem certeza de que deseja excluir?');">Excluir</asp:LinkButton>
                </p>
                </td>
                </tr>
                </table>
            </ItemTemplate>
        </asp:DataList></p>
        <asp:ObjectDataSource ID="DsImagens" runat="server" SelectMethod="SelecionaImagensnoticiaDs" TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
           <SelectParameters>
               <asp:QueryStringParameter DefaultValue="0" Name="not_cod" QueryStringField="codnoticia" Type="String" />
           </SelectParameters>
        </asp:ObjectDataSource>
        </asp:Panel>
       
       <asp:Panel ID="Panel4" runat="server" Visible="False">
       <b>PUBLICAÇÃO</b><br />
       <p>Autorização de Publicação:&nbsp; 
       <asp:DropDownList ID="DDL_Status" runat="server">
            <asp:ListItem>Selecione...</asp:ListItem>
            <asp:ListItem Value="A">Publicar</asp:ListItem>
            <asp:ListItem Value="R">Suspender</asp:ListItem>
       </asp:DropDownList></p>
       </asp:Panel>

       <asp:Button ID="Button1" runat="server" Text="Salvar/Atualizar/Confirma/Adiciona" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click" />
       &nbsp; 
       <asp:Button ID="Button2" runat="server" Text="Voltar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="Button2_Click"/>
       &nbsp; 
       <asp:Button ID="Button3" runat="server" Text="Excluir" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="Button3_Click" Visible="False"/>
       &nbsp; 
       <asp:Button ID="Button4" runat="server" Text="Autorizar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="Button4_Click" Visible="False"/>
       &nbsp; 
       <asp:Button ID="Button5" runat="server" Text="Inserir Imagem" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button5_Click"/>
       <p>&nbsp;</p>
       <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
</asp:Content>