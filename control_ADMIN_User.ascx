<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_User.ascx.cs" Inherits="control_ADMIN_User" %>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <table>
            <tr bgcolor="Olive" style="color: #FFFFFF">
                <td >
                    <strong>Users</strong>
                </td>
                <td>
                  <strong>New User</strong></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        onrowdeleting="GridView1_RowDeleting">
                        <HeaderStyle BackColor="Olive" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#BCB934" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                            <asp:BoundField DataField="id_user" HeaderText="No." />
                            <asp:BoundField DataField="login" HeaderText="Login" />
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td valign="top">
                    <table class="style1">
                        <tr>
                            <td>
                                Login</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="newu"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Login Obligatorio" 
                                    ValidationGroup="newu">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Pass</td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
                                    ValidationGroup="newu"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="TextBox2" Display="Dynamic" 
                                    ErrorMessage="Password Obligatorio" ValidationGroup="newu">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Re-Pass</td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" 
                                    ValidationGroup="newu"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="TextBox2" ControlToValidate="TextBox3" Display="Dynamic" 
                                    ErrorMessage="*" ValidationGroup="newu"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tipo</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>user_miami</asp:ListItem>
                                    <asp:ListItem>user_jamaica</asp:ListItem>
                                    <asp:ListItem>user</asp:ListItem>
                                    <asp:ListItem>admin</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                    ValidationGroup="newu">Add</asp:LinkButton>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ValidationGroup="newu" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
    </asp:View>
</asp:MultiView>


