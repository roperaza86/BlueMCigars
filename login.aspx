<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Title="Credenciales de acceso" %>

<%@ Register Src="control_login.ascx" TagName="control_login" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:control_login ID="Control_login1" runat="server" />
</asp:Content>

