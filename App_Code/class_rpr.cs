using System;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.Net.NetworkInformation;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Web.Configuration;
using System.Collections;


/// <summary>
/// Summary description for class_rpr
/// </summary>
public class class_rpr
{
    

    public class_rpr()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void Vistas(MultiView pMulti, int index)
    {
        pMulti.ActiveViewIndex = index;
    }
    public static void Vistas_Body(MultiView pMulti, int nivel)
    {
        pMulti.ActiveViewIndex = nivel;
    }
    public static void TConexionGrid(string aSP, GridView Grid)
    {
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.Text;
        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }

    public static void TConexionGridProc(string aSP, GridView Grid)
    {
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }
    public static void TConexionGrid(string aSP, GridView Grid, string aParametro)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
       // aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro"].Value = aParametro;

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }

    public static void TConexionGridProcHistorialMiami(string aSP, GridView Grid, string aParametro)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@entry", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@entry"].Value = aParametro;

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }

    public static void TConexionGrid(string aSP, GridView Grid, DateTime aParametro_1, DateTime aParametro_2)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        //   aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro1", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro1"].Value = aParametro_1.ToShortDateString();
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro2", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro2"].Value = aParametro_2.ToShortDateString();

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }
    public static void TConexionGrid(string aSP, GridView Grid,DateTime aParametro_2)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        //   aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

       
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro2", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro2"].Value = aParametro_2.ToShortDateString();

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }

    public static void TConexionGridProc(string aSP, GridView Grid, DateTime aParametro_1, DateTime aParametro_2)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro1", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro1"].Value = aParametro_1.ToShortDateString();
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro2", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro2"].Value = aParametro_2.ToShortDateString();

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }

    public static void TConexionListdProc(string aSP, ListBox listB)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        SqlDataReader reader = null; 
        Conexion.Open();
        reader= aSDA.SelectCommand.ExecuteReader();

        Queue myList = new Queue();

        while (reader.HasRows)
        {
            while (reader.Read())
            {
               
                string invoice=reader.GetString(0);
                myList.Enqueue(invoice);
            }

            reader.NextResult();



        
        }
        reader.Close();
        Conexion.Close();

       foreach(string k in myList)
       {
           listB.Items.Add(k);
        
       }
        

        
    }

    public static void TConexionGridProcHistorialMiami(string aSP, GridView Grid,String vitola,String capa, String liga, String entry)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@vitola", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@vitola"].Value =vitola;
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@capa", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@capa"].Value = capa;
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@liga", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@liga"].Value = liga;
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@entry", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@entry"].Value = entry;

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Grid.DataSource = aDS.Tables[0].DefaultView;
        Grid.DataBind();
    }


    public static void TConexionDetailView(string aSP, DetailsView Detail)
    {
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        Detail.DataSource = aDS.Tables[0].DefaultView;
        Detail.DataBind();
    }
    public static void TConexionDetailView(string aSP, DetailsView Detail, string aParametro)
    {
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro"].Value = aParametro;

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);

        Detail.DataSource = aDS.Tables[0].DefaultView;
        Detail.DataBind();
    }
    public static void TConexionDetailView(string aSP, DetailsView Detail, string aParametro_1, string aParametro_2)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@Parametro_1", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@Parametro_1"].Value = aParametro_1;
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@Parametro_2", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@Parametro_2"].Value = aParametro_2;

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);

        Detail.DataSource = aDS.Tables[0].DefaultView;
        Detail.DataBind();


    }

    public static string  control_operaciones(string pusuario, string poperacion, string P_wh, string P_vitola, string P_capa, string P_liga, int P_cantidad, decimal P_costo)
    {
        string mensaje = "Inicio";
        int minuto = DateTime.Now.Minute;
        string texto_minuto;

        if (minuto < 10)
        {
            texto_minuto = "0" + minuto.ToString();
        }
        else
        {
            texto_minuto = minuto.ToString();
        }

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlCommand CMD = new SqlCommand("INSERT INTO tb_security (login,fecha,hora,evento,wh,vitola,capa,liga,cantidad,costo) VALUES (@Login,@Fecha,@Hora,@Evento,@wh,@vitola,@capa,@liga,@cantidad,@costo)", Conexion);
        CMD.CommandType = CommandType.Text;

        CMD.Parameters.Add(new SqlParameter("@Login", SqlDbType.VarChar, 50));
        CMD.Parameters["@Login"].Value = pusuario;

        CMD.Parameters.Add(new SqlParameter("@Evento", SqlDbType.VarChar, 500));
        CMD.Parameters["@Evento"].Value = poperacion;

        CMD.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.SmallDateTime));
        CMD.Parameters["@Fecha"].Value = DateTime.Now.Date.ToShortDateString();

        CMD.Parameters.Add(new SqlParameter("@Hora", SqlDbType.VarChar, 50));
        CMD.Parameters["@Hora"].Value = DateTime.Now.Hour.ToString() + ":" + texto_minuto;



        CMD.Parameters.Add(new SqlParameter("@wh", SqlDbType.VarChar, 50));
        CMD.Parameters["@wh"].Value = P_wh;

        CMD.Parameters.Add(new SqlParameter("@vitola", SqlDbType.VarChar, 50));
        CMD.Parameters["@vitola"].Value = P_vitola;

        CMD.Parameters.Add(new SqlParameter("@capa", SqlDbType.VarChar, 50));
        CMD.Parameters["@capa"].Value = P_capa;

        CMD.Parameters.Add(new SqlParameter("@liga", SqlDbType.VarChar, 50));
        CMD.Parameters["@liga"].Value = P_liga;

        CMD.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        CMD.Parameters["@cantidad"].Value = P_cantidad;

        CMD.Parameters.Add(new SqlParameter("@costo", SqlDbType.Decimal));
        CMD.Parameters["@costo"].Value = P_costo;


        Conexion.Open();
        try
        {
            CMD.ExecuteNonQuery();
            mensaje = "ok";
        }

        catch (SqlException qlex)
        {
            mensaje = qlex.Message;
        }
        catch (Exception ex)
        {
            mensaje = ex.Message;
        }
        finally
        {
            Conexion.Close();
        }

        return mensaje;

    }

    public static string aviso_security()
    {
        string descrip_ip = "";
        NetworkInterface[] Netinterface = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface lista_ip in Netinterface)
        {
            descrip_ip += lista_ip.GetIPProperties().UnicastAddresses[0].Address.ToString() + "/";

        }
        string mensaje;
        string mensaje_linea_1 = "Se ha producido un intento de acceso no autorizado a la base de datos de Facturas del CECMED.";
        string mensaje_linea_2 = "Notificar a Dirección, Grupo de Informática, y Grupo de Seguridad y Protección del CECMED ";
        StringBuilder parrafo = new StringBuilder();
        parrafo.AppendLine(mensaje_linea_1);
        parrafo.AppendLine(mensaje_linea_2);
        parrafo.AppendLine("Datos:");
        parrafo.AppendLine("IP desde donde se ejecutó: " + descrip_ip);
        parrafo.AppendLine("Hora: " + DateTime.Now.ToShortTimeString());
        parrafo.AppendLine("Fecha: " + DateTime.Now.ToShortDateString());
        parrafo.AppendLine("Este correo se generó de forma automática, por favor no lo conteste.");


        MailMessage correo = new MailMessage();
        correo.From = new MailAddress("soporte@cecmed.sld.cu", "Sistema de Facturas CECMED", System.Text.Encoding.UTF8);
        correo.To.Add("robertico@cecmed.sld.cu");
        correo.Subject = "Alerta de acceso no autorizado a Base de Datos de Facturas del CECMED";
        correo.Body = parrafo.ToString();
        // serverva

        correo.SubjectEncoding = System.Text.Encoding.UTF8;
        correo.BodyEncoding = System.Text.Encoding.UTF8;
        SmtpClient server = new SmtpClient("correo");
        server.Credentials = new System.Net.NetworkCredential("soporte@cecmed.sld.cu", "soporte.");

        try
        {
            server.Send(correo);
            mensaje = "notificado";
        }
        catch (Exception ex)
        {
            mensaje = ex.Message;
        }

        return mensaje;


    }

    public static void Combo(string aSP, string DataText, string DataValue, DropDownList DDL)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        DataSet aDS = new DataSet();

        aSDA.Fill(aDS);
        DDL.DataSource = aDS.Tables[0];
        DDL.DataTextField = DataText;
        DDL.DataValueField = DataValue;
        DDL.DataBind();

    }

    public static void ComboProc(string aSP, string DataText, string DataValue, DropDownList DDL)
    {

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet aDS = new DataSet();

        aSDA.Fill(aDS);
        DDL.DataSource = aDS.Tables[0];
        DDL.DataTextField = DataText;
        DDL.DataValueField = DataValue;
        DDL.DataBind();

    }

   




    public static decimal chekeo_costo(int p_vitola, int p_capa, int p_liga)
    {

        decimal final = 0;
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlConnection conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("SELECT costo_main_ouvre FROM tb_costos WHERE (vitola=@vitola) AND (capa=@capa) AND (liga=@liga)", Conexion);

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = p_vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = p_capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = p_liga;

        Conexion.Open();

        try
        {

            final = decimal.Parse(cmd.ExecuteScalar().ToString());

        }
        catch (SqlException)
        {
            final = 0;
        }

        catch
        {
            final = 0;

        }
        finally
        {
            Conexion.Close();

        }


        return final;

    }


    public static string add_costo(int p_vitola, int p_capa, int p_liga, decimal p_Costo)
    {

        string mensaje="";
        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlConnection conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("INSERT INTO tb_costos (costo_main_ouvre,vitola,capa,liga) VALUES (@costo,@vitola,@capa,@liga)", Conexion);

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = p_vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = p_capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = p_liga;
        cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Decimal));
        cmd.Parameters["@costo"].Value = p_Costo;

        Conexion.Open();

        try
        {

            cmd.ExecuteNonQuery();          

            mensaje="Costo agregado";


        }
        catch (SqlException exp)
        {
            if (exp.Number.ToString() == "2627")
            {
                mensaje = "Costo ya existe";
            }
            else
            {
                mensaje = exp.Number.ToString();
            }
        }

        catch
        {
            mensaje= "Problem";

        }
        finally
        {
            Conexion.Close();

        }


        return mensaje;

    }




    public static string  agregar_p_diaria(string pVitola, string pCapa, string pLiga, string pOperario, string pCantidad, string pFecha/* int fechaR*/)
    {
        string reponse = "";
        int A_Vitola = int.Parse(pVitola);
        int A_Capa = int.Parse(pCapa);
        int A_Liga = int.Parse(pLiga);
        int A_Cantidad = int.Parse(pCantidad);
        
        
        
        string CadConexion;
        CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection conexion = new SqlConnection(CadConexion);        
        SqlCommand cmd = new SqlCommand("SP_insert_p_diaria",conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = A_Vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = A_Capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = A_Liga;        
        cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        cmd.Parameters["@cantidad"].Value = A_Cantidad;

        SqlTransaction trans = null;
      

         try
         {
             conexion.Open();
             trans = conexion.BeginTransaction();
             cmd.Transaction = trans;
             cmd.ExecuteNonQuery();
             trans.Commit();

             string msg_warehouseI = update_entrepot(A_Vitola, A_Capa, A_Liga, A_Cantidad/*, fechaR*/).ToString();

             reponse = "Registo agregado." + msg_warehouseI;


         }
         catch (SqlException sql_p)
         {
             reponse = sql_p.Message;
             trans.Rollback();
         }
         finally
         {
             conexion.Close();
         }



         return reponse;

        //string reponse = "";

        //int A_Vitola = int.Parse(pVitola);
        //int A_Capa = int.Parse(pCapa);
        //int A_Liga = int.Parse(pLiga);
        //int A_Operario = 0;//int.Parse(pOperario);
        //int A_Cantidad = int.Parse(pCantidad);

        //String A_date = DateTime.Now.ToShortDateString();// pFecha;
      
        

        //decimal A_Costo = chekeo_costo(A_Vitola, A_Capa, A_Liga);
        //decimal A_Costo_Total = A_Cantidad * A_Costo;

        //if (A_Costo == 0)
        //{
        //  //  reponse = "*NPU*";
        //}
        //else
        //{
        //    reponse = A_Costo.ToString();


        //    string CadConexion;
        //    CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        //    SqlConnection conexion = new SqlConnection(CadConexion);
        //   // SqlCommand cmd = new SqlCommand("INSERT INTO tb_produccion_diaria (vitola,capa,liga,operario,cantidad,fecha,costo) VALUES (@vitola,@capa,@liga,@operario,@cantidad,@fecha,@costo)", conexion);
        //    SqlCommand cmd = new SqlCommand("SP_insert_p_diaria");
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        //    cmd.Parameters["@vitola"].Value = A_Vitola;
        //    cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        //    cmd.Parameters["@capa"].Value = A_Capa;
        //    cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        //    cmd.Parameters["@liga"].Value = A_Liga;
        //    cmd.Parameters.Add(new SqlParameter("@operario", SqlDbType.Int));
        //    cmd.Parameters["@operario"].Value = A_Operario;
        //    cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        //    cmd.Parameters["@cantidad"].Value = A_Cantidad;
        //    cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.VarChar,20));
        //    cmd.Parameters["@fecha"].Value = A_date.ToString();/* http://stackoverflow.com/questions/17418258/datetime-format-to-sql-format-using-c-sharp */
        //    cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Decimal));
        //    cmd.Parameters["@costo"].Value = A_Costo_Total;

           

        //    SqlTransaction trans;
        //    conexion.Open();
        //    trans = conexion.BeginTransaction();
        //    cmd.Transaction = trans;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        trans.Commit();

        //        string msg_warehouseI = update_entrepot(A_Vitola, A_Capa, A_Liga, A_Cantidad,fechaR).ToString();

        //        reponse = "Registo agregado." + msg_warehouseI;
            

        //    }
        //    catch (SqlException sql_p)
        //    {
        //        reponse = sql_p.Message;
        //        trans.Rollback();
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }
        //}

        //return reponse;

    }

    public static string update_entrepot(int pVitola, int pCapa, int pLiga, int pCantidad/*, int fechaR*/)
    {
        string mensaje;
        string CadConexion;
        CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("INSERT INTO tb_entrepot (vitola,capa,liga,cantidad,destino_origen) VALUES (@vitola,@capa,@liga,@cantidad,0)", conexion);

        int A_Vitola = pVitola;
        int A_Capa = pCapa;
        int A_Liga = pLiga;
        int A_Cantidad = pCantidad;

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = A_Vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = A_Capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = A_Liga;
        cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        cmd.Parameters["@cantidad"].Value = A_Cantidad;
       /* cmd.Parameters.Add(new SqlParameter("@fechaR", SqlDbType.Int));
        cmd.Parameters["@fechaR"].Value = fechaR;*/

        SqlTransaction trans;
        conexion.Open();
        trans = conexion.BeginTransaction();
        cmd.Transaction = trans;

        try
        {

            cmd.ExecuteNonQuery();
            trans.Commit();
            mensaje= "Warehouse actualizado con nuevo producto.";

        }
        catch (SqlException msgwarehouse)
        {
            trans.Rollback();            

            if (msgwarehouse.Number.ToString() == "2627")
            {
                string ow = update_entrepot_overwrite(A_Vitola, A_Capa, A_Liga, A_Cantidad/*, fechaR*/);
                if (ow == "Warehouse actualizado.")
                {
                    mensaje = "Warehouse actualizado.";
                }
                else
                {
                    mensaje = "Problema  SQL escribiendo: "+ow;
                }
            }
            else
            {

                mensaje = "Problema diferente a 2627 SQL escribiendo:"+msgwarehouse.Message;

            }

        }
        catch
        {
            trans.Rollback();
            return "Big Problem out SQL";
        }

        finally
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        return mensaje;
    
    }

    public static string update_entrepot_overwrite(int pVitola, int pCapa, int pLiga, int pCantidad/*, int fechaR*/)
    {
        string CadConexion;
        CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection conexion = new SqlConnection(CadConexion);
        SqlCommand cmd = new SqlCommand("UPDATE tb_entrepot SET cantidad=cantidad+@cantidad WHERE vitola=@vitola AND capa=@capa AND liga=@liga", conexion);

        int A_Vitola = pVitola;
        int A_Capa = pCapa;
        int A_Liga = pLiga;
        int A_Cantidad = pCantidad;

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = A_Vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = A_Capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = A_Liga;
        cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        cmd.Parameters["@cantidad"].Value = A_Cantidad;
        //cmd.Parameters.Add(new SqlParameter("@fechaR", SqlDbType.Int));
        //cmd.Parameters["@fechaR"].Value = fechaR;

        SqlTransaction trans;
        conexion.Open();
        trans = conexion.BeginTransaction();
        cmd.Transaction = trans;

        try
        {

            cmd.ExecuteNonQuery();
            trans.Commit();
            return "Warehouse actualizado.";

        }
        catch (SqlException msgwarehouse)
        {
            trans.Rollback();
            return msgwarehouse.Message;
        }
        catch
        {
            trans.Rollback();
            return "Big";
        }

        finally
        {
            conexion.Close();
        }


    }


    public static string delete_prod_daily (GridView GView,GridViewDeleteEventArgs e, int P_Col_index,string consulta,string P_Msg_Positivo)
    {
        string reponse="";
        int index = e.RowIndex;
        GridViewRow row = GView.Rows[index];

        int ident = int.Parse(row.Cells[P_Col_index].Text.ToString());
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand(consulta, conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = ident;


        conexion.Open();
        try
        {            
            cmd.ExecuteNonQuery();
            reponse = P_Msg_Positivo; 

        }

        catch (Exception er)
        {
            reponse = er.Message; ;
        }
        finally
        {
            conexion.Close();
        }

        return reponse;
    }


    public static string moins_entrepot_prod_daily(GridView GView, GridViewDeleteEventArgs e, int P_Col_index,string P_Msg_Positivo)
    {
        string reponse = "";
        int index = e.RowIndex;
        GridViewRow row = GView.Rows[index];

        int ident = int.Parse(row.Cells[P_Col_index].Text.ToString());

  
     
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("UPDATE tb_entrepot SET cantidad=(cantidad-@cantidad) WHERE vitola=@vitola AND capa=@capa AND liga=@liga AND cantidad>@cantidad", conexion);

        int vitola = Vitola_Pro_Daily(GView, e, P_Col_index);
        int capa = Capa_Pro_Daily(GView, e, P_Col_index);
        int liga = Liga_Pro_Daily(GView, e, P_Col_index);
        int cantidad = Cantidad_Pro_Daily(GView, e, P_Col_index);

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = vitola;

        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = capa;

        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = liga;

        cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        cmd.Parameters["@cantidad"].Value = cantidad;

        
      
      
        conexion.Open();
        try
        {
          int col_afec=cmd.ExecuteNonQuery();

          if (col_afec != 0)
          {
              reponse = P_Msg_Positivo;
          }
          else
          {
              reponse = "Al realizar esta acción el WareHouse tambien se actualiza. Actualmente con este producto existe una diferencia, entre lo que se quiere eliminar de la produccion diaria y el existente en el Warehouse, esta situación es atipica por lo que debe contactar con el desarrollador de este software para buscar una solución";
          }

        }

        catch (Exception er)
        {
            reponse = er.Message; ;
        }
        finally
        {
            conexion.Close();
        }

        return reponse;
    }


    public static int Vitola_Pro_Daily(GridView GView, GridViewDeleteEventArgs e, int P_Col_index)
    {

        int reponse;
        int index = e.RowIndex;
        GridViewRow row = GView.Rows[index];

        int ident = int.Parse(row.Cells[P_Col_index].Text.ToString());
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 vitola FROM tb_produccion_diaria WHERE id_registro= @id", conexion);

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = ident;


        conexion.Open();
        try
        {            
            reponse= (int)cmd.ExecuteScalar();           

        }

        catch (Exception )
        {
            reponse = 0;
        }
        finally
        {
            conexion.Close();
        }

        return reponse;
       
    }

    public static int Capa_Pro_Daily(GridView GView, GridViewDeleteEventArgs e, int P_Col_index)
    {

        int reponse;
        int index = e.RowIndex;
        GridViewRow row = GView.Rows[index];

        int ident = int.Parse(row.Cells[P_Col_index].Text.ToString());
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 capa FROM tb_produccion_diaria WHERE id_registro= @id", conexion);

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = ident;


        conexion.Open();
        try
        {
            reponse = (int)cmd.ExecuteScalar();

        }

        catch (Exception )
        {
            reponse = 0;
        }
        finally
        {
            conexion.Close();
        }

        return reponse;

    }

    public static int Liga_Pro_Daily(GridView GView, GridViewDeleteEventArgs e, int P_Col_index)
    {

        int reponse;
        int index = e.RowIndex;
        GridViewRow row = GView.Rows[index];

        int ident = int.Parse(row.Cells[P_Col_index].Text.ToString());
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 liga FROM tb_produccion_diaria WHERE id_registro= @id", conexion);

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = ident;


        conexion.Open();
        try
        {
            reponse = (int)cmd.ExecuteScalar();

        }

        catch (Exception )
        {
            reponse = 0;
        }
        finally
        {
            conexion.Close();
        }

        return reponse;

    }


    public static int Cantidad_Pro_Daily(GridView GView, GridViewDeleteEventArgs e, int P_Col_index)
    {

        int reponse;
        int index = e.RowIndex;
        GridViewRow row = GView.Rows[index];

        int ident = int.Parse(row.Cells[P_Col_index].Text.ToString());
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 cantidad FROM tb_produccion_diaria WHERE id_registro= @id", conexion);

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = ident;


        conexion.Open();
        try
        {
            reponse = (int)cmd.ExecuteScalar();

        }

        catch (Exception )
        {
            reponse = 0;
        }
        finally
        {
            conexion.Close();
        }

        return reponse;

    }


   

    public static void change_state_multiple(int id,DateTime date)
    {
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());

        SqlCommand cmd = new SqlCommand("UPDATE tb_entrepot_jamaica_venta SET date_paid=@fecha, estado='Paid' WHERE id=@id", conexion);

        cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.SmallDateTime));
        cmd.Parameters["@fecha"].Value = date.ToShortDateString();
        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = id;

        conexion.Open();

        try
        {

            cmd.ExecuteNonQuery();

        }
        catch
        {
        ///
        }
        finally
        {
            conexion.Close();
        }
    }


    public static string change_state_parciel(DateTime P_invoice, DateTime P_date, Decimal P_amount, int p_id)
    {
        string response;

        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlConnection conexion2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());

        SqlCommand cmd = new SqlCommand("INSERT INTO tb_entrepot_jamaica_venta_parcial (invoice,fecha,amount,id_registro)VALUES(@invoice,@fecha,@amount,@id)", conexion);
        SqlCommand cmd_parcial = new SqlCommand("UPDATE tb_entrepot_jamaica_venta SET parcial='YES' WHERE id=@id", conexion2);


        cmd_parcial.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd_parcial.Parameters["@id"].Value = p_id;

        cmd.Parameters.Add(new SqlParameter("@invoice", SqlDbType.Date));
        cmd.Parameters["@invoice"].Value = P_invoice;

        cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
        cmd.Parameters["@fecha"].Value = P_date;

        cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.Decimal));
        cmd.Parameters["@amount"].Value = P_amount;

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        cmd.Parameters["@id"].Value = p_id;


       

        conexion.Open();

        try
        {

            cmd.ExecuteNonQuery();
            response = "ok";
            conexion2.Open();
            cmd_parcial.ExecuteNonQuery();
            conexion2.Close();


        }
        catch(SqlException ex)
        {
            response = ex.Message;
        }
        finally
        {
            conexion.Close();
        }

        return response;
    }


    public static void Exportar_PDF(HttpResponse Response, string aSP, string aParametro_1, CrystalReportViewer CRViewer, string Path)
    {
        try
        {
            string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
            SqlConnection Conexion = new SqlConnection(CadConexion);

            SqlDataAdapter aSDA = new SqlDataAdapter(aSP, Conexion);
            aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            aSDA.SelectCommand.Parameters.Add(new SqlParameter("@invoice", SqlDbType.VarChar, 20));
            aSDA.SelectCommand.Parameters["@invoice"].Value = aParametro_1;

            DataSet DataSet = new DataSet();
            aSDA.Fill(DataSet, "DT_Invoice");



            ReportDocument RPT_Document = new ReportDocument();

            RPT_Document.Load(Path + "Invoice.rpt");
            // RPT_Document.Load(Server.MapPath("~/Invoice.rpt");

            RPT_Document.SetDataSource(DataSet.Tables["DT_Invoice"]);


            CRViewer.ReportSource = RPT_Document;
            RPT_Document.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Invoice");
            RPT_Document.Dispose();

        }

        catch (ExecutionEngineException ex)
        { 
        
       
        
        }
    

    }
}


