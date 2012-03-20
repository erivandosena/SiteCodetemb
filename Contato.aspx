<%@ Page Language="C#" MasterPageFile="~/MasterPagePaginas.master" AutoEventWireup="true" CodeFile="Contato.aspx.cs" Inherits="Contato" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong>Nosso endereço:</strong>
           <p>
           <asp:Label ID="LblEndereco" runat="server" ForeColor="#485B15"></asp:Label> 
           <br />
               CEP: <asp:Label ID="LblCep" runat="server" ForeColor="#485B15"></asp:Label>
               &nbsp;&nbsp;Cidade: 
           <asp:Label ID="LblCidade" runat="server" ForeColor="#485B15"></asp:Label>
               &nbsp;&nbsp;Estado: 
           <asp:Label ID="LblEstado" runat="server" ForeColor="#485B15"></asp:Label>
           </p>
       <strong>Telefone(s):</strong>
       <p>Telefone: 
       <asp:Label ID="LblTel1" runat="server" ForeColor="#485B15"></asp:Label>
           &nbsp;&nbsp;Celular/Fax: 
           <asp:Label ID="LblTel2" runat="server" ForeColor="#485B15"></asp:Label>
       </p>
       <strong>E-mail e Comunicação instantânea:</strong>
       <p>E-mail: 
       <asp:Label ID="LblMail1" runat="server" ForeColor="#485B15"></asp:Label>
       <br />
           MSN: 
           <asp:Label ID="LblMail2" runat="server" ForeColor="#485B15"></asp:Label>
       <br />
           Skype: 
           <asp:Label ID="LblSkype" runat="server" ForeColor="#485B15"></asp:Label>
       </p>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
       
       <p><strong>FORMULÁRIO DE CONTATO:</strong></p>
                   Nome:
       <p>
           <asp:TextBox ID="TextBoxNome" runat="server" Width="250px"></asp:TextBox>
           </p>
                   E-mail:
       <p>
           <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
           </p>
                   Telefone: (opcional)
       <p>
           <asp:TextBox ID="TextBoxTelefone" runat="server"></asp:TextBox>
           </p>
                   Assunto:
       <p>
           <asp:DropDownList ID="DropDownListAss" runat="server">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem>Elogio</asp:ListItem>
               <asp:ListItem>Reclamação</asp:ListItem>
               <asp:ListItem>Sugestão</asp:ListItem>
               <asp:ListItem>Assunto não especificado</asp:ListItem>
           </asp:DropDownList>
           </p>
                   Mensagem:
       <p>
           <asp:TextBox ID="TextBoxMens" runat="server" Height="100px" 
               TextMode="MultiLine" Width="319px"></asp:TextBox>
           </p>
      <asp:Button ID="Button1" runat="server" Text="Enviar" 
                       OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
                       UseSubmitBehavior="False" onclick="Button1_Click"/> 
       <p><asp:Label ID="LblMsg" runat="server"></asp:Label></p>  
          
               </ContentTemplate>
           </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <strong>Mapa de localização:</strong>
           <p>
           <asp:Label ID="LblMapa" runat="server"></asp:Label> 
</asp:Content>

