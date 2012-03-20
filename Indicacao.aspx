<%@ Page Language="C#" MasterPageFile="~/MasterPagePaginas.master" AutoEventWireup="true" CodeFile="Indicacao.aspx.cs" Inherits="Indicacao" Title="Untitled Page" %>

<%@ Register src="WUC_Links.ascx" tagname="WUC_Links" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="noticia-1" class="post">
     <p>
    <asp:Label ID="Lbl_Titulo" runat="server" Font-Bold="True" Font-Names="Georgia, Times New Roman, Arial, Times, serif" 
            Font-Size="14pt"></asp:Label>
    </p>
    <p>
			<asp:Label ID="Lbl_Resumo" runat="server" ForeColor="#333333" 
                Font-Italic="False"></asp:Label>
                        </p>
     <p>
       <strong> Envio de indicação da publicação</strong></p>
                        Seu nome:
                        <p>
              <ASP:TextBox id="TxtBoxNome" runat="server" width="300px"></ASP:TextBox></p>
                        Seu e-mail:
                        <p>
              <ASP:TextBox id="TxtBoxEmail" runat="server" width="300px"></ASP:TextBox></p>
                        E-mail do(a) Amigo(a):
                        <p>
              <ASP:TextBox id="TxtBoxEmailDest" runat="server" width="300px"></ASP:TextBox></p>
                        Mensagem (Opcional):
                        <p>
              <asp:TextBox ID="TextBoxMenOpc" runat="server" height="100px" textmode="MultiLine" width="400px"></asp:TextBox>
                        </p>
                        <p>
              <asp:Label ID="LblMsg" runat="server" Font-Names="Trebuchet MS" Font-Size="10pt"></asp:Label>
              </p>
                      <p>
                        <asp:Button ID="Button2" runat="server" Text="Voltar" 
                            OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
                            UseSubmitBehavior="False" CausesValidation="False" onclick="Button2_Click" />
                          &nbsp;&nbsp;
		    
		  <asp:Button ID="Button1" runat="server" Text="Enviar" 
                    OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
                    UseSubmitBehavior="False" onclick="Button1_Click"/>


              </p>
    
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <uc1:WUC_Links ID="WUC_Links1" runat="server" />
</asp:Content>

