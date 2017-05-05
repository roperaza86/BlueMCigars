using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class control_ADMIN_Nomencladores : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    public void BindGrid()
    {
        class_rpr.TConexionGridProc("SP_see_vitola", GridView1);
        class_rpr.TConexionGridProc("SP_see_capa", GridView2);
        class_rpr.TConexionGridProc("SP_see_liga", GridView3);
        class_rpr.TConexionGridProc("SP_see_operario", GridView4);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string valor=DropDownList1.SelectedValue.ToString();
 
        switch (valor)
        {
            case "Vitola" : class_rpr.Vistas(MultiView1, 0);
                class_rpr.TConexionGridProc("SP_see_vitola", GridView1);
                break;
            case "Capa": class_rpr.Vistas(MultiView1, 1);
                class_rpr.TConexionGridProc("SP_see_capa", GridView2);
                break;
            case "Liga": class_rpr.Vistas(MultiView1, 2);
                class_rpr.TConexionGridProc("SP_see_liga", GridView3);
                break;
            case "Operario": class_rpr.Vistas(MultiView1, 3);
                class_rpr.TConexionGridProc("SP_see_operario", GridView4);
                break;

            case "Client": class_rpr.Vistas(MultiView1, 4);
                class_rpr.TConexionGridProc("SP_see_client_jamaica", GridView6);
                break;


               
        }
    
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string p_Vitola = TextBox1.Text.ToString();
        string p_havano="no";

        if (CheckBox1.Checked == true)
        {
            p_havano = "si";

        }
      
        
        
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("SP_insert_vitola", Conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.VarChar, 50));
        cmd.Parameters["@vitola"].Value = p_Vitola;

        cmd.Parameters.Add(new SqlParameter("@habano", SqlDbType.VarChar, 2));
        cmd.Parameters["@habano"].Value = p_havano;

        Conexion.Open();

        try
        {
            cmd.ExecuteNonQuery();
            Label1.Text = "La vitola: '" + p_Vitola + "' fue agregada correctamente.";
            TextBox1.Text = "";
            class_rpr.TConexionGridProc("SP_see_vitola", GridView1);
        }

        catch (SqlException ex)
        {
            string number_error = ex.Message.ToString();
            switch (number_error)
            {
                case "2627": Label1.Text = "Esta Vitola ya existe en la base de datos. No es posible repetirla";
                    TextBox1.Text = "";
                    TextBox1.Focus();
                    break;

                default: Label1.Text = ex.Message.ToString();
                    break;
            }
        }
        catch (Exception exT)
        {

            Label2.Text = exT.Message;

        }

        finally
        {
            Conexion.Close();
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        string p_Capa = TextBox2.Text.ToString();
        string p_havano = "no";

        if (CheckBox2.Checked == true)
        {
            p_havano = "si";

        }

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("SP_insert_capa", Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.VarChar, 50));
        cmd.Parameters["@capa"].Value = p_Capa;
        cmd.Parameters.Add(new SqlParameter("@habano", SqlDbType.VarChar, 2));
        cmd.Parameters["@habano"].Value = p_havano;
        Conexion.Open();

        try
        {
            cmd.ExecuteNonQuery();
            Label2.Text = "La capa: '" + p_Capa + "' fue agregada correctamente.";
            TextBox2.Text = "";
            class_rpr.TConexionGridProc("SP_see_capa", GridView2);
        }

        catch (SqlException ex)
        {
            string number_error = ex.Number.ToString();
            switch (number_error)
            {
                case "2627": Label2.Text = "Esta Capa ya existe en la base de datos. No es posible repetirla";
                    TextBox2.Text = "";
                    TextBox2.Focus();
                    break;

                default: Label2.Text = ex.Number.ToString();
                    break;           
            }
        }
        catch (Exception exT)
            {

             Label2.Text = exT.Message;
                               
            }
            
       finally
        {
            Conexion.Close();
        }
       
        
        
       
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string p_Liga = TextBox3.Text.ToString();
        string p_havano = "no";

        if (CheckBox3.Checked == true)
        {
            p_havano = "si";

        }
        

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("SP_insert_liga", Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.VarChar, 50));
        cmd.Parameters["@liga"].Value = p_Liga;
        cmd.Parameters.Add(new SqlParameter("@habano", SqlDbType.VarChar, 2));
        cmd.Parameters["@habano"].Value = p_havano;
        Conexion.Open();

        try
        {
            cmd.ExecuteNonQuery();
            Label3.Text = "La liga: '" + p_Liga + "' fue agregada correctamente.";
            TextBox3.Text = "";
            class_rpr.TConexionGridProc("SP_see_liga", GridView3);
        }

        catch (SqlException ex)
        {
            string number_error = ex.Number.ToString();
            switch (number_error)
            {
                case "2627": Label3.Text = "Esta Liga ya existe en la base de datos. No es posible repetirla";
                    TextBox3.Text = "";
                    TextBox3.Focus();
                    break;

                default: Label3.Text = ex.Number.ToString();
                    break;
            }
        }
        catch (Exception exT)
        {

            Label3.Text = exT.Message;

        }

        finally
        {
            Conexion.Close();
        }
       
        
        
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {


        string p_Operario = TextBox4.Text.ToString();
        


        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("INSERT INTO tb_operario (operario) VALUES (@p_Operario)", Conexion);

        cmd.Parameters.Add(new SqlParameter("@p_Operario", SqlDbType.VarChar, 50));
        cmd.Parameters["@p_Operario"].Value = p_Operario;
        Conexion.Open();

        try
        {
            cmd.ExecuteNonQuery();
            Label4.Text = "El operario: '" + p_Operario + "' fue agregado correctamente.";
            TextBox4.Text = "";
            class_rpr.TConexionGridProc("SP_see_operario", GridView4);
        }

        catch (SqlException ex)
        {
            string number_error = ex.Number.ToString();
            switch (number_error)
            {
                case "2627": Label4.Text = "Este operario ya existe en la base de datos. No es posible repetirlo";
                    TextBox4.Text = "";
                    TextBox4.Focus();
                    break;

                default: Label4.Text = ex.Number.ToString();
                    break;
            }
        }
        catch (Exception exT)
        {

            Label4.Text = exT.Message;

        }

        finally
        {
            Conexion.Close();
        }
       
        
        
    }
   
  
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView1.PageIndex = newPageIndex;
        BindGrid();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView2.PageIndex = newPageIndex;
        BindGrid();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView3.PageIndex = newPageIndex;
        BindGrid();
    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView4.PageIndex = newPageIndex;
        BindGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label1.Text = class_rpr.delete_prod_daily(GridView1, e, 1, "SP_delete_vitola", "Vitola eliminada de Nomencladores");
       BindGrid();
    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label2.Text = class_rpr.delete_prod_daily(GridView2, e, 1, "SP_delete_capa", "Capa eliminada de Nomencladores");
        BindGrid();

    }


    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label3.Text = class_rpr.delete_prod_daily(GridView3, e, 1, "SP_delete_liga", "Liga eliminada de Nomencladores");
        BindGrid();

    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {



        string p_Client = TextBox5.Text.ToString();
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("INSERT INTO tb_entrepot_jamaica_cliente (client) VALUES (@client)", Conexion);
        cmd.Parameters.Add(new SqlParameter("@client", SqlDbType.VarChar, 50));
        cmd.Parameters["@client"].Value = p_Client;
        Conexion.Open();

        try
        {
            cmd.ExecuteNonQuery();
            Label4.Text = "The client: '" + p_Client + "' added";

            class_rpr.TConexionGridProc("SP_see_client_jamaica", GridView6);
        }

        catch (SqlException ex)
        {
            string number_error = ex.Number.ToString();
            switch (number_error)
            {
                case "2627": Label4.Text = "This client exist already";
                    TextBox4.Text = "";
                    TextBox4.Focus();
                    break;

                default: Label4.Text = ex.Number.ToString();
                    break;
            }
        }
        catch (Exception exT)
        {

            Label4.Text = exT.Message;

        }

        finally
        {
            Conexion.Close();
            TextBox5.Text = "";
            TextBox5.Focus();
        }
       


    }
}