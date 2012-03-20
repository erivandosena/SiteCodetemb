<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Destaque.ascx.cs" Inherits="WUC_Destaque" %>

    <h3>Destaque</h3>
    <ul>
        <asp:DataList ID="DataList4" runat="server" DataSourceID="DsLinksDireito" ShowFooter="False" ShowHeader="False" RepeatColumns="6" RepeatLayout="Flow" RepeatDirection="Horizontal" >
        <ItemTemplate>
            <li>
            <span>
            <a href="<%# Eval("pag_cod", "Conteudo.aspx?pag={0}") %>" title="<%# Eval("pag_descricao") %>"><%# Eval("pag_nome")%></a>
            </span>
            </li>
        </ItemTemplate>
        </asp:DataList>
    </ul>

    <asp:ObjectDataSource ID="DsLinksDireito" runat="server" SelectMethod="SelecionaPaginasDs" TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="pag_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="pag_nome" Type="String" />
        <asp:Parameter DefaultValue="DIREITO" Name="pag_menu" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
