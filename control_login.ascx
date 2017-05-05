<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_login.ascx.cs" Inherits="login" %>

 

 

 

<table>
    <tr>
        <td align="right">
            Usuario</td>
        <td >
            <asp:TextBox ID="txt_nombre" runat="server" TabIndex="1"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nombre requerido" ControlToValidate="txt_nombre" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td align="right">
            Contrase�a</td>
        <td style="width: 100px">
            <asp:TextBox ID="txt_pass" runat="server" TabIndex="2" TextMode="Password"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Contrase�a requerida" ControlToValidate="txt_pass" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td valign="top" align="right">
            <asp:Button ID="Button1" runat="server" Text="Acceder>>" BorderStyle="Double" TabIndex="3" ToolTip="Acceder" OnClick="Button1_Click"  ClientIDMode="Static" /></td>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="ActiveCaption" HeaderText="Errores en la autenticaci�n:" ShowMessageBox="True" ToolTip="Lista de campos vacios" />
        </td>
        <td>
          </td>
    </tr>
</table>
            <asp:Label ID="label_info" runat="server"></asp:Label>
<p>
    &nbsp;</p>

