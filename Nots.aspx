<%@ Page Language="C#" MasterPageFile="~/MasterPagePaginas.master" AutoEventWireup="true" CodeFile="Nots.aspx.cs" Inherits="Nots" Title="Untitled Page" %>

<%@ Register src="WUC_Links.ascx" tagname="WUC_Links" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="LabelPublicidade" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:GridView ID="GVNoticias" runat="server" 
            AutoGenerateColumns="False" 
            GridLines="None" 
            Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" AllowPaging="True" 
            onpageindexchanging="GVNoticias_PageIndexChanging" 
    ShowHeader="False" PageSize="50" CellPadding="4" ForeColor="#333333">
            <FooterStyle BackColor="#4A3D24" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="not_data" DataFormatString="{0:dd/MM/yyyy}" 
                    ShowHeader="False">
                    <HeaderStyle Font-Bold="True" />
                    <ItemStyle Font-Bold="True" Font-Size="8pt" ForeColor="#464646" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="not_cod" 
                    DataNavigateUrlFormatString="Not.aspx?n={0}" 
                    DataTextField="texto_resumido" ShowHeader="False">
                    <HeaderStyle Font-Bold="False" 
                        Font-Underline="False" />
                    <ItemStyle Font-Underline="False" />
                </asp:HyperLinkField>
            </Columns>
            <PagerStyle BackColor="#4A3D24" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        
     <asp:Label ID="LblMsg" runat="server"></asp:Label>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_Links ID="WUC_Links1" runat="server" />
</asp:Content>

