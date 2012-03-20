<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="CadLinks.aspx.cs" Inherits="Administrativo_CadLinks" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><strong>Cadastro de Links</strong></p>
    <p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Título:<br />
        <asp:TextBox ID="TextBoxNome" runat="server" Width="300px" MaxLength="200"></asp:TextBox></p>
    <p>URL: Ex. www.site.com.br<br />
        <asp:TextBox ID="TextBoxUrl" runat="server" Width="500px" MaxLength="200"></asp:TextBox></p>
        
        <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>

    <asp:Button ID="Button1" runat="server" Text="Inserir/Atualizar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click" /> 
    &nbsp;           
    <asp:Button ID="Button2" runat="server" Text="Voltar" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button2_Click" 
               CausesValidation="False"/>
    &nbsp;           
    <asp:Button ID="Button3" runat="server" Text="Excluir" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button3_Click" 
               CausesValidation="False" Visible="False"/>
</asp:Content>

