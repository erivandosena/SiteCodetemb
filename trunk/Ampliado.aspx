<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ampliado.aspx.cs" Inherits="Ampliado" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <p align="center"><input onclick="history.go(-1)" type="button" value="Voltar" /></p>
       <p align="center">
       <img border="0" src="HandlerImgs.ashx?Img=<%= Request.QueryString["i"] %>&Tamanho=A"></a>
       </p>
       <p align="center"><input onclick="history.go(-1)" type="button" value="Voltar" /></p>
</asp:Content>

