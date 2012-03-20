<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Noticias.aspx.cs" Inherits="Administrativo_Noticias" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><strong>Notícias Cadastradas</strong></p>
       <p>
       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" 
                Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" 
               onpageindexchanging="GridView1_PageIndexChanging" 
               onrowcreated="GridView1_RowCreated">
                <FooterStyle Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#ECECFF" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="not_cod" 
                        DataNavigateUrlFormatString="~/Administrativo/CadNoticias.aspx?codnoticia={0}" 
                        DataTextField="not_cod" 
                        DataTextFormatString="&lt;strong&gt;Alterar / Excluir / Autorizar&lt;/strong&gt;" 
                        HeaderText="Edição" Text="Alterar">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="not_titulo" HeaderText="Título" >
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Publicação" DataField="not_data" 
                        DataFormatString="{0:d}" >
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("not_status") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("not_status") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#6CAFC2" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFFFF4" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#6CAFC2" Font-Bold="True" ForeColor="White" />
                <EditRowStyle />
                <AlternatingRowStyle BackColor="White" />
       </asp:GridView>
       </p>
       <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
       <p><asp:Button ID="Button1" runat="server" Text="Cadastrar Nova" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click"/>
       </p>
</asp:Content>

