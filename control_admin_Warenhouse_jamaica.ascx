<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_admin_Warenhouse_jamaica.ascx.cs" Inherits="control_admin_Warenhouse_jamaica" %>

<style type="text/css">
    
   
</style>

<asp:MultiView ID="MultiView2" runat="server" 
    ActiveViewIndex="1">
    <asp:View ID="View3" runat="server">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/constr.jpg" />
    </asp:View>
    <asp:View ID="View4" runat="server">
<table>
    <tr>
        <td bgcolor="Olive" style="color: #FFFFFF">
            <strong>WAREHOUSE-Jamaica</strong></td>
        <td bgcolor="Olive" style="color: #FFFFFF">
            <strong>Sales Management</strong></td>
        
    </tr>
    <tr>
        <td valign="top">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id_gestion_jamaica" onrowdeleting="GridView1_RowDeleting" 
                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                PageSize="100" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                style="font-size: large">
            <HeaderStyle BackColor="Olive" ForeColor="White" />
            <AlternatingRowStyle BackColor="#BCB934" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField DeleteText="(X)" ShowDeleteButton="True" ButtonType="Button" >
                    <ControlStyle Font-Bold="False" BackColor="#FF3300" />
                    </asp:CommandField>
                    <asp:BoundField DataField="id_gestion_jamaica" HeaderText="Id" />
                    <asp:BoundField DataField="vitola" HeaderText="Size" />
                    <asp:BoundField DataField="capa" HeaderText="Wrapper" />
                    <asp:BoundField DataField="Liga" HeaderText="Blend" />
                    <asp:BoundField DataField="cantidad" HeaderText="Existing" />
                </Columns>
                <SelectedRowStyle Font-Bold="True" Font-Size="Large" />
            </asp:GridView>
        </td>
        <td valign="top">
                                <table border="0">
                                    <tr bgcolor="Olive" style="color: #FFFFFF">
                                        <td colspan="2" >
                                            <strong>Add</strong></td>
                                        <td >
                                            <strong>Invoices</strong></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" class="style9">
                                            Date</td>
                                        <td align="left" style="color: #FFFFFF">
                                            &nbsp;</td>
                                        <td align="left"  rowspan="7">
            <table>
                <tr>
                    <td >
                        D<span>ispatch</span></td>
                    <td >
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
                    <td valign="top"  >
                        Cantidad</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="51px" 
                            ValidationGroup="invoices"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                ControlToValidate="TextBox1" Display="Dynamic" 
                                                ErrorMessage="Only numbers" 
                            ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                                ValidationGroup="invoices"></asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator" 
                            ForeColor="Red" SetFocusOnError="True" ValidationGroup="invoices">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top"  >
                        INVOICE</td>
                    <td>
                        <asp:Calendar ID="Calendar3" runat="server" Height="95px" Width="16px">
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td valign="top"  >
                        Fee</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Width="62px" 
                            ValidationGroup="invoices"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="RequiredFieldValidator" 
                            ValidationGroup="invoices" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                                ControlToValidate="TextBox4" Display="Dynamic" 
                                                ErrorMessage="Only numbers" ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="1" SetFocusOnError="True" Type="Double" 
                                                ValidationGroup="invoices"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top"  >
                        Payment</td>
                    <td>
                        <asp:DropDownList ID="DropDownList6" runat="server" 
                           >
                            <asp:ListItem Value="Paid">Paid</asp:ListItem>
                            <asp:ListItem Value="No Paid">No Paid</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top"  >
                        Client</td>
                    <td>
                        <asp:DropDownList ID="DropDownList8" runat="server">
                        </asp:DropDownList>
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                            ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton4_Click" Width="25px" />
                    </td>
                </tr>
                <tr>
                    <td valign="top"  >
                        Salesman</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" ValidationGroup="invoices"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TextBox6" Display="Dynamic" 
                            ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                            ValidationGroup="invoices" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top"  align="center">
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                            Text="OK" Enabled="False" ValidationGroup="invoices" 
                            style="text-align: center" />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" class="style9">
                                            Size</td>
                                        <td align="left"  style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList5" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton1_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style9">
                                            Wrapper</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton2_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style9">
                                            Blend</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton3_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style9">
                                            Quantity</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:TextBox ID="TextBox2" runat="server" Width="68px" 
                                                ValidationGroup="prod_diaria"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="TextBox2" Display="Dynamic" 
                                                ErrorMessage="*" SetFocusOnError="True" ForeColor="Red" 
                                                ValidationGroup="prod_diaria"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                ControlToValidate="TextBox2" Display="Dynamic" 
                                                ErrorMessage="Only numbers" ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                                ValidationGroup="prod_diaria"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9">
                                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                ToolTip="Clic para agregar un nuevo producto" 
                                                ValidationGroup="prod_diaria">Add</asp:LinkButton>
                                        </td>
                                       
                                        <td align="left">
                                            &nbsp;</td>
                                       
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="style3">
                                            <asp:Label ID="Label5" runat="server" Visible="False">5</asp:Label>
                                            <asp:Label ID="Label6" runat="server" Visible="False">6</asp:Label>
                                            <asp:Label ID="Label7" runat="server" Visible="False">7</asp:Label>
                                            <asp:Label ID="Label8" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td >
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" Width="311px" 
                                                Font-Bold="True" ForeColor="#333300" RepeatDirection="Horizontal" 
                                                TextAlign="Left">
                                    <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                    <asp:ListItem Value="NoPaid">No Paid</asp:ListItem>
                                    <asp:ListItem>Date &amp; Client</asp:ListItem>
                                    <asp:ListItem>All</asp:ListItem>
                                </asp:RadioButtonList>

                                        
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" BackColor="#009933" BorderStyle="Outset" 
                                                            Font-Bold="True" Font-Size="Large" ForeColor="#FFFFCC" Text="Paid" 
                                                            ToolTip="Paid"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" BackColor="#FF3300" BorderStyle="Inset" 
                                                            Font-Bold="True" Font-Size="Large" ForeColor="#FFFFCC" Text="No Paid" 
                                                            ToolTip="No paid"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" BackColor="#9900CC" BorderStyle="None" 
                                                            Font-Bold="True" Font-Size="Large" ForeColor="#FFFFCC" Text="All" ToolTip="All"></asp:Label>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="2">
                                            <asp:MultiView ID="MultiView3" runat="server">
                                                <asp:View ID="View5" runat="server">
                                                    <table class="style8">
                                                        <tr valign="top">
                                                            <td colspan="2">
                                                                <hr style="background-color: #FF3300; color: #FF0000" size="5" />
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td>
                                                                <asp:Calendar ID="Calendar2" runat="server" Height="16px" Width="16px" 
                                                                    onselectionchanged="Calendar2_SelectionChanged">
                                                                </asp:Calendar>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" 
                                                                    onselectedindexchanged="DropDownList7_SelectedIndexChanged1">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                </asp:View>
                                            </asp:MultiView>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="2">                             
                                           
                                               <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                                Text="change state" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                    
                                <br />
                                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View1" runat="server">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            onselectedindexchanged="GridView2_SelectedIndexChanged" 
                                            style="margin-bottom: 9px">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vitola" HeaderText="Size" />
                                                <asp:BoundField DataField="capa" HeaderText="Wrapper" />
                                                <asp:BoundField DataField="liga" HeaderText="Blend" />
                                                <asp:BoundField DataField="cantidad" HeaderText="Existing" />
                                                <asp:TemplateField HeaderText="Invoice">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("invoice") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" 
                                                            Text='<%# Bind("invoice", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                                  HeaderText="Date" HtmlEncode="False" />
                                                <asp:BoundField DataField="login" HeaderText="Login" />
                                                <asp:BoundField DataField="importe" HeaderText="Imports" />
                                                <asp:BoundField DataField="estado" HeaderText="Estado" />
                                                <asp:BoundField DataField="client" HeaderText="Client" />
                                                <asp:BoundField DataField="vendedor" HeaderText="Sales man" />
                                                <asp:BoundField DataField="date_paid" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="Payment date"  HtmlEncode="False"  />
                                                <asp:BoundField DataField="parcial" HeaderText="Partial" />
                                                <asp:TemplateField HeaderText="id">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table>
                                            <tr>
                                                <td bgcolor="#BCB934" class="style6" colspan="2">
                                                    <strong>Change of&nbsp; state</strong></td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#BCB934" class="style7">
                                                    Id</td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#BCB934" class="style7">
                                                    Invoice
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#BCB934" class="style7">
                                                    Parciel</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#BCB934" class="style7">
                                                    Fecha Pago</td>
                                                <td>
                                                    <asp:Calendar ID="Calendar1" runat="server" Height="16px" Width="66px">
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="Button2" runat="server" Text="Ok" onclick="Button2_Click" />
                                                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Cancel" />
                                                </td>
                                                
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>
                                    
        </td>
    </tr>
    <tr>
        <td valign="top">
            &nbsp;</td>
        <td valign="top">
                                &nbsp;</td>
    </tr>
</table>
    </asp:View>
</asp:MultiView>
