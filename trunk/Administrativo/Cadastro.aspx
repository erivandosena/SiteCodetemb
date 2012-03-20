<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Cadastro.aspx.cs" Inherits="Administrativo_Cadastro" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><strong>Cadastro do Site</strong></p>
    <p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Nome ou razão social da empresa:<br />
        <asp:TextBox ID="TextBoxNome" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Nome de fantasia:<br />
        <asp:TextBox ID="TextBoxFantasia" runat="server" Width="500px" MaxLength="50"></asp:TextBox></p>
    <p>Slogan:<br />
        <asp:TextBox ID="TextBoxSlogan" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Nome do responsável:<br />
        <asp:TextBox ID="TextBoxResp" runat="server" Width="500px" MaxLength="50"></asp:TextBox></p>
    <p>CNPJ:<br />
        <asp:TextBox ID="TextBoxCNPJ" runat="server" Width="200px" MaxLength="18"></asp:TextBox></p>
    <p>Endereço:<br />
        <asp:TextBox ID="TextBoxEndereco" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Cidade:<br />
        <asp:TextBox ID="TextBoxCidade" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>Estado:<br />
        <asp:TextBox ID="TextBoxEstado" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>CEP:<br />
        <asp:TextBox ID="TextBoxCEP" runat="server" Width="100px" MaxLength="10"></asp:TextBox></p>
    <p>Website:<br />
        <asp:TextBox ID="TextBoxSite" runat="server" Width="250px" MaxLength="50"></asp:TextBox></p>
    <p>Telefone fixo:<br />
        <asp:TextBox ID="TextBoxTel1" runat="server" Width="200px" MaxLength="14"></asp:TextBox></p>
    <p>Telefone celular ou Fax:<br />
        <asp:TextBox ID="TextBoxTel2" runat="server" Width="200px" MaxLength="14"></asp:TextBox></p>
    <p>E-mail:<br />
        <asp:TextBox ID="TextBoxEmail1" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>MSN:<br />
        <asp:TextBox ID="TextBoxEmail2" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>Skype:<br />
        <asp:TextBox ID="TextBoxSkype" runat="server" Width="200px" MaxLength="20"></asp:TextBox></p>
    <p>Mapa de localização: (Largura máxima permitida de 273 pixels e altura de 650 pixels)<br />
        <FCKeditorV2:FCKeditor ID="FCKeditorMapa" runat="server" BasePath="~/fckeditor/" Height="500px" 
                                Width="350px"></FCKeditorV2:FCKeditor></p>
    <p>Publicidade topo da página inicial: (Largura máxima permitida, 900 pixels)<br />
        <FCKeditorV2:FCKeditor ID="FCKeditorPub1" runat="server" BasePath="~/fckeditor/" Height="300px" Width="100%"></FCKeditorV2:FCKeditor></p>
    <p>Publicidade base das páginas: (Largura máxima de 570 pixels X altura 160 pixels)<br />
        <FCKeditorV2:FCKeditor ID="FCKeditorPub2" runat="server" BasePath="~/fckeditor/" Height="300px" 
                                Width="700px"></FCKeditorV2:FCKeditor></p>
   <p>Logomarca:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
        <asp:Image ID="Image1" runat="server" />
        &nbsp;
        <asp:Button ID="Button4" runat="server" Text="Remove" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button4_Click"/>
    </p>
         
    <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
    
    <asp:Button ID="Button1" runat="server" Text="Salvar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click" /> 
    &nbsp;           
    <asp:Button ID="Button3" runat="server" Text="Excluir" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" Visible="False" onclick="Button3_Click"/>
</asp:Content>

