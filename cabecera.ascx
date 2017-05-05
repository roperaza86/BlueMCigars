<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cabecera.ascx.cs" Inherits="cabecera" %>
<table 2" border="0" width="100%">

    <tr>
        <td>            
            <hr size="4" style="background-color: #808000"/>            
        </td>
    </tr>

    <tr>
        <td style="text-align: center">
           
                <table style="font-size: 24pt; width: 100%">
                    <tr>
                        <td align="left" rowspan="2" valign="top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/logo_bmc1-250x141.png" 
                                Width="100px" />
                        </td>
                        <td align="left" valign="top">
                            <span style="color: #800000">
                             Sistema Análisis de Datos<span 
                                style="color: #800000; font-size: large; font-weight: 700;"><br />
                            BLUE MOUNTAIN CIGARS</span></span></td>
                        <td align="left" valign="top">
                            <table>
                                <tr valign="top">
                                    <td valign="top">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/img/3-400x600.jpg" 
                                            Width="50px" />
                                    </td>
                                    <td valign="top">
                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/img/añejo.png" Width="50px" />
                                    </td>
                                    <td>
                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/img/bmc_hometitle.png" 
                                            Width="50px" />
                                    </td>
                                    <td>
                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/img/salomon-doble-capa.png" 
                                            Width="50px" />
                                    </td>
                                    <td>
                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/img/anejo.png" Width="50px" />
                                    </td>
                                    <td>
                            <a href="https://www.facebook.com/bluemountaincigars/" target=_blank>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/img/facebook.png" 
                                Width="40px" />
                            </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   
                </table>
               </td>
        </tr>
        <tr>
            <td style="text-align: center">
            <hr size="10" style="background-color: #808000"/>     
            </td>
        </tr>
        <tr>
           <td align="left">
                <asp:Label ID="Label1" runat="server" Font-Names="Monotype Corsiva" Font-Size="15pt"
                ForeColor="#400000" Text="Saludo"></asp:Label>&nbsp; ud. está en &nbsp;<asp:Label
                    ID="Label2" runat="server" Text="inicio"></asp:Label></td>
    </tr>
    <tr>
    
        <td align="left">
            <hr size="4" style="background-color: #808000"/>   
         </td>
    </tr>
    <tr>
    
        <td align="left">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click">Reporte</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton27" runat="server" onclick="LinkButton27_Click">Pago</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Nomencladores</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Warehouse</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">WH-Miami</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton18" runat="server" onclick="LinkButton18_Click">WH-Jamaica</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton11" runat="server" onclick="LinkButton11_Click">Traces</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton22" runat="server" onclick="LinkButton22_Click">Account</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton23" runat="server" onclick="LinkButton23_Click">My Pass</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                    style="font-size: medium">logout()</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                 <asp:View ID="View2" runat="server">
                     <table>
                         <tr>
                             <td>
                                 <asp:LinkButton ID="LinkButton6" runat="server" onclick="LinkButton6_Click">Reporte</asp:LinkButton>
                             </td>
                             <td>
                                 <asp:LinkButton ID="LinkButton28" runat="server" onclick="LinkButton27_Click">Pago</asp:LinkButton>
                             </td>
                             <td>
                                 <asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton7_Click">Nomencladores</asp:LinkButton>
                             </td>
                             <td>
                                 <asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click">Warehouse</asp:LinkButton>
                             </td>
                             <td>
                                 <asp:LinkButton ID="LinkButton24" runat="server" onclick="LinkButton23_Click">My Pass</asp:LinkButton>
                             </td>
                             <td>
                                 <asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton10_Click" 
                                     style="font-size: medium">logout()</asp:LinkButton>
                             </td>
                         </tr>
                     </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton15" runat="server" onclick="LinkButton15_Click">WH-Miami</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton25" runat="server" onclick="LinkButton23_Click">My Pass</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton17" runat="server" onclick="LinkButton1_Click" 
                                    style="font-size: medium">logout()</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View4" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton21" runat="server" onclick="LinkButton18_Click">WH-Jamaica</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton26" runat="server" onclick="LinkButton23_Click">My Pass</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton20" runat="server" onclick="LinkButton1_Click" 
                                    style="font-size: medium">logout()</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
            </asp:View>
            </asp:MultiView>
         </td>
    </tr>
    <tr>
    
        <td align="left">
           
            &nbsp;</td>
    </tr>
</table>
