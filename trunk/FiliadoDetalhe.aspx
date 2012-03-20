<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FiliadoDetalhe.aspx.cs" Inherits="FiliadoDetalhe" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:FormView ID="FormView1" runat="server" DataSourceID="DsDetalhe">
         <ItemTemplate>
         <ul>
            <table cellpadding="0" cellspacing="0" class="style1" width="900">
            <tr>
                <td colspan="2"><h3>Sobre: <%# Eval("fil_nome")%></h3></td>
            </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <li><strong><i>Informação Institucional (<%# Eval("fil_tipo")%>)</i></strong></li>
                    </td>
                    <td style="color: #516C00; font-weight: bold">Logomarca da Instituição:</td>
                </tr>
            <tr>
                <td valign="top">
                <li>Nome da instituição: <strong style="color: #516C00"><%# Eval("fil_nome")%></strong></li>
                <li>Representante legal: <strong style="color: #516C00"><%# Eval("fil_responsavel")%></strong></li>
                <li>Endereço: <strong style="color: #516C00"><%# Eval("fil_endereco")%></strong></li>
                <li>CEP: <strong style="color: #516C00"><%# Eval("mun_cep")%></strong></li>
                <li>Telefone: <strong style="color: #516C00"><%# Eval("fil_telefone")%></strong></li>
                <li>E-mail: <strong style="color: #516C00"><%# Eval("fil_email")%></strong></li>
                <li>Website: <strong><a href='http://<%# Eval("fil_site")%>' target="_blank"><%# Eval("fil_site")%></a></strong></li>
                </td>
                <td><img alt='<%# Eval("fil_nome") %>' border="0" src='../HandlerImgs.ashx?imgfil=<%# Eval("fil_cod") %>'></img></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                <tr>
                    <td><li><strong><i>Informação Municipal</i></strong></li></td>
                    <td style="color: #516C00; font-weight: bold">Logomarca do Município:</td>
                </tr>
                <tr>
                    <td valign="top">
                        <li>Gestor: <strong style="color: #516C00"><%# Eval("mun_gestor")%></strong></li>
                        <li>Cidade: <strong style="color: #516C00"><%# Eval("mun_nome")%></strong></li>
                        <li>Estado: <strong style="color: #516C00"><%# Eval("mun_estado")%></strong></li>
                        <li>Website oficial: <strong><a href='http://<%# Eval("mun_site")%>' target="_blank"><%# Eval("mun_site")%></a></strong></li>
                    </td>
                    <td><img alt='<%# Eval("mun_nome") %>' border="0" src='../HandlerImgs.ashx?imgmun=<%# Eval("mun_cod") %>'></img></td>
                </tr>
            <tr>
                <td colspan="2" valign="top">
                <li>Localização geográfica: </li>
                <li><%# Eval("mun_mapa")%></li>
                </td>
            </tr>
           </table>  
         </ul>
         </ItemTemplate>
     </asp:FormView>
     <p><a href="Default.aspx">Visualizar pelo mapa</a> | <a href="Filiados.aspx">Visualizar todos</a></p>
    <asp:ObjectDataSource ID="DsDetalhe" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelecionaFiliadosMunicipiosDs" TypeName="Rwd.BLL.BusinessLogic">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="fil_cod" QueryStringField="f" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="mun_nome" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

