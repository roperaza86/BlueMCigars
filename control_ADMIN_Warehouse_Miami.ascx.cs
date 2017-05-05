using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;



public partial class control_ADMIN_Warehouse_Miami : System.Web.UI.UserControl
{

    
    

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)///no es la primera vez
        {

            class_rpr.ComboProc("SP_see_vitola", "vitola", "id_vitola", DropDownList5);
            class_rpr.ComboProc("SP_see_capa", "capa", "id_capa", DropDownList2);
            class_rpr.ComboProc("SP_see_liga", "liga", "id_liga", DropDownList3);
            class_rpr.Combo("SP_see_InvoiceMiamiHistory", "invoice", "invoice", DropDownList6);

            //    ///////////////////////////// drop de filtrar historial para admin
            class_rpr.ComboProc("SP_see_vitola", "vitola", "vitola", ddl_Vitola);
            class_rpr.ComboProc("SP_see_capa", "capa", "capa", ddl_Capa);
            class_rpr.ComboProc("SP_see_liga", "liga", "liga", ddl_Liga);
            class_rpr.ComboProc("SP_see_entry", "entry", "entry2", ddl_Entry);

            class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);

            class_rpr.TConexionListdProc("SP_last_invoice_miami", ListBox1);


            //class_rpr.TConexionGrid("SELECT TOP 5 tb_vitola.vitola,tb_capa.capa,tb_liga.liga,cantidad FROM (((tb_entrepot_miami LEFT JOIN tb_vitola ON tb_entrepot_miami.vitola = tb_vitola.id_vitola) LEFT JOIN tb_capa ON tb_entrepot_miami.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_entrepot_miami.liga=tb_liga.id_liga) GROUP BY tb_vitola.vitola,tb_capa.capa,tb_liga.liga,cantidad ORDER BY cantidad DESC", GridView3);
            //class_rpr.TConexionGrid("SELECT TOP 5 tb_vitola.vitola,tb_capa.capa,tb_liga.liga,cantidad FROM (((tb_entrepot_miami LEFT JOIN tb_vitola ON tb_entrepot_miami.vitola = tb_vitola.id_vitola) LEFT JOIN tb_capa ON tb_entrepot_miami.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_entrepot_miami.liga=tb_liga.id_liga) GROUP BY tb_vitola.vitola,tb_capa.capa,tb_liga.liga,cantidad ORDER BY cantidad", GridView4);

                
         

            

        }////if

            
        Button1.Enabled = false;
    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {

        int cantidad = int.Parse(Label7.Text.ToString());
        int pedido = int.Parse(TextBox1.Text.ToString());
        string invoice = TextBox3.Text.ToString();
        if (cantidad >= pedido)
        {

            int restante = cantidad - pedido;
            SqlTransaction trans = null;



            SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
            SqlCommand cmd_Gestion = new SqlCommand("SP_newInvoice_Miami", conexion);
            cmd_Gestion.CommandType = CommandType.StoredProcedure;




            cmd_Gestion.Parameters.Add(new SqlParameter("@vitola", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@vitola"].Value = Label1.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@capa", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@capa"].Value = Label2.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@liga", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@liga"].Value = Label3.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
            cmd_Gestion.Parameters["@cantidad"].Value = pedido; 

            cmd_Gestion.Parameters.Add(new SqlParameter("@invoice", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@invoice"].Value = TextBox3.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
            cmd_Gestion.Parameters["@fecha"].Value = DateTime.Now.ToShortDateString();

            cmd_Gestion.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@login"].Value = Session["login"].ToString();

            cmd_Gestion.Parameters.Add(new SqlParameter("@entry", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@entry"].Value = Label9.Text.ToString();

            cmd_Gestion.Parameters.Add(new SqlParameter("@price", SqlDbType.Money, 18));
            cmd_Gestion.Parameters["@price"].Value = TextBox5.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@restante", SqlDbType.Int));
            cmd_Gestion.Parameters["@restante"].Value = restante;

            cmd_Gestion.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            cmd_Gestion.Parameters["@id"].Value = int.Parse(Label5.Text.ToString());

            try
            {

                conexion.Open();
                trans = conexion.BeginTransaction();
                cmd_Gestion.Transaction = trans;
                cmd_Gestion.ExecuteNonQuery();
                trans.Commit();
                Label4.Text = "Invoice gestionado con exito";
                TextBox1.Text = "";
                TextBox3.Text = "";
                TextBox5.Text = "";


                class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
                class_rpr.TConexionGridProcHistorialMiami("SP_miami_historial_producto", GridView2, Label1.Text, Label2.Text, Label3.Text, Label9.Text);
                //class_rpr.Combo("SELECT id_vitola,vitola FROM tb_vitola  WHERE habano='no' ORDER BY vitola", "vitola", "vitola", ddl_Vitola);
                //class_rpr.Combo("SELECT id_capa,capa FROM tb_capa   WHERE habano='no' ORDER BY capa", "capa", "capa", ddl_Capa);
                //class_rpr.Combo("SELECT id_liga,liga FROM tb_liga   WHERE habano='no' ORDER BY liga", "liga", "liga", ddl_Liga);
                class_rpr.ComboProc("SP_see_entry", "entry", "entry2", ddl_Entry);
                class_rpr.TConexionListdProc("SP_last_invoice_miami", ListBox1); 

                
                

            }

            catch (SqlException ex)
            {

                trans.Rollback();
                Label4.Text = ex.Message;
                throw ex;
            }

            

            finally
            {
                   
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();    
                }
                 
             


            }


        }

        else {

            Label4.Text = "Su pedido sobrepasa la disponibilidad actual";
        
        }

    
    }


    public void report(string invoice)
    {
        class_rpr.Exportar_PDF(Page.Response, "SP_see_InvoiceMiamiHistory_4Invoice", invoice, CrystalReportViewer1, Server.MapPath("~/"));
        // Label4.Text = Server.MapPath("/"); 
      
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1); 
        int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];
        row.ControlStyle.BackColor = System.Drawing.Color.BlueViolet;
        Label1.Text = row.Cells[2].Text.ToString();
        Label2.Text = row.Cells[3].Text.ToString();
        Label3.Text = row.Cells[4].Text.ToString();
        Label5.Text = row.Cells[1].Text.ToString();
        Label7.Text = row.Cells[5].Text.ToString();
        Label9.Text = row.Cells[7].Text.ToString();
       
        Button1.Enabled = true;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SELECT id_vitola,vitola FROM tb_vitola", "vitola", "id_vitola", DropDownList5);
        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        
        class_rpr.Combo("SELECT id_capa,capa FROM tb_capa", "capa", "id_capa", DropDownList2);
        
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        
        class_rpr.Combo("SELECT id_liga,liga FROM tb_liga", "liga", "id_liga", DropDownList3);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        string sVitola = DropDownList5.SelectedItem.Text;
        string sCapa = DropDownList2.SelectedItem.Text;
        string sLiga = DropDownList3.SelectedItem.Text;
        string sEntry = TextBox4.Text;



        int p_Vitola = int.Parse(DropDownList5.SelectedValue.ToString());
        int p_Capa = int.Parse(DropDownList2.SelectedValue.ToString());
        int p_Liga = int.Parse(DropDownList3.SelectedValue.ToString());
        string entry = TextBox4.Text;
        String date = txtDateEntree.Text;
       
        int cantidad = int.Parse(TextBox2.Text.ToString());
        //string fecha = Calendar1.SelectedDate.ToShortDateString() ;

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlCommand cmd = new SqlCommand("SP_insert_Miami", Conexion);
        cmd.CommandType = CommandType.StoredProcedure; 
      

        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = p_Vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = p_Capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = p_Liga;
        cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        cmd.Parameters["@cantidad"].Value = cantidad;
        cmd.Parameters.Add(new SqlParameter("@entry", SqlDbType.VarChar,50));
        cmd.Parameters["@entry"].Value = entry;
        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar,20));
        cmd.Parameters["@date"].Value = date;      

        Conexion.Open();

        SqlTransaction trans;
        trans=Conexion.BeginTransaction();

        cmd.Transaction = trans;


        try
        {      
            
            
                cmd.ExecuteNonQuery();
                trans.Commit();  
                Label8.Text = "El registro fue agregado correctamente."; 
                string reporte = "En el WH-MIAMI agregó Vitola:" + DropDownList5.SelectedItem.ToString() + " Capa:" + DropDownList2.SelectedItem.ToString() + " Liga:" + DropDownList3.SelectedItem.ToString() + "cantidad:" + TextBox2.Text.ToString(); ;
                class_rpr.control_operaciones(Session["login"].ToString(), "Con el entry:"+sEntry+". Agrego un nuevo producto a:", "Miami", sVitola, sCapa, sLiga, cantidad,0);
                
                TextBox2.Text = "";
                class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
                Label8.Text = date; 
              
                
                
            
        }

        catch (SqlException ex )   
        {

            trans.Rollback();

            if (ex.Number == 2627)
            {
                SqlConnection Conexion_auxiliar2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
                SqlCommand cmd_GestionPb = new SqlCommand("SP_update_Miami", Conexion_auxiliar2);
                cmd_GestionPb.CommandType = CommandType.StoredProcedure;



                cmd_GestionPb.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                cmd_GestionPb.Parameters["@vitola"].Value = p_Vitola;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                cmd_GestionPb.Parameters["@capa"].Value = p_Capa;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                cmd_GestionPb.Parameters["@liga"].Value = p_Liga;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                cmd_GestionPb.Parameters["@cantidad"].Value = cantidad;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@entry", SqlDbType.VarChar, 50));
                cmd_GestionPb.Parameters["@entry"].Value = entry;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar, 20));
                cmd_GestionPb.Parameters["@date"].Value = date;    


                Conexion_auxiliar2.Open();

                SqlTransaction trans2;
                trans2 = Conexion_auxiliar2.BeginTransaction();

                cmd_GestionPb.Transaction = trans2;

                try
                {
                    cmd_GestionPb.ExecuteNonQuery();
                    trans2.Commit();
                    Label5.Text = "Se agrego una cantidad a un producto existente";
                    string reporte = "En el WH-MIAMI adiciono a Vitola:" + DropDownList5.SelectedItem.ToString() + " Capa:" + DropDownList2.SelectedItem.ToString() + " Liga:" + DropDownList3.SelectedItem.ToString() + " la cantidad de:" + TextBox2.Text.ToString();
                    class_rpr.control_operaciones(Session["login"].ToString(), "Con el entry:" + sEntry + ". agrego una cantidad a un producto existente en:", "Miami", sVitola, sCapa, sLiga, cantidad, 0);
                    TextBox2.Text = "";
                   
                    Label8.Text = "Se agrego una cantidad a un producto existente";
                    class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
                }
                catch (Exception er)
                {
                    Label8.Text = "Problemas adicionando " + er.Message;
                    trans2.Rollback();
                   

                }




                finally
                {
                    Conexion_auxiliar2.Close();

                }


            }

            else
            {
              //  trans.Rollback();
                Label8.Text = "Problemas adicionando ";
            }
            
           
        }
        catch (Exception exT)
        {

            Label5.Text = exT.Message;
            trans.Rollback();
           

        }

        finally
        {
            Conexion.Close();
            Label2.Text = "";
        }
    

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView1.PageIndex = newPageIndex;
        class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView2.PageIndex = newPageIndex;


        String vitola = ddl_Vitola.SelectedValue;
        String capa = ddl_Capa.SelectedValue;
        String liga = ddl_Liga.SelectedValue;
        String entry = ddl_Entry.SelectedValue;
        class_rpr.TConexionGridProcHistorialMiami("SP_miami_historial_producto", GridView2, vitola, capa, liga, entry);
        

    }
   
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        ///mostrar resultados de filtrar la busqueda en historial
        ///
        String vitola = ddl_Vitola.SelectedValue;
        String capa = ddl_Capa.SelectedValue;
        String liga = ddl_Liga.SelectedValue;
        String entry = ddl_Entry.SelectedValue;
        class_rpr.TConexionGridProcHistorialMiami("SP_miami_historial_producto", GridView2, vitola, capa, liga, entry);
        Label4.Text = vitola;

        

       
       
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {

       
        String entry = txt_historialEntry.Text;
        class_rpr.TConexionGridProcHistorialMiami("SP_miami_historial_entry", GridView5, entry);
       

    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        class_rpr.TConexionGridProc("SP_miami_statisique1",GridView6);

    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;

        }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {



        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter("SP_see_InvoiceMiamiHistory_4Invoice", Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@invoice", SqlDbType.VarChar, 20));
        aSDA.SelectCommand.Parameters["@invoice"].Value = DropDownList6.SelectedValue.ToString();

        DataSet aDS = new DataSet();
        aSDA.Fill(aDS);
        GridView8.DataSource = aDS.Tables[0].DefaultView;
        GridView8.DataBind();



        //DataTable ResultsTable = new DataTable();



        //try
        //{

        //    aSDA.Fill(ResultsTable);
        //}

        //catch (Exception ex)
        //{
        //    Response.Write(ex.ToString());
        //}




        //ReportViewer1.Visible = true;
        //ReportViewer1.LocalReport.ReportPath = "Report2.rdlc" ;
        //ReportViewer1.LocalReport.DataSources.Clear();
        //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetMiami", ResultsTable));

        

        
         

    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Dao_Miami daoMiami = new Dao_Miami();

        daoMiami.getDataGridView(GridView1,1,8);
        Label10.Text = daoMiami.deleteDataIninventario("SP_delete_entrepot_Miami").ToString()+" eliminado(s)";
        class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {

       

        Dao_Miami daoMiami = new Dao_Miami();
        daoMiami.getDataGridView(GridView2, 9, 10);
        Label11.Text = daoMiami.getDataIninventario("SP_delete_entrepot_Miami_historial").ToString();

        String vitola = ddl_Vitola.SelectedValue;
        String capa = ddl_Capa.SelectedValue;
        String liga = ddl_Liga.SelectedValue;
        String entry = ddl_Entry.SelectedValue;
        class_rpr.TConexionGridProcHistorialMiami("SP_miami_historial_producto", GridView2, vitola, capa, liga, entry);
        class_rpr.TConexionListdProc("SP_last_invoice_miami", ListBox1); 

       
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {

        Dao_Miami daoMiami = new Dao_Miami();
        daoMiami.getDataGridView(GridView2, 9, 10);

        Label11.Text = daoMiami.getDataIninventario("SP_See_fromHistorial_4id").ToString() + "Borrados del historial y reintegrados al inventario";
        Label11.Text = daoMiami.fromHistoryToInventary("SP_update_Miami_from_historial");
        
        daoMiami.deleteDataIninventario("SP_delete_entrepot_Miami_historial");

        String vitola = ddl_Vitola.SelectedValue;
        String capa = ddl_Capa.SelectedValue;
        String liga = ddl_Liga.SelectedValue;
        String entry = ddl_Entry.SelectedValue;
        class_rpr.TConexionGridProcHistorialMiami("SP_miami_historial_producto", GridView2, vitola, capa, liga, entry);
        class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
        class_rpr.TConexionListdProc("SP_last_invoice_miami", ListBox1); 


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string invoice =DropDownList6.SelectedValue.ToString();
        class_rpr.Exportar_PDF(Page.Response, "SP_see_InvoiceMiamiHistory_4Invoice", invoice, CrystalReportViewer1, Server.MapPath("/depot_nicaragua"));
    }
    protected void ImageButton4_Click1(object sender, ImageClickEventArgs e)
    {
        class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
    }
    protected void ImageButton4_Click2(object sender, ImageClickEventArgs e)
    {
        class_rpr.TConexionGridProc("SP_see_entrepot_Miami", GridView1);
    }
   
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        this.report(ListBox1.SelectedValue); 
    }
    
}