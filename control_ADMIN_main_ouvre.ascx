<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_main_ouvre.ascx.cs" Inherits="control_ADMIN_main_ouvre" %>
  <%-- <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
   <table>
            <tr bgcolor="Olive" style="color: #FFFFFF">
                <td align="center" style="font-weight: 700">
                    RESUMEN</td>
                <td colspan="2" bgcolor="Olive" style="color: #FFFFFF" align="center">
                    <strong>PERIODO A CONTAR</strong></td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <HeaderStyle BackColor="Olive" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#BCB934" />
                        <Columns>
                            <asp:BoundField DataField="Operario" HeaderText="Operario" />
                            <asp:BoundField DataField="pago" HeaderText="Pago" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </td>
                <td>
                    <asp:Calendar ID="Calendar2" runat="server" 
                        onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
        </table>
<p>
    </p>
<%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="756px">
</rsweb:ReportViewer>--%>



