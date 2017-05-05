<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_Admin_Pass.ascx.cs" Inherits="control_Admin_Pass" %>
<style type="text/css">
    .style2
    {
        height: 23px;
    }
    .style3
    {
        text-align: right;
    }
    .style4
    {
        height: 23px;
        text-align: right;
    }
    .style5
    {
        text-align: left;
    }
</style>

<table>
    <tr bgcolor="Olive" style="color: #FFFFFF">
        <td colspan="2" >
            <strong>Cambio/Change Password</strong></td>
    </tr>
    <tr>
        <td class="style3">
            Pass
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" 
                ValidationGroup="pass"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="pass requerido" ControlToValidate="TextBox1" 
                ValidationGroup="pass"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style3">
            New Pas</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
                ValidationGroup="pass"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="new pass requerido" ControlToValidate="TextBox2" 
                ValidationGroup="pass"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td >
            Re-Type(new pas)</td>
        <td >
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" 
                ValidationGroup="pass"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ErrorMessage="error de coincidencias" ControlToCompare="TextBox2" 
                ControlToValidate="TextBox3" ValidationGroup="pass"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style3" valign="top">
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                ValidationGroup="pass">OK</asp:LinkButton>
        </td>
        <td valign="top">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ValidationGroup="pass" />
        </td>
    </tr>
    <tr>
        <td colspan="2" valign="top">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
</table>

