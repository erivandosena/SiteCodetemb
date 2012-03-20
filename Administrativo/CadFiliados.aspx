<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="CadFiliados.aspx.cs" Inherits="Administrativo_CadFiliados" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><strong>Cadastro de Filiados</strong></p>
    <p>Código:&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></p>
    <p>Município:<br />
        <asp:DropDownList ID="DDListCidades" runat="server">
        </asp:DropDownList></p>
    <p>Nome da instituição:<br />
        <asp:TextBox ID="TextBoxFiliado" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Tipo:<br />
        <asp:DropDownList ID="DDListTipo" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Poder Público</asp:ListItem>
            <asp:ListItem>Sociedade Civil</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Nome do Representante:<br />
        <asp:TextBox ID="TextBoxResp" runat="server" Width="500px" MaxLength="200"></asp:TextBox></p>
    <p>Endereço da instituição:<br />
        <asp:TextBox ID="TextBoxEndereco" runat="server" Width="500px" MaxLength="100"></asp:TextBox></p>
    <p>Telefone:<br />
        <asp:TextBox ID="TextBoxTel" runat="server" Width="300px" MaxLength="14"></asp:TextBox></p>
    <p>E-mail:<br />
        <asp:TextBox ID="TextBoxEmail" runat="server" Width="300px" MaxLength="50"></asp:TextBox></p>
    <p>Website: Ex. www.nome.com.br<br />
        <asp:TextBox ID="TextBoxSite" runat="server" Width="500px" MaxLength="50"></asp:TextBox></p>
    <p>Logomarca da instituição:<br />
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