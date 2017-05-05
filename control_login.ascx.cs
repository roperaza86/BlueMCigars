using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class login : System.Web.UI.UserControl
{
   
   

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        

        string tiket_name=txt_nombre.Text;
        string tiket_pass=txt_pass.Text;
        //string tiket_pass=FormsAuthentication.HashPasswordForStoringInConfigFile(txt_pass.Text,"SHA1");
        //Session["pass"] = tiket_pass;
       
        
        

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("SP_acces_general", Conexion);
        cmd.CommandType = CommandType.StoredProcedure;



        cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));
        cmd.Parameters["@user"].Value = tiket_name.ToString();
        cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 50));
        cmd.Parameters["@pass"].Value = tiket_pass.ToString();  
    
        string tipo = "";
        bool check = false;

        Conexion.Open();
        try
        {
            
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                check = true;
                Session["login"] = tiket_name;
                class_rpr.control_operaciones(Session["login"].ToString(), "ha ingresado al sistema", "", "", "", "", 0, 0);
            
                

            }
            else
            {
                label_info.Text = "Creedeciales no autorizadas, este acceso en falso quedará notificado";
             /*   count++;             
                if(count==3)   
                {
                  //  label_info.Text = class_rpr.aviso_security();
                    
                }   
                */
            }

        }

        catch (SqlException ex)
        {
            label_info.Text = ex.Message;

        }
        finally
        {
            Conexion.Close();
        }

        if (check == true)
        {
           
            try
            {
            
            FormsAuthentication.RedirectFromLoginPage(tiket_name.ToString(), false);
            Session["usuario"] = tiket_name.ToString();
            Conexion.Open();
            tipo = (string)cmd.ExecuteScalar();

            switch (tipo)
            {
                case "admin": Session["nivel"] = "admin";
                    break;

                case "user": Session["nivel"] = "user";
                    break;
                case "user_miami": Session["nivel"] = "user_miami";
                    break;
                case "user_jamaica": Session["nivel"] = "user_jamaica";
                    break;
                default: Session["nivel"] = "admin";
                    break;
            }
        
            }
            catch(SqlException ex)
            {
                label_info.Text = ex.Message;

            }
            finally
            {
                Conexion.Close();
            }
        }

        


    }
}
