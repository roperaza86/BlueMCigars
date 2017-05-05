<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  MasterPageFile="~/MasterPage.master"%>

<%@ Register src="control_login.ascx" tagname="control_login" tagprefix="uc1" %>

<%@ Register src="control_ADMIN_produccion_diaria.ascx" tagname="control_ADMIN_produccion_diaria" tagprefix="uc2" %>

<%@ Register src="control_ADMIN_Nomencladores.ascx" tagname="control_ADMIN_Nomencladores" tagprefix="uc3" %>

<%@ Register src="control_ADMIN_Warehouse.ascx" tagname="control_ADMIN_Warehouse" tagprefix="uc4" %>

<%@ Register src="control_ADMIN_Warehouse_Miami.ascx" tagname="control_ADMIN_Warehouse_Miami" tagprefix="uc5" %>

<%@ Register src="control_security.ascx" tagname="control_security" tagprefix="uc6" %>

<%@ Register src="control_admin_Warenhouse_jamaica.ascx" tagname="control_admin_Warenhouse_jamaica" tagprefix="uc7" %>

<%@ Register src="control_ADMIN_User.ascx" tagname="control_ADMIN_User" tagprefix="uc8" %>

<%@ Register src="control_Admin_Pass.ascx" tagname="control_Admin_Pass" tagprefix="uc9" %>

<%@ Register src="control_ADMIN_Bitacora.ascx" tagname="control_ADMIN_Bitacora" tagprefix="uc10" %>

<%@ Register src="control_ADMIN_main_ouvre.ascx" tagname="control_ADMIN_main_ouvre" tagprefix="uc11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>        
        <tr>
            <td>
                <asp:MultiView ID="MultiView_Admin" runat="server">
                    <asp:View ID="View1" runat="server">
                        <uc2:control_ADMIN_produccion_diaria ID="control_ADMIN_produccion_diaria1" 
                            runat="server" />
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <uc3:control_ADMIN_Nomencladores ID="control_ADMIN_Nomencladores1" 
                            runat="server" />
                    </asp:View>
                     <asp:View ID="View3" runat="server">
                         <uc4:control_ADMIN_Warehouse ID="control_ADMIN_Warehouse1" runat="server" />
                    </asp:View>
                     <asp:View ID="View4" runat="server">
                         <uc5:control_ADMIN_Warehouse_Miami ID="control_ADMIN_Warehouse_Miami1" 
                             runat="server" />
                    </asp:View>
                     <asp:View ID="View5" runat="server">
                        <table>
                            <tr valign="top">
                                <td>
                                    <uc10:control_ADMIN_Bitacora ID="control_ADMIN_Bitacora1" runat="server" />
                                </td>
                                <td>
                                    <uc6:control_security ID="control_security1" runat="server" />
                                </td>
                            </tr>
                         </table>
                            
                    </asp:View>
                    <asp:View ID="View6" runat="server">
                            <uc7:control_admin_Warenhouse_jamaica ID="control_admin_Warenhouse_jamaica1" 
                             runat="server" />
                    </asp:View>
                     <asp:View ID="View7" runat="server">
                          <uc8:control_ADMIN_User ID="control_ADMIN_User1" runat="server" />
                    </asp:View>
                     <asp:View ID="View9" runat="server">
                         <uc9:control_Admin_Pass ID="control_Admin_Pass1" runat="server" />
                    </asp:View>
                      <asp:View ID="View8" runat="server">
                          <uc11:control_ADMIN_main_ouvre ID="control_ADMIN_main_ouvre1" runat="server" />
                    </asp:View>
                </asp:MultiView>
               
            </td>
        </tr>
        <tr>
            <td>

   </td>
        </tr>
    </table>


</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    
    </asp:Content>



