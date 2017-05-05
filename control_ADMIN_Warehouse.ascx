<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_Warehouse.ascx.cs" Inherits="control_ADMIN_Warehouse" %>


<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>


<table>
    <tr>
        <td bgcolor="Olive" style="color: #FFFFFF">
            <strong>WAREHOUSE</strong></td>
        <td bgcolor="Olive" style="color: #FFFFFF">
            <strong>Gestion</strong></td>
    </tr>
    <tr>
        <td valign="top">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id_gestion" onrowdeleting="GridView1_RowDeleting">
            <HeaderStyle BackColor="Olive" ForeColor="White" />
            <AlternatingRowStyle BackColor="#BCB934" />
                <Columns>
                    <asp:CommandField DeleteText="-&gt;" ShowDeleteButton="True" >
                    <ControlStyle Font-Bold="False" />
                    </asp:CommandField>
                    <asp:BoundField DataField="id_gestion" HeaderText="Id" />
                    <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                    <asp:BoundField DataField="capa" HeaderText="Capa" />
                    <asp:BoundField DataField="Liga" HeaderText="Liga" />
                    <asp:BoundField DataField="cantidad" HeaderText="Existente" />
                    <asp:BoundField DataField="fechaR" HeaderText="Fecha" />
                </Columns>
                <SelectedRowStyle Font-Bold="True" Font-Size="X-Large" />
            </asp:GridView>
        </td>
        <td valign="top">
            <table>
                <tr>
                    <td>
                        D<span class="gt-card-ttl-txt" style="direction: ltr;">ispatch</span></td>
                    <td>
                        <table border="1">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Enabled="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Enabled="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Enabled="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Cantidad</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="51px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox1" Display="Dynamic" 
                            ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                            ValidationGroup="fecha">*</asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="RangeValidator" 
                            MaximumValue="1000000" MinimumValue="1" Type="Integer" ValidationGroup="fecha">solo numeros enteros</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        To</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" width="59px">
                            <asp:ListItem>Miami</asp:ListItem>
                            <asp:ListItem>Jamaica</asp:ListItem>
                            <asp:ListItem Value="Defecto">Defecto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Fecha</td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server" 
                            onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
                        <asp:TextBox ID="TextBox2" runat="server" BackColor="#FFCC66" 
                            BorderStyle="None" Enabled="False" Font-Names="#FFCC66" ValidationGroup="fecha" 
                            Width="86px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox2" Display="Dynamic" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="fecha">Campo fecha no elejido</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                            Text="Transferir&gt;&gt;&gt;" style="height: 26px" 
                            ValidationGroup="fecha" />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2">
                        <table class="style1">
                            <tr>
                                <td>
                                    Historico-Transferencias</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="id_transferencia" HeaderText="Id" />
                                            <asp:BoundField DataField="info" HeaderText="Info" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top">
            &nbsp;</td>
        <td valign="top">
            &nbsp;</td>
    </tr>
    </table>

