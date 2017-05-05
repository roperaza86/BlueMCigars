using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;



public partial class control_ADMIN_produccion_diaria : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            //class_rpr.TConexionGrid("SELECT  idWH,id_registro,Fecha,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,tb_operario.operario,Cantidad FROM (((tb_produccion_diaria LEFT JOIN tb_vitola ON tb_produccion_diaria.vitola = tb_vitola.id_vitola)LEFT JOIN tb_capa ON tb_produccion_diaria.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_produccion_diaria.liga=tb_liga.id_liga)LEFT JOIN tb_operario ON tb_produccion_diaria.operario=tb_operario.id_operario ORDER BY Fecha DESC", GridView1);

            //class_rpr.Combo("SELECT id_vitola,vitola FROM tb_vitola ORDER BY vitola", "vitola", "id_vitola", DropDownList1);
            class_rpr.Combo("SP_see_vitola", "vitola", "id_vitola", DropDownList1);

            class_rpr.Combo("SP_see_capa", "capa", "id_capa", DropDownList2);
            class_rpr.Combo("SP_see_liga", "liga", "id_liga", DropDownList3);
            class_rpr.Combo("SP_see_operario", "operario", "id_operario", DropDownList4);
        }
        BindGrid();
    }

    public void BindGrid()
    {
       // class_rpr.TConexionGrid("SELECT  idWH,id_registro,Fecha,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,tb_operario.operario,Cantidad FROM (((tb_produccion_diaria LEFT JOIN tb_vitola ON tb_produccion_diaria.vitola = tb_vitola.id_vitola)LEFT JOIN tb_capa ON tb_produccion_diaria.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_produccion_diaria.liga=tb_liga.id_liga)LEFT JOIN tb_operario ON tb_produccion_diaria.operario=tb_operario.id_operario ORDER BY Fecha DESC ", GridView1);
        class_rpr.TConexionGrid("SP_production_daily", GridView1);
    }

    
    
    protected void LinkButton1_Click(object sender, EventArgs e) 
    {
         string mensaje = class_rpr.agregar_p_diaria(DropDownList1.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString(), TextBox2.Text.ToString(), ""/* 2*/);
         class_rpr.TConexionGrid("SP_production_daily", GridView1);



      // // String fecha = TextBox4.Text.ToString();
      //  //String fechaA = TextBox4.Text.Remove(2, 4);
      // // String fechaAnne = fechaA.Substring(2, 4);
      // // String fechaMois = fechaA.Substring(0, 2);
      ////  String fechaT = fechaAnne.ToString() + fechaMois.ToString(); 

      ////  int fechaAgrup = int.Parse(fechaT); 
        
      //  /*codigo agregado*/
      //  String fechaT = "";
      //  String fecha = "";
      //  int fechaAgrup = 4;

      // //////////////////////////////
       
        
        
        
      // // if (fecha != "0001-01-01")
      //  if(1==1)
      //  {
      //      string mensaje = class_rpr.agregar_p_diaria(DropDownList1.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString(), TextBox2.Text.ToString(), fecha, fechaAgrup);
      //      class_rpr.TConexionGrid("SP_production_daily", GridView1);


      //      if (mensaje == "*NPU*")
      //      {
      //          TextBox3.Text = mensaje;
      //          TextBox3.Enabled = true;
      //          LinkButton2.Enabled = true;
      //          LinkButton1.Enabled = false;
      //      }
      //      else
      //      {

      //          TextBox3.Text = class_rpr.chekeo_costo(int.Parse(DropDownList1.SelectedValue.ToString()), int.Parse(DropDownList2.SelectedValue.ToString()), int.Parse(DropDownList3.SelectedValue.ToString())).ToString();
      //          mensaje += class_rpr.control_operaciones(Session["login"].ToString(), "Agregado a la producción diaria", "Nicaragua", DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, int.Parse(TextBox2.Text.ToString()), decimal.Parse(TextBox3.Text));

      //          Label1.Text = mensaje;

      //          BindGrid();
      //      }

      //     // txtdate.Text = "";
           
      //  }

      //  else {
      //         Label1.Text = "Escoja una fecha valida";     
      //       }   
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        /*int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];

        string P_vitola = row.Cells[3].Text.ToString();
        string P_capa = row.Cells[4].Text.ToString();
        string P_liga = row.Cells[5].Text.ToString();
        int P_cantidad = int.Parse(row.Cells[7].Text.ToString());
        String p_Fecha = row.Cells[2].Text.ToString();
        
        
        
        Label2.Text = class_rpr.moins_entrepot_prod_daily(GridView1, e, 1, "Actualizado WareHouse");
        class_rpr.control_operaciones(Session["login"].ToString(), "Actualizó el WH (-)", "Nicaragua", P_vitola, P_capa, P_liga, P_cantidad, 0);
        class_rpr.control_operaciones(Session["login"].ToString(), "Se eliminó de la producción diaria", "Nicaragua", P_vitola, P_capa, P_liga, P_cantidad, 0);
        Label2.Text += " y " + class_rpr.delete_prod_daily(GridView1, e, 1, "SP_delete_prod_daily", "Registro eliminado de la Prod.Diaria");
       
    */}
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView1.PageIndex = newPageIndex;
        BindGrid();

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SP_see_vitola", "vitola", "id_vitola", DropDownList1);
       
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SP_see_capa", "capa", "id_capa", DropDownList2);
        
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SP_see_liga", "liga", "id_liga", DropDownList3);
        
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SP_see_operario", "operario", "id_operario", DropDownList4);
       
    }
   
  
/*
    public void agrego_costo(int p_vitola, int p_capa, int p_liga, decimal p_unitario)
    {

       
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlCommand cmd = new SqlCommand("INSERT INTO tb_costos  (vitola,capa,liga,costo_main_ouvre) VALUES (@vitola,@capa,@liga,@punitario)", Conexion);
        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = p_vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = p_capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = p_liga;
        cmd.Parameters.Add(new SqlParameter("@punitario", SqlDbType.Decimal));
        cmd.Parameters["@punitario"].Value = p_unitario;

        Conexion.Open();

        try
   
            
             {
                cmd.ExecuteNonQuery();
                Label2.Text = "Este Registro ya tiene precio unitario por favor prosiga";
                Label1.Text = "Este Registro ya tiene precio unitario por favor prosiga";
                TextBox3.Enabled = false;


            }
            catch (SqlException)
            {

            }
            finally
            {
                Conexion.Close();
            }


        }

    */

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int p_Vitola = int.Parse(DropDownList1.SelectedValue.ToString());
        int p_Capa = int.Parse(DropDownList2.SelectedValue.ToString());
        int p_Liga = int.Parse(DropDownList3.SelectedValue.ToString());
        decimal costo_m_o = decimal.Parse(TextBox3.Text.ToString());
        Label1.Text=class_rpr.add_costo(p_Vitola, p_Capa, p_Liga, costo_m_o);
        if (Label1.Text == "Costo agregado")
        {
            class_rpr.control_operaciones(Session["login"].ToString(), "Agrego costo a ", "Nicaragua", DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, 0, costo_m_o);
        }
        LinkButton2.Enabled = false;
        TextBox3.Enabled = false;
        LinkButton1.Enabled = true;
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
       
        
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        String fecha = TextBox4.Text.ToString(); 
        String fechaA = TextBox4.Text.Remove(2, 4);
        String fechaAnne = fechaA.Substring(2, 4);
        String fechaMois = fechaA.Substring(0, 2);
        Label1.Text = fechaAnne.ToString()+fechaMois.ToString(); 
        //CB/23/20A6

       
    }
}

