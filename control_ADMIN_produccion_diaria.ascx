<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_produccion_diaria.ascx.cs" Inherits="control_ADMIN_produccion_diaria" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style type="text/css">
    .style3
    {
        height: 23px;
    }
</style>
<table>
    <tr valign="top">
        <td>
            <asp:Label ID="Label2" runat="server"></asp:Label>

        </td>
        <td>
                                &nbsp;</td>
    </tr>
    <tr valign="top">
        <td>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CaptionAlign="Top" 
                ForeColor="Black" DataKeyNames="id_registro" 
                onrowdeleting="GridView1_RowDeleting" AllowPaging="True" 
                onpageindexchanging="GridView1_PageIndexChanging" PageSize="20">
    <AlternatingRowStyle BackColor="#BCB934" />
    <Columns>
        <asp:CommandField DeleteText="Del" ShowDeleteButton="True" />
        <asp:BoundField DataField="id_registro" HeaderText="ID" />
        <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" 
            HeaderText="Fecha" HtmlEncode="False" />
        <asp:BoundField DataField="vitola" HeaderText="Vitola" />
        <asp:BoundField DataField="capa" HeaderText="Capa" />
        <asp:BoundField DataField="liga" HeaderText="Liga" />
        <asp:BoundField DataField="operario" HeaderText="Operario" />
        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
    </Columns>
    <HeaderStyle BackColor="Olive" ForeColor="White" />
</asp:GridView>

        </td>
        <td>
                                <table border="0">
                                    <tr bgcolor="Olive" style="color: #FFFFFF">
                                        <td >
                                            <strong>Agregar</strong></td>
                                        <td >
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" >
                                            Vitola</td>
                                        <td align="left" style="color: #FFFFFF" >
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton1_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Capa</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton2_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Liga</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton3_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Operario</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList4" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton4" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton4_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Cantidad</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:TextBox ID="TextBox2" runat="server" Width="68px" 
                                                ValidationGroup="prod_diaria"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="TextBox2" Display="Dynamic" 
                                                ErrorMessage="*" SetFocusOnError="True" ForeColor="Red" 
                                                ValidationGroup="prod_diaria"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                ControlToValidate="TextBox2" Display="Dynamic" 
                                                ErrorMessage="Solo numeros enteros" ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                                ValidationGroup="prod_diaria"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Fecha</td>
                                       
                                        <td align="left">
                                            
                                            <asp:Image ID="Imagebtn" runat="server" ImageUrl="~/img/calendar.png" />
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            Format="MM/dd/yyyy" PopupButtonID="Imagebtn" PopupPosition="BottomRight" 
                                            TargetControlID="TextBox4" TodaysDateFormat="MMMM, d yyyy" />

                                          

                                            <br />
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            Precio Unitario</td>
                                       
                                        <td align="left">
                                            <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Width="62px" 
                                                ValidationGroup="prod_diaria" TextMode="SingleLine"></asp:TextBox>
                                            
                                            <asp:LinkButton ID="LinkButton2" runat="server" Enabled="False" 
                                                onclick="LinkButton2_Click" ValidationGroup="prod_diaria">+</asp:LinkButton>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                ControlToValidate="TextBox3" Display="Dynamic" 
                                                ErrorMessage="Sin Precio Unitario" ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="0" SetFocusOnError="True" Type="Currency" 
                                                ValidationGroup="prod_diaria"></asp:RangeValidator>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                ToolTip="Clic para agregar una nueva vitola" ValidationGroup="prod_diaria">Agregar</asp:LinkButton>
                                        </td>
                                       
                                        <td align="left">
                                            &nbsp;</td>
                                       
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="style3">
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
    </tr>
    <tr valign="top">
        <td>
            </td>
        <td>
                                &nbsp;</td>
    </tr>
</table>


