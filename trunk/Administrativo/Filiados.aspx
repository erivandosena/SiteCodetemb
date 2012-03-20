<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Filiados.aspx.cs" Inherits="Administrativo_Filiados" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p><strong>Filiados Cadastrados</strong></p>
<p>
       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" 
                Width="100%" Font-Names="Trebuchet MS" Font-Size="10pt" 
               onpageindexchanging="GridView1_PageIndexChanging" PageSize="12">
                <PagerSettings PageButtonCount="20" />
                <FooterStyle Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#ECECFF" />
                <Columns>
                    <asp:TemplateField HeaderText="Edição">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "CadFiliados.aspx?codfiliado=" + Eval("fil_cod") + "&codmunicipio=" + Eval("mun_cod") %>' Text='<strong>Alterar / Excluir</strong>'></asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="fil_nome" HeaderText="Instituição">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fil_tipo" HeaderText="Tipo">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fil_telefone" HeaderText="Telefone">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fil_responsavel" HeaderText="Representante">
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
       <p><asp:Button ID="Button1" runat="server" Text="Cadastrar Novo" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" onclick="Button1_Click" 
               style="margin-bottom: 0px"/>
       </p>
</asp:Content>

