using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class control_ADMIN_Bitacora : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            class_rpr.Combo("SELECT id_vitola,vitola FROM tb_vitola order by vitola", "vitola", "id_vitola", DropDownList1);
            class_rpr.Combo("SELECT id_capa,capa FROM tb_capa order by capa", "capa", "capa", DropDownList2);
            class_rpr.Combo("SELECT id_liga,liga FROM tb_liga order by liga", "liga", "id_liga", DropDownList3);
           
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT login,fecha,hora,evento,wh,cantidad,costo FROM tb_security WHERE (vitola=@Vitola) AND (capa=@Capa) AND (liga=@Liga) ORDER BY FECHA DESC", conexion);
        DataSet DSet = new DataSet();


        adapter.SelectCommand.Parameters.Add(new SqlParameter("@Vitola", SqlDbType.VarChar, 50));
        adapter.SelectCommand.Parameters["@Vitola"].Value = DropDownList1.SelectedItem.Text.ToString();
        adapter.SelectCommand.Parameters.Add(new SqlParameter("@Capa", SqlDbType.VarChar, 50));
        adapter.SelectCommand.Parameters["@Capa"].Value = DropDownList2.SelectedItem.Text.ToString();
        adapter.SelectCommand.Parameters.Add(new SqlParameter("@Liga", SqlDbType.VarChar, 50));
        adapter.SelectCommand.Parameters["@Liga"].Value = DropDownList3.SelectedItem.Text.ToString();
    
        
        try
        {
            adapter.Fill(DSet);
            GridView1.DataSource = DSet;
            GridView1.DataBind();
        }
        catch(Exception ex)
        {
            Label1.Text = ex.Message;
        }
        finally
        {
        
        }
    }
}