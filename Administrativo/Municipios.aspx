<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Municipios.aspx.cs" Inherits="Administrativo_Municipios" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p><strong>Cidades Cadastradas</strong></p>
<p>
       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" 
                Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" 
               onpageindexchanging="GridView1_PageIndexChanging">
                <PagerSettings PageButtonCount="20" />
                <FooterStyle Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#ECECFF" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="mun_cod" 
                        DataNavigateUrlFormatString="~/Administrativo/CadMunicipios.aspx?codmunicipio={0}" 
                        DataTextField="mun_cod" 
                        DataTextFormatString="&lt;strong&gt;Alterar / Excluir&lt;/strong&gt;" 
                        HeaderText="Edição" Text="Alterar">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="mun_nome" HeaderText="Município">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mun_cep" HeaderText="CEP">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="mun_site" HeaderText="Website">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle BackColor="#6CAFC2" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#6CAFC2" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#004080" />
                <AlternatingRowStyle BackColor="White" />
       </asp:GridView>
       
       </p>
       <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>
       <p><asp:Button ID="Button1" runat="server" Text="Cadastrar Nova" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click"/>
       </p>
</asp:Content>

