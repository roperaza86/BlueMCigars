<%@ Control Language="C#" AutoEventWireup="true" CodeFile="control_ADMIN_Warehouse_Miami.ascx.cs" Inherits="control_ADMIN_Warehouse_Miami" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<script type="text/javascript" >


    /*$(function () {
          $("body").fadeIn(3000); 

    });

    $(function () { 
        $("body").fadeIn(3000);

    });

    $(function () {    
        $("#tabla1").slideDown();    
    });*/
     
    

</script>




<div id="div_principal">
<table id="tabla1" >
    <tr bgcolor="Olive" style="color: #FFFFFF">
        <td>
            <strong>WAREHOUSE-MIAMI</strong></td>
        <td>
            <strong>Gestion de Ventas</strong></td>
            <tr>
            <td>
                <table>
                    <tr>
                        <td>
            <strong><asp:LinkButton ID="LinkButton10" runat="server" 
                onclick="LinkButton10_Click">Delete</asp:LinkButton>
            </strong>
                        </td>
                        <td>
                            <strong>
                <asp:Label ID="Label10" runat="server"></asp:Label>
            </strong>
                        </td>
                        <td>
                                            <asp:ImageButton ID="ImageButton4" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" 
                                onclick="ImageButton4_Click2" Width="25px" />
                                        </td>
                    </tr>
                </table>
                </td>
            </tr>
    </tr>
    <tr valign="top">
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id_gestion_miami" onrowdeleting="GridView1_RowDeleting" 
                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                PageSize="50" 
                HorizontalAlign="Center" AllowSorting="True">
            <HeaderStyle BackColor="Olive" ForeColor="White" />
            <AlternatingRowStyle BackColor="#BCB934" />
                <Columns>
                    <asp:CommandField DeleteText="-&gt;" ShowDeleteButton="True" >
                    <ControlStyle Font-Bold="False" />
                    </asp:CommandField>
                    <asp:BoundField DataField="id_gestion_miami" HeaderText="Id" />
                    <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                    <asp:BoundField DataField="capa" HeaderText="Capa" />
                    <asp:BoundField DataField="Liga" HeaderText="Liga" />
                    <asp:BoundField DataField="cantidad" HeaderText="Existente" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="date" HeaderText="Date" 
                        DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                    <asp:BoundField DataField="entry" HeaderText="Entry" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle Font-Bold="True" Font-Size="Large" />
            </asp:GridView>
        </td>
        <td valign="top">
            <table >
                <tr>
                    <td>
                                <table >
                                    <tr bgcolor="Olive" style="color: #FFFFFF">
                                        <td colspan="2" style="font-weight: 700" >
                                            Add</td>
                                        <td style="font-weight: 700" >
                                            Make invoice</td>
                                        <td style="font-weight: 700" >
                                            Last&nbsp; Invoices</td>
                                    </tr>
                                    <tr valign="middle">
                                        <td class="style4" >
                                            &nbsp;Vitola</td>
                                        <td align="left" style="color: #FFFFFF" >
                                            <asp:DropDownList ID="DropDownList5" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton1_Click" Width="25px" />
                                        </td>
                                        <td align="left" style="color: #FF0000"  rowspan="7">
            <table>
                <tr valign="top">
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
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Cantidad</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="51px" 
                            ValidationGroup="invoices"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                ControlToValidate="TextBox1" Display="Dynamic" 
                                                ErrorMessage="Solo numeros enteros" 
                            ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                                ValidationGroup="invoices"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        INVOICE</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Width="51px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Price&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Width="86px"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right" >
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                            Text="OK" Enabled="False" ValidationGroup="invoices" 
                            style="text-align: right; height: 26px;" />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
                                        </td>
                                        <td align="left" style="color: #FF0000"  rowspan="7" valign="top">
                                            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                                           
                                            <br />
                                             <ajaxToolkit:BalloonPopupExtender ID="ListBox1_BalloonPopupExtender" 
                                                runat="server" TargetControlID="ListBox1" BalloonPopupControlID="Panel1" DisplayOnMouseOver=true DisplayOnClick=false>
                                            </ajaxToolkit:BalloonPopupExtender>
                                            <asp:LinkButton ID="LinkButton13" runat="server" onclick="LinkButton13_Click">Print</asp:LinkButton>
                                            <asp:Panel ID="Panel1" runat="server">
                                                <span style="color: rgb(34, 34, 34); font-family: &quot;Diaria Light Pro&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(245, 246, 245); display: inline !important; float: none;">
                                                Here you have the last invoices made</span></asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style4">
                                            Capa</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton2_Click" Width="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style4">
                                            Liga</td>
                                        <td align="left" style="color: #FFFFFF">
                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                                ImageUrl="~/img/Refresh-icon.png" onclick="ImageButton3_Click" Width="25px" />
                                        </td>
                                    </tr>
                                     <tr>
                                    <td class="style4">Cantidad</td>
                                    <td> 
                                        <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="prod_diaria" 
                                            Width="68px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ErrorMessage="RequiredFieldValidator" style="color: #FF0000" 
                                            ValidationGroup="prod_diaria" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                ControlToValidate="TextBox2" Display="Dynamic" 
                                                ErrorMessage="Solo numeros enteros" ForeColor="#FF3300" MaximumValue="1000000" 
                                                MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                                ValidationGroup="prod_diaria"></asp:RangeValidator>
                                        </td>

                                   
                                    
                                    </tr>
                                     <tr>
                                    <td class="style4">Entry </td>
                                    <td> 
                                        <asp:TextBox ID="TextBox4" runat="server" Width="68px"></asp:TextBox>
                                        </td>

                                   
                                    
                                    </tr>
                                     <tr>
                                    <td class="style4">Date</td>
                                    <td> 
                                       
                                        <asp:TextBox ID="txtDateEntree" runat="server"></asp:TextBox>
                                        <asp:Image ID="Imagebtn1" runat="server" ImageUrl="~/img/calendar.png" />

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            Format="MM/dd/yyyy" PopupButtonID="Imagebtn1" PopupPosition="BottomRight" 
                                            TargetControlID="txtDateEntree" TodaysDateFormat="MMMM, d yyyy" />
                                        </td>

                                   
                                    
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                ToolTip="Clic para agregar un nuevo producto" 
                                                ValidationGroup="prod_diaria">Agregar</asp:LinkButton>
                                        </td>
                                       
                                        <td align="left">
                                            </td>
                                       
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="2" >
                                            <asp:Label ID="Label5" runat="server" Visible="False">5</asp:Label>
                                            <asp:Label ID="Label6" runat="server" Visible="False">6</asp:Label>
                                            <asp:Label ID="Label7" runat="server" Visible="False">7</asp:Label>
                                            <asp:Label ID="Label8" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                </tr>
                <tr>
                    <td>
