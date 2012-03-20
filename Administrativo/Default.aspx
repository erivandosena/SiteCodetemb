<%@ Page Language="C#" MasterPageFile="~/Administrativo/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrativo_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="home_geral">
        <div id="home_esquerdo">
        <div id="home_1">
        Bem-vindo(a)!
        <asp:LoginName ID="LoginName1" runat="server" Font-Bold="True" /><br />
        &nbsp;
        <p>Hoje é <%= DateTime.Now.ToLongDateString() %></p>Você está na Área Administrativa do Site:&nbsp;
        <b><%= HttpContext.Current.Request.Url.Authority %></b>
        </div>
        <div id="divisor_horizontal"><br /><hr /></div>
            <div>
                <div id="outros_menus">
                    <p>
                        <b><a href="http://www.workspace.com.br/codetemb/" target="_blank">Alterar 
                Senha de E-mail</a></b> <a href="http://webmail.codetemb.com.br" title="Webmail - Login" style="text-decoration: none"; target="_blank">( Acesso <strong>WebMail</strong> )</a> 
                        <br /><font color="#999999">Alteração da senha da conta de e-mail.</font></p>
                    <p><strong>Estatísticas/Relatórios de acesso</strong><br />Você poderá acessar as estatísticas e relatórios de visitação do seu website utilizando as informações abaixo:
                        Enereço: <a href="http://stats.porta80.com.br" target="_blank">http://stats.porta80.com.br</a><br />
                        Site ID: 21318<br />
                        Usuário: codetemb<br />
                        Senha: 33471498
                    </p>
                </div>
            </div>
       </div>
  </div>     

</asp:Content>

