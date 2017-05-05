<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_security.ascx.cs" Inherits="control_security" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<table class="style1">
    <tr>
        <td bgcolor="Olive" style="color: #FFFFFF">
            <strong>TRACES</strong></td>
    </tr>
    <tr>
        <td>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
                onpageindexchanging="GridView1_PageIndexChanging">
<HeaderStyle BackColor="Olive" ForeColor="White" />
<AlternatingRowStyle BackColor="#BCB934" />
    <Columns>
        <asp:BoundField DataField="login" HeaderText="Login" />
        <asp:BoundField DataField="fecha" HeaderText="Fecha" 
            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
        <asp:BoundField DataField="Hora" HeaderText="Hora" />
        <asp:BoundField DataField="evento" HeaderText="Descripción" />
        <asp:BoundField DataField="vitola" HeaderText="Vitola" />
        <asp:BoundField DataField="capa" HeaderText="Capa" />
        <asp:BoundField DataField="liga" HeaderText="Liga" />
        <asp:BoundField DataField="wh" HeaderText="WH" />
        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="costo" HeaderText="Costo" />
    </Columns>
</asp:GridView>

        </td>
    </tr>
</table>