<table>
    <tr>
        <td valign="top">
                                <table class="style3">
                                    <tr>
                                        <td>
                                            Historial-&gt;<table 
                                                border="1">
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Producto</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">Entry</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton6" runat="server" onclick="LinkButton6_Click">Estadistica 1</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton  ID="LinkButton8" runat="server" onclick="LinkButton8_Click">Historial</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton7_Click">Reporte</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="3">
                                    <asp:View ID="View1" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Vitola" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Capa" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Liga" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Entry" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Filtrar</asp:LinkButton>
                                                                &nbsp;&nbsp;
                                                                <asp:LinkButton ID="LinkButton11" runat="server" onclick="LinkButton11_Click">Delete</asp:LinkButton>
                                                                &nbsp;
                                                                <asp:LinkButton ID="LinkButton12" runat="server" onclick="LinkButton12_Click">Eliminar y Restaurar</asp:LinkButton>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GridView2" runat="server" 
                                                        AutoGenerateColumns="False" Caption="Historial" CaptionAlign="Left" 
                                                        onpageindexchanging="GridView2_PageIndexChanging" AllowSorting="True" 
                                                        AllowPaging="True" PageSize="20">
                                                        <HeaderStyle BackColor="Olive" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="#BCB934" />
                                                        <Columns>
                                                            <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                                            <asp:BoundField DataField="capa" HeaderText="Capa" />
                                                            <asp:BoundField DataField="liga" HeaderText="Liga" />
                                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                            <asp:BoundField DataField="invoice" HeaderText="Invoice" />
                                                            <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                                                HeaderText="Fecha" HtmlEncode="False" />
                                                            <asp:BoundField DataField="login" HeaderText="Login" />
                                                            <asp:BoundField DataField="entry" HeaderText="Entry" />
                                                            <asp:BoundField DataField="Price" HeaderText="Price" />
                                                            <asp:BoundField DataField="id" HeaderText="Id" />
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>                                    
                                    <asp:View ID="View2" runat="server">
                                        <table class="style3">
                                            <tr>
                                                <td>
                                                    Entry
                                                    <asp:TextBox ID="txt_historialEntry" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click">Filtrar</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GridView5" runat="server" AllowSorting="True" 
                                                        AutoGenerateColumns="False" Caption="Historial" CaptionAlign="Left" 
                                                        onpageindexchanging="GridView2_PageIndexChanging" PageSize="50">
                                                        <HeaderStyle BackColor="Olive" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="#BCB934" />
                                                        <Columns>
                                                            <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                                            <asp:BoundField DataField="capa" HeaderText="Capa" />
                                                            <asp:BoundField DataField="liga" HeaderText="Liga" />
                                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                            <asp:BoundField DataField="invoice" HeaderText="Invoice" />
                                                            <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                                                HeaderText="Fecha" HtmlEncode="False" />
                                                            <asp:BoundField DataField="login" HeaderText="Login" />
                                                            <asp:BoundField DataField="entry" HeaderText="Entry" />
                                                            <asp:BoundField DataField="Price" HeaderText="Price" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server">
                                        <asp:GridView ID="GridView6" runat="server" AllowSorting="True" 
                                            AutoGenerateColumns="False" Caption="Historial" CaptionAlign="Left" 
                                            onpageindexchanging="GridView2_PageIndexChanging" PageSize="50" 
                                            AllowPaging="True">
                                            <HeaderStyle BackColor="Olive" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#BCB934" />
                                            <Columns>
                                                <asp:BoundField DataField="entry" HeaderText="Entry" />
                                                <asp:BoundField DataField="price" HeaderText="Price" 
                                                    NullDisplayText="No Price(free)" />
                                                <asp:BoundField DataField="suma" HeaderText="Sales+Last Date" />
                                                <asp:BoundField DataField="First" HeaderText="Sales First Date " />
                                                <asp:BoundField DataField="puros" HeaderText="Cantidad Puros" />
                                                <asp:BoundField DataField="Operaciones" HeaderText="Operaciones" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:View>

                                    <asp:View ID="View4" runat="server">
                                       <asp:GridView ID="GridView7" runat="server" AllowSorting="True" 
                                            AutoGenerateColumns="False" Caption="Historial" CaptionAlign="Left" 
                                            onpageindexchanging="GridView2_PageIndexChanging" PageSize="50" 
                                            AllowPaging="True">
                                            <HeaderStyle BackColor="Olive" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#BCB934" />
                                            <Columns>
                                                <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                                <asp:BoundField DataField="capa" HeaderText="Capa" />
                                                <asp:BoundField DataField="liga" HeaderText="Liga" />
                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="invoice" HeaderText="Invoice" />
                                                <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                                    HeaderText="Fecha" HtmlEncode="False" />
                                                <asp:BoundField DataField="login" HeaderText="Login" />
                                                <asp:BoundField DataField="entry" HeaderText="Entry" />
                                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                            </Columns>
                                        </asp:GridView>
                                </asp:View>
                                 <asp:View ID="View5" runat="server">
                                     <asp:DropDownList ID="DropDownList6" runat="server" 
                                         onselectedindexchanged="DropDownList6_SelectedIndexChanged">
                                     </asp:DropDownList>
                                     <asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton9_Click">Ok</asp:LinkButton>
                                     &nbsp;&nbsp;&nbsp;<br />
                                     <asp:GridView ID="GridView8" runat="server" AllowPaging="True" 
                                         AllowSorting="True" AutoGenerateColumns="False" Caption="Historial" 
                                         CaptionAlign="Left" onpageindexchanging="GridView2_PageIndexChanging" 
                                         PageSize="50">
                                         <HeaderStyle BackColor="Olive" ForeColor="White" />
                                         <AlternatingRowStyle BackColor="#BCB934" />
                                         <Columns>
                                             <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                             <asp:BoundField DataField="capa" HeaderText="Capa" />
                                             <asp:BoundField DataField="liga" HeaderText="Liga" />
                                             <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                             <asp:BoundField DataField="invoice" HeaderText="Invoice" />
                                             <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" 
                                                 HeaderText="Fecha" HtmlEncode="False" />
                                             <asp:BoundField DataField="login" HeaderText="Login" />
                                             <asp:BoundField DataField="entry" HeaderText="Entry" />
                                             <asp:BoundField DataField="Price" HeaderText="Price" />
                                         </Columns>
                                     </asp:GridView>
                                     &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                                         AutoDataBind="true" />
                                     &nbsp;<%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                                         Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                                         WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
                                         ShowExportControls="False" ShowFindControls="False" ShowRefreshButton="False" 
                                         ShowZoomControl="False"><LocalReport ReportPath="Report2.rdlc"></LocalReport></rsweb:ReportViewer>--%><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                         OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                                         TypeName="DataSetMiamiTableAdapters.SP_miami_historialTableAdapter">
                                     </asp:ObjectDataSource>
                                     <br />
                                  </asp:View>
                                </asp:MultiView>
                                        </td>
                                    </tr>
                                </table>
                                
                                <br />
        </td>
    </tr>
</table>
                    </td>
                </tr>
                <tr>
                    <td>
                                <table >
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                                Caption="TOP 5 +PLUS">
                                                <AlternatingRowStyle BackColor="#FFFFCC" />
                                                <Columns>
                                                    <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                                    <asp:BoundField DataField="capa" HeaderText="Capa" />
                                                    <asp:BoundField DataField="liga" HeaderText="Liga" />
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" >
                                                    <ControlStyle BorderColor="Red" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <HeaderStyle BackColor="#FF3300" />
                                            </asp:GridView>
                                        </td>
                                        <td>
                                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                                Caption="TOP 5 -PLUS">
                                                <AlternatingRowStyle BackColor="#FFFFCC" />
                                                <Columns>
                                                    <asp:BoundField DataField="vitola" HeaderText="Vitola" />
                                                    <asp:BoundField DataField="capa" HeaderText="Capa" />
                                                    <asp:BoundField DataField="liga" HeaderText="Liga" />
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                </Columns>
                                                <HeaderStyle BackColor="#6600FF" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>
