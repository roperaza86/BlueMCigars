<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_Nomencladores.ascx.cs" Inherits="control_ADMIN_Nomencladores" %>


<table>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td>
                        Ir a</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="Elija una opcion">Elija una opción</asp:ListItem>
                            <asp:ListItem>Vitola</asp:ListItem>
                            <asp:ListItem>Capa</asp:ListItem>
                            <asp:ListItem>Liga</asp:ListItem>
                            <asp:ListItem>Operario</asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    AllowPaging="True" BorderStyle="Inset" 
                                    onpageindexchanging="GridView1_PageIndexChanging" 
                                    onrowdeleting="GridView1_RowDeleting">
                                    <AlternatingRowStyle BackColor="#FFFF99" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="id_vitola" HeaderText="Id" />
                                        <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                    </Columns>
                                    <HeaderStyle BackColor="Olive" ForeColor="White" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <SelectedRowStyle BackColor="Black" />
                                </asp:GridView>
                            </td>
                            <td valign="top">
                                <table border="0">
                                    <tr bgcolor="Olive" style="color: #FFFFFF">
                                        <td >
                                            <strong>Agregar</strong></td>
                                        <td >
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Vitola</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="vitola"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="*" 
                                                Font-Bold="True" ForeColor="Red" SetFocusOnError="True" 
                                                ValidationGroup="vitola"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                       
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Habano" />
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                ToolTip="Clic para agregar una nueva vitola" ValidationGroup="vitola">Agregar</asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                    AllowPaging="True" BorderStyle="Inset" 
                                        onpageindexchanging="GridView2_PageIndexChanging" 
                                        onrowdeleting="GridView2_RowDeleting">
                                    <AlternatingRowStyle BackColor="#FFFF99" />
                                   
                                    
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="id_capa" HeaderText="Id" />
                                            <asp:BoundField DataField="capa" HeaderText="Capa" />
                                        </Columns>
                                         <HeaderStyle BackColor="Olive" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                                <td valign="top">
                                    <table border="0">
                                        <tr bgcolor="Olive" style="color: #FFFFFF">
                                            <td>
                                                <strong>Agregar</strong></td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Capa</td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="capa"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*" 
                                                    Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ValidationGroup="capa"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="left">
                                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Habano" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
                                                    ToolTip="Clic para agregar una nueva capa" ValidationGroup="capa">Agregar</asp:LinkButton>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
                                    AllowPaging="True" BorderStyle="Inset" 
                                        onpageindexchanging="GridView3_PageIndexChanging" 
                                        onrowdeleting="GridView3_RowDeleting">
                                    <AlternatingRowStyle BackColor="#FFFF99" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="id_liga" HeaderText="Id" />
                                            <asp:BoundField DataField="liga" HeaderText="Liga" />
                                        </Columns>
                                        <HeaderStyle BackColor="Olive" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                                <td valign="top">
                                    <table border="0">
                                        <tr bgcolor="Olive" style="color: #FFFFFF">
                                            <td>
                                                <strong>Agregar</strong></td>
                                            <td >
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Liga</td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="capa"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*" 
                                                    Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ValidationGroup="capa"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="left">
                                                <asp:CheckBox ID="CheckBox3" runat="server" Text="Habano" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
                                                    ToolTip="Clic para agregar una nueva liga" ValidationGroup="capa">Agregar</asp:LinkButton>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                     <asp:View ID="View4" runat="server">
                         <table>
                             <tr>
                                 <td valign="top">
                                     <asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                                         AutoGenerateColumns="False" BorderStyle="Inset" 
                                         onpageindexchanging="GridView4_PageIndexChanging">
                                         <AlternatingRowStyle BackColor="#FFFF99" />
                                         <Columns>
                                             <asp:BoundField DataField="id_operario" HeaderText="Id" />
                                             <asp:BoundField DataField="operario" HeaderText="Operario" />
                                         </Columns>
                                         <HeaderStyle BackColor="Olive" ForeColor="White" />
                                     </asp:GridView>
                                 </td>
                                 <td valign="top">
                                     <table border="0">
                                         <tr bgcolor="Olive" style="color: #FFFFFF">
                                             <td>
                                                 <strong>Agregar</strong></td>
                                             <td>
                                                 &nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td>
                                                 Operario</td>
                                             <td align="left">
                                                 <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="operario"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                     ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="*" 
                                                     Font-Bold="True" ForeColor="Red" SetFocusOnError="True" 
                                                     ValidationGroup="operario"></asp:RequiredFieldValidator>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>
                                                 <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" 
                                                     ToolTip="Clic para agregar una nueva liga" ValidationGroup="operario">Agregar</asp:LinkButton>
                                             </td>
                                             <td align="left">
                                                 &nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td colspan="2">
                                                 <asp:Label ID="Label4" runat="server"></asp:Label>
                                             </td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                         </table>
                    </asp:View>
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:GridView ID="GridView6" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" BorderStyle="Inset" 
                                    onpageindexchanging="GridView4_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="#FFFF99" />
                                    <Columns>
                                        <asp:BoundField DataField="id_client" HeaderText="Id" />
                                        <asp:BoundField DataField="client" HeaderText="Client" />
                                    </Columns>
                                    <HeaderStyle BackColor="Olive" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td valign="top">
                                <table border="0">
                                    <tr bgcolor="Olive" style="color: #FFFFFF">
                                        <td>
                                            <strong>Agregar</strong></td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Client</td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBox5" runat="server" ValidationGroup="client"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="*" 
                                                Font-Bold="True" ForeColor="Red" SetFocusOnError="True" 
                                                ValidationGroup="client"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click" 
                                                ToolTip="Clic para agregar una nueva liga" ValidationGroup="operario">Agregar</asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label5" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </td>
        
    </tr>
</table>

