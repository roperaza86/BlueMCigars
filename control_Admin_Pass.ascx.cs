using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;


public partial class control_Admin_Pass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        string tiket_name = Session["login"].ToString();
        string tiket_pass = TextBox1.Text;
       



        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("SELECT pass FROM tb_user WHERE login=@user AND pass=@pass", Conexion);
        SqlCommand cmd_act = new SqlCommand("UPDATE tb_user SET pass=@new_pass WHERE login=@user AND pass=@pass", Conexion);

        
        cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));
        cmd.Parameters["@user"].Value = tiket_name.ToString();
        cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 50));
        cmd.Parameters["@pass"].Value = tiket_pass.ToString();

        cmd_act.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));
        cmd_act.Parameters["@user"].Value = tiket_name.ToString();
        cmd_act.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 50));
        cmd_act.Parameters["@pass"].Value = tiket_pass.ToString();
        cmd_act.Parameters.Add(new SqlParameter("@new_pass", SqlDbType.VarChar, 50));
        cmd_act.Parameters["@new_pass"].Value = TextBox2.Text;

       
     

        Conexion.Open();
        try
        {

            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                Conexion.Close();
                Conexion.Open();
               try
               {
                   cmd_act.ExecuteNonQuery();
                   Label1.Text = "Password Actualizado/Update";
                   TextBox1.Text = "";
                   TextBox2.Text = "";
                   TextBox3.Text = "";
          //         class_rpr.control_operaciones(Session["login"].ToString(), "cambió su password");
               }
                catch(SqlException eq)
               {
                   Label1.Text = eq.Message;
                }
            }
            else
            {
                Label1.Text = "La contraseña actual es incorrecta/ The actual password is incorrect";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox1.Focus();
            }

        }

        catch (SqlException ex)
        {
            Label1.Text = ex.Message;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";

        }
        finally
        {
            Conexion.Close();
        }

       
        

        

    }
}