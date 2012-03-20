<%@ Page Language="C#" MasterPageFile="~/MasterPagePaginas.master" AutoEventWireup="true" CodeFile="Filiados.aspx.cs" Inherits="Filiados" Title="Untitled Page" %>

<%@ Register src="WUC_Links.ascx" tagname="WUC_Links" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Label ID="LabelPublicidade" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:DataList ID="DataList1" runat="server" 
        DataKeyField="mun_nome" DataSourceID="DsMunicipios" 
        Width="565px" onselectedindexchanged="DataList1_SelectedIndexChanged">
        <HeaderTemplate>
            
            <table cellpadding="0" cellspacing="0" style="width: 565px">
                <tr>
                    <td>
                        <h3>Todas as Representações Municipais</h3></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
        </HeaderTemplate>
        <SelectedItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width: 565px">
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="select" Text='<%# Eval("mun_nome") %>' Font-Bold="True" Font-Size="14" style="text-decoration: none"></asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <asp:DataList ID="DataList2" runat="server" CellPadding="4" 
                DataKeyField="mun_nome" DataSourceID="DsFiliados" ForeColor="#333333" 
                Width="565px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EEFFDD" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" style="width: 565px">
                        <tr>
                            <td>
                            
                                <ul>
                                <li><strong><%# Eval("fil_responsavel")%></strong> (<i><%# Eval("fil_tipo")%></i>)</li>
                                <li><a href='FiliadoDetalhe.aspx?f=<%# Eval("fil_cod")%>'><%# Eval("fil_nome")%></a></li>
                                </ul>
                                
                                </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList><br />
            <a href="Filiados.aspx">&lt;&lt; Ocultar</a>
            <p>&nbsp;</p>
            
        </SelectedItemTemplate>
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width: 565px">
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="select" Text='<%# Eval("mun_nome") %>' Font-Bold="True" Font-Size="12"></asp:LinkButton>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    [ <a href="Default.aspx">Visualizar individualmente pelo mapa</a> ]

    <asp:ObjectDataSource ID="DsMunicipios" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelecionaMunicipiosDs" TypeName="Rwd.BLL.BusinessLogic">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="mun_cod" Type="Int32" />
            <asp:Parameter DefaultValue="%" Name="mun_nome" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="DsFiliados" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelecionaFiliadosMunicipiosDs" TypeName="Rwd.BLL.BusinessLogic">
            <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="fil_cod" Type="Int32" />
                <asp:ControlParameter ControlID="DataList1" DefaultValue="" Name="mun_nome" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_Links ID="WUC_Links1" runat="server" />
</asp:Content>

