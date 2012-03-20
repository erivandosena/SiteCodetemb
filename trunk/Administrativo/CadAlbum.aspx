<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="CadAlbum.aspx.cs" Inherits="Administrativo_CadAlbum" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script src="../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="../Scripts/Plugins/MultipleFileUpload/jquery.MultiFile.js" type="text/javascript"></script>

  <div>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <strong>ÁLBUM</strong><br />
            <p>Código: &nbsp;<asp:Label ID="LabelCodigo" runat="server"></asp:Label></p>
            <p>Nome do álbum:<br />
            <asp:TextBox ID="TxtNome" runat="server" Width="400px" MaxLength="100"></asp:TextBox></p>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <strong>FOTO</strong><br />
            <p>
            Localizar fotografia:<br />
            <asp:FileUpload ID="FileUpload1" runat="server" class="multi" accept="jpg|gif|png" maxlength="10" />
            &nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
            </p>
            <p>Legenda da foto:<br />
            <asp:TextBox ID="TxtFotoLegenda" runat="server" MaxLength="150" Width="600px"></asp:TextBox></p>
            <p><asp:Label ID="LblMsgFot" runat="server"></asp:Label></p>
            <p>Fotos do Álbum: <asp:Label ID="LabelAlbum" runat="server" Font-Bold="True" Font-Size="12pt"></asp:Label></p>
            <p>
            <asp:DataList ID="DlFotos" runat="server" CellSpacing="10" DataKeyField="fot_cod" 
                    DataSourceID="DsFotos" EnableViewState="False" RepeatColumns="4" 
                    RepeatDirection="Horizontal" Width="100%">
                <ItemTemplate>
                    <table bgcolor="#E9E9E9" border="0" cellpadding="0" cellspacing="5" width="139">
                    <tr>
                    <td bgcolor="#FFFFFF" valign="top" align="center">
                    <img alt="" border="0" src='../HandlerImgs.ashx?foto=<%# Eval("fot_cod") %>&Tamanho=M'></img>
                    </td>
                    </tr>
                    <tr>
                    <td bgcolor="#E9E9E9" valign="top">
                    <%# Eval("fot_legenda")%>
                    <p align="center">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# "CadAlbum.aspx?codalbum=" + Request.QueryString["codalbum"] + "&codfoto=" + Eval("fot_cod") + "&opcao=atualiza" %>' onclick="LinkButton1_Click">Atualizar</asp:LinkButton>
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# "CadAlbum.aspx?codalbum=" + Request.QueryString["codalbum"] + "&codfoto=" + Eval("fot_cod") + "&opcao=exclui" %>' OnClientClick="return confirm('Tem certeza de que deseja excluir?');" onclick="LinkButton2_Click">Excluir</asp:LinkButton>
                    </p>
                    </td>
                    </tr>
                    </table>
                </ItemTemplate>
                <AlternatingItemStyle VerticalAlign="Top" />
                <ItemStyle VerticalAlign="Top" />
            </asp:DataList></p>
        </asp:Panel>
  </div>
        <asp:ObjectDataSource ID="DsFotos" runat="server" 
            SelectMethod="SelecionaFotoAlbumDs" TypeName="Rwd.BLL.BusinessLogic" 
            OldValuesParameterFormatString="original_{0}">
           <SelectParameters>
               <asp:Parameter Name="fot_cod" Type="Int32" DefaultValue="" />
               <asp:QueryStringParameter Name="alb_cod" QueryStringField="codalbum" Type="String" DefaultValue="" />
               <asp:Parameter Name="fot_legenda" Type="String" DefaultValue="" />
           </SelectParameters>
        </asp:ObjectDataSource>
        
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
               CausesValidation="False" Visible="False" onclick="Button3_Click"/>
       &nbsp; 
       <asp:Button ID="Button5" runat="server" Text="Adicionar e Gerenciar Fotografias" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button5_Click"/>
       <p></p>
       <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
</asp:Content>

