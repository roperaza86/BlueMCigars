using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_security : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        class_rpr.TConexionGrid("SELECT login,fecha,hora,evento,wh,cantidad,costo,vitola,capa,liga FROM tb_security ORDER BY id_operacion DESC", GridView1);
    }
     public void BindGrid()
     {
         class_rpr.TConexionGrid("SELECT login,fecha,hora,evento,wh,cantidad,costo,vitola,capa,liga FROM tb_security ORDER BY id_operacion DESC", GridView1);
     }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView1.PageIndex = newPageIndex;
        BindGrid();
    }
}