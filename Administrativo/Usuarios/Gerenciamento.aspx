<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Gerenciamento.aspx.cs" Inherits="Administrativo_Usuarios_Gerenciamento" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
    <tr>
    <td valign="top"></td>
    <td valign="top"> 
    <table cellspacing="0" cellpadding="0" border="0" align="center" width="100%">
    <tr>
    <td align="center">
    <strong><font size="1" color="#333333">CONTAS DE USUÁRIOS</font></strong></td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td>
    <table border="0" cellpadding="0" cellspacing="0" align="center" width="100%">
    <tr>
    <td valign="top" align="center">
    <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" 
        Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" PageSize="15" 
            onrowdeleting="GridView1_RowDeleting" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcreated="GridView1_RowCreated">
        <FooterStyle Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E8EDDE" />
            <Columns>
            <asp:BoundField DataField="USERNAME" HeaderText="Nome de Usuário">
            <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="EMAIL" HeaderText="E-mail" >
            <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            
            <asp:CommandField ButtonType="Button" DeleteText="Excluir" ShowDeleteButton="true" 
                    HeaderText="Remover">
            
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            
            </Columns>
        <PagerStyle BackColor="#0066FF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#CFD9BB" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#3366FF" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#FF6600" />
        <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    <br />
    <asp:Label ID="LblMsg" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>	
        <br />
    <br />

    <fieldset>
    <legend><strong><font size="1" color="#333333">CONTROLE DE NÍVEL DE ACESSO DO USUÁRIO</font></strong></legend>
    <br />
        <table border="0" cellpadding="0" cellspacing="0" align="center" width="100%">
        <tr>
        <td><strong>Usuários(s):</strong></td>
        <td><strong>Regras:</strong></td>
        <td align="center"><strong>Adicionar / Remover</strong></td>
            <td>
                <strong>Regra(s) de <asp:Label ID="LabelUsuarioRegra" runat="server"></asp:Label></strong>
            </td>
        </tr>
        <tr>
        <td valign="top">
            <strong>
            <asp:ListBox ID="ListBoxUsuario" runat="server" Rows="8" Width="100%" AutoPostBack="True" onselectedindexchanged="ListBoxUsuario_SelectedIndexChanged" />
            </strong>
        </td>
        <td valign="top">
            <asp:ListBox ID="ListBoxRegra" runat="server" Rows="8" Width="100%" SelectionMode="Multiple">
            </asp:ListBox>
        </td>
        <td align="center">
            <asp:Button ID="BtnAdicionaRegra" runat="server" Text="&gt;&gt;&gt;" onclick="BtnAdicionaRegra_Click" />
            <br />
            <br />
            <asp:Button ID="BtnRemoveRegra" runat="server" Text="&lt;&lt;&lt;" Width="38px" onclick="BtnRemoveRegra_Click" />
        </td>
            <td valign="top">
                <asp:ListBox ID="ListBoxUsuarioRegra" runat="server" Rows="8" Width="100%" SelectionMode="Multiple">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
        <td></td>
        <td align="left">
            <asp:Button ID="BtnExcluiRegra" runat="server" OnClick="BtnExcluiRegra_Click" Text="-" />
            <asp:TextBox ID="TextBoxRegra" runat="server" MaxLength="20" />
            <asp:Button ID="BtnCriaRegra" runat="server" OnClick="BtnCriaRegra_Click" Text="+" />
            </td>
        <td></td>
            <td></td>
        </tr>
        <tr>
        <td colspan="4">
            &nbsp;</td>
        </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Msg" runat="server" ForeColor="maroon" />
                </td>
            </tr>
        </table>
    </fieldset>
       
    </td>
    </tr>
    </table>
    </td>
    </tr>
    </table>
    </table>
    
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>