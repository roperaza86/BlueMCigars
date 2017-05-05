using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class control_ADMIN_User : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nivel"] == "admin")
        {
            MultiView1.ActiveViewIndex = 0;
           

        }
        else 
        {
            MultiView1.ActiveViewIndex = 1;
        }
        
        
        if (!IsPostBack)
        {
            class_rpr.TConexionGrid("SELECT id_user,login,tipo FROM tb_user", GridView1);
        //    class_rpr.Combo("SELECT DISTINCT tipo FROM tb_user", "tipo", "tipo", DropDownList1);
           
           
        }
    }

    public void BindGrid()
    {
        class_rpr.TConexionGrid("SELECT id_user,login,tipo FROM tb_user", GridView1);
     //   class_rpr.Combo("SELECT DISTINCT tipo FROM tb_user", "tipo", "tipo", DropDownList1);
        

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];
        int id_user = int.Parse(row.Cells[1].Text.ToString());
        string user_login = row.Cells[2].Text.ToString();
         
        
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("DELETE FROM tb_user where id_user=@id_user", conexion);
        conexion.Open();

        cmd.Parameters.Add(new SqlParameter("@id_user", SqlDbType.Int));
        cmd.Parameters["@id_user"].Value = id_user;

        try
        {
            cmd.ExecuteNonQuery();
           // class_rpr.control_operaciones(Session["login"].ToString(), "Eliminó al usuario:" + user_login.ToString());
            GridView1.Caption = "Usuario:" + user_login.ToString()+" fue eliminado";
            BindGrid();

        }
        catch(SqlException ex)
        {
            GridView1.Caption = ex.Message.ToString();
        }
        finally
        {
            conexion.Close();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        string login = TextBox1.Text;
        string pass = TextBox2.Text;
        string tipo = DropDownList1.SelectedItem.ToString();

        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("INSERT INTO tb_user (login,pass,tipo)VALUES(@login,@pass,@tipo)", conexion);
        conexion.Open();

        cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar,50));
        cmd.Parameters["@login"].Value = login;
        cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 50));
        cmd.Parameters["@pass"].Value = pass;
        cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar, 50));
        cmd.Parameters["@tipo"].Value = tipo;

        try
        {
            cmd.ExecuteNonQuery();
        //    class_rpr.control_operaciones(Session["login"].ToString(), "Agregó al usuario:" + login.ToString());
            GridView1.Caption = "Usuario:" + login + " fue agregado";
            TextBox1.Text = "";
            BindGrid();

        }
        catch (SqlException ex)
        {
            GridView1.Caption = ex.Message.ToString();
        }
        finally
        {
            conexion.Close();
        }
        
        
        
    }
    
}