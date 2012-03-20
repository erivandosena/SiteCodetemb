<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="CadMunicipios.aspx.cs" Inherits="Administrativo_CadMunicipios" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><strong>Cadastro de Cidades</strong></p>
    <p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Município:<br />
        <asp:TextBox ID="TextBoxCidade" runat="server" Width="300px" MaxLength="100"></asp:TextBox></p>
    <p>CEP:<br />
        <asp:TextBox ID="TextBoxCep" runat="server" Width="150px" MaxLength="10"></asp:TextBox></p>
    <p>Gestor:<br />
        <asp:TextBox ID="TextBoxGestor" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Estado:<br />
        <asp:TextBox ID="TextBoxEstado" runat="server" Width="300px" MaxLength="20"></asp:TextBox></p>
    <p>Website: Ex. www.site.com.br<br />
        <asp:TextBox ID="TextBoxSite" runat="server" Width="500px" MaxLength="50"></asp:TextBox></p>
    <p>Mapa de localização: (Largura máxima permitida de 900 pixels e altura de 400 pixels)<br />
        <FCKeditorV2:FCKeditor ID="FCKeditorMapa" runat="server" BasePath="~/fckeditor/" Height="300px" Width="100%"></FCKeditorV2:FCKeditor></p>
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

    <asp:Button ID="Button1" runat="server" Text="Inserir/Atualizar" 
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
</asp:Content>

