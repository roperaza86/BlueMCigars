<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_Bitacora.ascx.cs" Inherits="control_ADMIN_Bitacora" %>

<table>
    <tr>
        <td bgcolor="Olive" style="color: #FFFFFF">
            <strong>BITACORA</strong></td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
                    </td>
                    <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
                    </td>
                    <td>
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">OK</asp:LinkButton>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>

        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <HeaderStyle BackColor="Olive" ForeColor="White" />
<AlternatingRowStyle BackColor="#BCB934" />
                <Columns>
                    <asp:BoundField DataField="login" HeaderText="Login" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha"  DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False"/>
                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                    <asp:BoundField DataField="evento" HeaderText="Evento" />
                    <asp:BoundField DataField="wh" HeaderText="WH" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="costo" HeaderText="Costo" />
                </Columns>
            </asp:GridView>

        </td>
    </tr>
</table>




