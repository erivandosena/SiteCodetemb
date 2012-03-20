<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Links.ascx.cs" Inherits="WUC_Links" %>

    <h2>Links</h2>
    <ul>
        <asp:DataList ID="DataList3" runat="server" DataSourceID="DsLinksDireito" ShowFooter="False" ShowHeader="False" RepeatColumns="1" Width="270px" >
        <ItemTemplate>
            <li>
            <a href='http://<%# Eval("url_link", "{0}") %>' target="_blank" title='<%# Eval("url_link") %>'><%# Eval("url_nome")%></a>
            </li>
        </ItemTemplate>
        </asp:DataList>
    </ul>

    <asp:ObjectDataSource ID="DsLinksDireito" runat="server" SelectMethod="SelecionaUrlsDs" TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="url_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="url_nome" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
