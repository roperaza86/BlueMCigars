using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class control_ADMIN_Warehouse : System.Web.UI.UserControl
{

    /*methodes */


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            BindGrid();
        }
        
    }

    public void BindGrid()
    {
        class_rpr.TConexionGrid("SP_see_Entrepot", GridView1);
        class_rpr.TConexionGrid("sp_see_tranferecias", GridView2);
         
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Label1.Text != "")
        {
            SqlConnection conexion_aux = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());


            int pvitola=0;
            int pcapa=0;
            int pliga=0;
            int pcantidad = 0;
          

            SqlCommand cmd_4Vitola = new SqlCommand("SELECT id_vitola FROM tb_vitola WHERE vitola='" + Label1.Text+ "'", conexion_aux);
            SqlCommand cmd_4Capa = new SqlCommand("SELECT id_capa FROM tb_capa WHERE capa='" + Label2.Text + "'", conexion_aux);
            SqlCommand cmd_4Liga = new SqlCommand("SELECT id_liga FROM tb_liga WHERE liga='" + Label3.Text + "'", conexion_aux);
            

           
          
            
         
            try
            {
             conexion_aux.Open();
             pvitola = (int)(cmd_4Vitola.ExecuteScalar());
             pcapa = (int)(cmd_4Capa.ExecuteScalar());
             pliga = (int)(cmd_4Liga.ExecuteScalar());               
             conexion_aux.Close();
            }
            catch(Exception Ex)
            {
              Label4.Text = Ex.Message;
              conexion_aux.Close();
            }
            try
            {
                SqlCommand cmd_4Cantidad = new SqlCommand("SELECT cantidad FROM tb_entrepot WHERE vitola=" + pvitola + " AND liga=" + pliga + " AND capa=" + pcapa + "", conexion_aux);
                conexion_aux.Open();
                pcantidad = (int)(cmd_4Cantidad.ExecuteScalar());
                conexion_aux.Close();
            }
            catch (Exception Ex)
            {
                Label4.Text = Ex.Message;
                conexion_aux.Close();
            }       
              
          
            

            int chk = int.Parse(TextBox1.Text.ToString());

            if (pcantidad >= chk)
            {
                string transfer = "";
                string name_entrepot ="";
                string name_entrepot_show = "";
                transfer = DropDownList1.SelectedValue.ToString();
                
                string transfer_real = "";
                switch (transfer.ToString())
                {
                    case "Miami": transfer_real = "INSERT INTO tb_entrepot_miami (vitola,capa,liga,cantidad)values(@vitola,@capa,@liga,@cantidad)";
                                  name_entrepot="tb_entrepot_miami";
                                  name_entrepot_show = "Miami";
                        break;

                    case "Jamaica": transfer_real = "INSERT INTO tb_entrepot_jamaica (vitola,capa,liga,cantidad)values(@vitola,@capa,@liga,@cantidad)";
                        name_entrepot = "tb_entrepot_jamaica";
                        name_entrepot_show = "Jamaica";
                        break;

                    case "Defecto": transfer_real = "INSERT INTO tb_defectusos_de_fabrica (vitola,capa,liga,cantidad)values(@vitola,@capa,@liga,@cantidad)";
                         name_entrepot="tb_defectusos_de_fabrica";
                         name_entrepot_show = "Defecto";
                        break;
                }

               

               
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
                SqlCommand cmd_Gestion = new SqlCommand(transfer_real, conexion);
                cmd_Gestion.CommandType = CommandType.Text;
                SqlCommand cmd_Gestion2 = new SqlCommand("UPDATE tb_entrepot SET cantidad=(cantidad-@cantidad) WHERE vitola=@vitola AND  capa=@capa AND liga=@liga", conexion);
             
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                cmd_Gestion.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                cmd_Gestion.Parameters["@vitola"].Value = pvitola;

                cmd_Gestion.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                cmd_Gestion.Parameters["@capa"].Value = pcapa;

                cmd_Gestion.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                cmd_Gestion.Parameters["@liga"].Value = pliga;

                cmd_Gestion.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                cmd_Gestion.Parameters["@cantidad"].Value = int.Parse(TextBox1.Text.ToString());

                /////////////////////////////////////////////////////////////////////////////////////////////////////
               
                ////////////////////////////////////////////////////////////////////////////////////////////////////////

                cmd_Gestion2.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                cmd_Gestion2.Parameters["@vitola"].Value = pvitola;

                cmd_Gestion2.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                cmd_Gestion2.Parameters["@capa"].Value = pcapa;

                cmd_Gestion2.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                cmd_Gestion2.Parameters["@liga"].Value = pliga;

                cmd_Gestion2.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                cmd_Gestion2.Parameters["@cantidad"].Value = int.Parse(TextBox1.Text.ToString());

               ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                conexion.Open();

                try
                {
                    cmd_Gestion.ExecuteNonQuery();
                    cmd_Gestion2.ExecuteNonQuery();
                 //   class_rpr.control_operaciones(Session["login"].ToString(), "Hizo una salida de:" + Label1.Text.ToString() + "/" + Label2.Text.ToString() + "/" + Label3.Text.ToString() + "||Cantidad:" + TextBox1.Text.ToString() + " En Fecha:" + Calendar1.SelectedDate.ToShortDateString() + "a:" + name_entrepot_show);
                    Label4.Text = "Transferido con exito inventario de:" + name_entrepot_show;

                    SqlConnection Conexion_Transferencia = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
                    SqlCommand cmd_Transferencia = new SqlCommand("sp_insert_historial_tranferecias", Conexion_Transferencia);
                    cmd_Transferencia.CommandType = CommandType.StoredProcedure;

                    cmd_Transferencia.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                    cmd_Transferencia.Parameters["@vitola"].Value = pvitola;
                    cmd_Transferencia.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                    cmd_Transferencia.Parameters["@capa"].Value = pcapa;
                    cmd_Transferencia.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                    cmd_Transferencia.Parameters["@liga"].Value = pliga;
                    cmd_Transferencia.Parameters.Add(new SqlParameter("@user", SqlDbType.Int));
                    cmd_Transferencia.Parameters["@user"].Value = int.Parse(Session["login"].ToString());
                    cmd_Transferencia.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                    cmd_Transferencia.Parameters["@cantidad"].Value = int.Parse(TextBox1.Text.ToString());
                    cmd_Transferencia.Parameters.Add(new SqlParameter("@date", SqlDbType.SmallDateTime));
                    cmd_Transferencia.Parameters["@date"].Value = DateTime.Now.Date.ToShortDateString();

                    cmd_Transferencia.Parameters.Add(new SqlParameter("@destino", SqlDbType.VarChar, 100));
                    cmd_Transferencia.Parameters["@destino"].Value = name_entrepot;
                }

                catch (SqlException ex)
                {
                    
                    if (ex.Number == 2627)
                    {

                        SqlConnection Conexion_auxiliar2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
                        SqlCommand cmd_GestionPb = new SqlCommand("UPDATE "+ name_entrepot+" SET cantidad=(cantidad+@cantidad) WHERE vitola=@vitola AND  capa=@capa AND liga=@liga", Conexion_auxiliar2);
                        SqlCommand cmd_GestionPb2 = new SqlCommand("UPDATE tb_entrepot SET cantidad=(cantidad-@cantidad) WHERE vitola=@vitola AND  capa=@capa AND liga=@liga", Conexion_auxiliar2);


                        cmd_GestionPb.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                        cmd_GestionPb.Parameters["@vitola"].Value = pvitola;

                        cmd_GestionPb.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                        cmd_GestionPb.Parameters["@capa"].Value = pcapa;

                        cmd_GestionPb.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                        cmd_GestionPb.Parameters["@liga"].Value = pliga;

                        cmd_GestionPb.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                        cmd_GestionPb.Parameters["@cantidad"].Value = int.Parse(TextBox1.Text.ToString());
                        /////////////////////////////////////////////////////////////////////////////////////4cmd_GestionPb.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));

                        cmd_GestionPb2.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                        cmd_GestionPb2.Parameters["@vitola"].Value = pvitola;

                        cmd_GestionPb2.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                        cmd_GestionPb2.Parameters["@capa"].Value = pcapa;

                        cmd_GestionPb2.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                        cmd_GestionPb2.Parameters["@liga"].Value = pliga;

                        cmd_GestionPb2.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                        cmd_GestionPb2.Parameters["@cantidad"].Value = int.Parse(TextBox1.Text.ToString());



                        Conexion_auxiliar2.Open();
                        cmd_GestionPb.ExecuteNonQuery();
                        cmd_GestionPb2.ExecuteNonQuery();
                        Conexion_auxiliar2.Close();
                        Label4.Text = "Transferido con exito inventario de:" + name_entrepot_show;
                   //     class_rpr.control_operaciones(Session["login"].ToString(), "Hizo una salida de:" + Label1.Text.ToString() + "/" + Label2.Text.ToString() + "/" + Label3.Text.ToString() + "||Cantidad:" + TextBox1.Text.ToString() + " En Fecha:" + Calendar1.SelectedDate.ToShortDateString()+" a:"+name_entrepot_show);


                        SqlConnection Conexion_Transferencia = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
                        SqlCommand cmd_Transferencia = new SqlCommand("sp_insert_historial_tranferecias", Conexion_Transferencia);
                        cmd_Transferencia.CommandType = CommandType.StoredProcedure;

                        cmd_Transferencia.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                        cmd_Transferencia.Parameters["@vitola"].Value=pvitola;
                        cmd_Transferencia.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                        cmd_Transferencia.Parameters["@capa"].Value=pcapa;
                        cmd_Transferencia.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                        cmd_Transferencia.Parameters["@liga"].Value=pliga;
                        cmd_Transferencia.Parameters.Add(new SqlParameter("@user", SqlDbType.Int));
                        cmd_Transferencia.Parameters["@user"].Value= int.Parse(Session["login"].ToString());
                        cmd_Transferencia.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                        cmd_Transferencia.Parameters["@cantidad"].Value = int.Parse(TextBox1.Text.ToString());
                        cmd_Transferencia.Parameters.Add(new SqlParameter("@date", SqlDbType.SmallDateTime));
                        cmd_Transferencia.Parameters["@date"].Value = DateTime.Now.Date.ToShortDateString();

                        cmd_Transferencia.Parameters.Add(new SqlParameter("@destino", SqlDbType.VarChar,100));
                        cmd_Transferencia.Parameters["@destino"].Value = name_entrepot;




                     

                    }

                }

                catch(Exception Eg)
                {

                    Label4.Text = Eg.Message;
                }

                finally
                {
                    conexion.Close();
                    BindGrid();
                }

            }
            else
            {
                Label4.Text = "No hay suficiente disponibilidad para su pedido";
            }
        } 
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];
        row.ControlStyle.BackColor = System.Drawing.Color.BlueViolet;
        Label1.Text = row.Cells[2].Text.ToString();
        Label2.Text = row.Cells[3].Text.ToString();
        Label3.Text = row.Cells[4].Text.ToString();
       
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox2.Text = Calendar1.SelectedDate.ToShortDateString();
    }
}