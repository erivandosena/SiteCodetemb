<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Fotos.aspx.cs" Inherits="Fotos" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Scripts/Plugins/Lightbox/css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Scripts/Plugins/Lightbox/js/jquery.lightbox-0.5.js" type="text/javascript"></script>
    
    <script type="text/javascript">
    $(document).ready(function()
    {
    $("#album a").lightBox();
    }); 
    </script>
    
    <asp:DataList ID="DataList1" runat="server" DataKeyField="alb_cod" DataSourceID="DsAlbuns" Width="565px" onselectedindexchanged="DataList1_SelectedIndexChanged">
        <HeaderTemplate>
            
            <table cellpadding="0" cellspacing="0" style="width: 900px">
                <tr>
                    <td>
                        <h3>Acervo de fotos</h3>
                        <i>Clique no nome do álbum para visualizar as fotografias.</i> </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
        </HeaderTemplate>
        <SelectedItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width: 900px">
                <tr>
                    <td>
                        Visualizando o álbum: <asp:LinkButton ID="LinkButton1" runat="server" CommandName="select" Text='<%# Eval("alb_nome") %>' Font-Bold="True" Font-Size="14" style="text-decoration: none"></asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <asp:DataList ID="DataList2" runat="server" CellPadding="4" 
                DataKeyField="alb_cod" DataSourceID="DsFotos" 
                Width="900px" RepeatDirection="Horizontal" RepeatColumns="5" 
                BorderColor="#F7F7F7" BorderWidth="1px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingItemStyle BackColor="#F9F9F9" VerticalAlign="Top" />
                <ItemStyle BackColor="#F9F9F9" VerticalAlign="Top" />
                <SelectedItemStyle BackColor="#4A2500" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                <div id="album">
                    <table border="0" cellpadding="0" cellspacing="5" align="center" 
                        style="width: 100px">
                    <tr>
                    <td bgcolor="#FFFFFF" valign="top" align="center">
                    
                    <a href='../HandlerImgs.ashx?foto=<%# Eval("fot_cod") %>&amp;Tamanho=N'>
                    <img alt="Clique na foto para ampliar" border="0" src='../HandlerImgs.ashx?foto=<%# Eval("fot_cod") %>&amp;Tamanho=M' style="border: #fdfdfd 6px solid"></img>
                    </a>
                    
                    </td>
                    </tr>
                    <tr>
                    <td valign="top" style="color: #333333; font-size: 10pt; font-family: Arial;">
                    <%# Eval("fot_legenda")%>
                    </td>
                    </tr>
                    </table>
                 </div>
                </ItemTemplate>
            </asp:DataList><br />
            <a href="Fotos.aspx">&lt;&lt; <i>Fechar este álbum</i> </a>
            <p>&nbsp;</p>
            
        </SelectedItemTemplate>
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width: 880px">
                <tr>
                    <td>
                        Álbum: <asp:LinkButton ID="LinkButton1" runat="server" CommandName="select" Text='<%# Eval("alb_nome") %>' Font-Bold="True" Font-Size="12"></asp:LinkButton>
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
    
    <asp:ObjectDataSource ID="DsAlbuns" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="SelecionaAlbumDs" 
        TypeName="Rwd.BLL.BusinessLogic">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="alb_cod" Type="Int32" />
            <asp:Parameter DefaultValue="%" Name="alb_nome" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="DsFotos" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="SelecionaFotoAlbumDs" TypeName="Rwd.BLL.BusinessLogic">
            <SelectParameters>
            <asp:Parameter Name="fot_cod" Type="Int32" />
                <asp:ControlParameter ControlID="DataList1" DefaultValue="alb_cod" Name="alb_cod" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter Name="fot_legenda" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

