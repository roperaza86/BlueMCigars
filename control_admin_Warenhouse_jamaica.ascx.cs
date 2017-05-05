using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class control_admin_Warenhouse_jamaica : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            class_rpr.Combo("SELECT id_vitola,vitola FROM tb_vitola ORDER BY vitola", "vitola", "id_vitola", DropDownList5);
            class_rpr.Combo("SELECT id_capa,capa FROM tb_capa ORDER BY capa", "capa", "id_capa", DropDownList2);
            class_rpr.Combo("SELECT id_liga,liga FROM tb_liga ORDER BY liga", "liga", "id_liga", DropDownList3);
            class_rpr.Combo("SELECT id_client,client FROM tb_entrepot_jamaica_cliente ORDER BY client", "client", "id_client", DropDownList8);
            class_rpr.TConexionGrid("SELECT id_gestion_jamaica,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,cantidad FROM (((tb_entrepot_jamaica LEFT JOIN tb_vitola ON tb_entrepot_jamaica.vitola = tb_vitola.id_vitola) LEFT JOIN tb_capa ON tb_entrepot_jamaica.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_entrepot_jamaica.liga=tb_liga.id_liga)  GROUP BY id_gestion_jamaica,tb_entrepot_jamaica.Vitola,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,Cantidad ORDER BY tb_vitola.Vitola,tb_capa.Capa,tb_liga.Liga ", GridView1);
            Label8.Text = "";
            class_rpr.TConexionGrid("SELECT vitola,capa,liga,cantidad,tb_entrepot_jamaica_venta.invoice,tb_entrepot_jamaica_venta.fecha,login,importe,estado,client,vendedor,id,date_paid,tb_entrepot_jamaica_venta_parcial.amount AS parcial FROM tb_entrepot_jamaica_venta LEFT JOIN tb_entrepot_jamaica_venta_parcial ON tb_entrepot_jamaica_venta.id=tb_entrepot_jamaica_venta_parcial.id_registro ORDER BY id DESC", GridView2);
            Button1.Enabled = false;
            BindGrid();
        }
        
        
        Label_Pagado_Comprueba();
    }

    public void BindGrid()
    {
        class_rpr.TConexionGrid("SELECT id_gestion_jamaica,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,cantidad FROM (((tb_entrepot_jamaica LEFT JOIN tb_vitola ON tb_entrepot_jamaica.vitola = tb_vitola.id_vitola) LEFT JOIN tb_capa ON tb_entrepot_jamaica.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_entrepot_jamaica.liga=tb_liga.id_liga)  GROUP BY id_gestion_jamaica,tb_entrepot_jamaica.Vitola,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,Cantidad,tb_vitola.Vitola,tb_capa.Capa,tb_liga.Liga ORDER BY tb_vitola.Vitola,tb_capa.Capa,tb_liga.Liga", GridView1);
        class_rpr.TConexionGrid("SELECT vitola,capa,liga,cantidad,tb_entrepot_jamaica_venta.invoice,tb_entrepot_jamaica_venta.fecha,login,importe,estado,client,vendedor,id,date_paid,tb_entrepot_jamaica_venta_parcial.amount AS parcial FROM tb_entrepot_jamaica_venta LEFT JOIN tb_entrepot_jamaica_venta_parcial ON tb_entrepot_jamaica_venta.id=tb_entrepot_jamaica_venta_parcial.id_registro  ORDER BY id DESC", GridView2);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int cantidad = int.Parse(Label7.Text.ToString());
        int pedido = int.Parse(TextBox1.Text.ToString());

        if (cantidad >= pedido)
        {

            SqlConnection conexion_aux = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
            SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
            SqlCommand cmd_Gestion = new SqlCommand("INSERT INTO tb_entrepot_jamaica_venta (vitola,capa,liga,cantidad,invoice,fecha,login,importe,estado,client,vendedor)values(@vitola,@capa,@liga,@cantidad,@invoice,@fecha,@login,@fee,@payment,@client,@vendedor) ", conexion);


            cmd_Gestion.Parameters.Add(new SqlParameter("@vitola", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@vitola"].Value = Label1.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@capa", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@capa"].Value = Label2.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@liga", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@liga"].Value = Label3.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
            cmd_Gestion.Parameters["@cantidad"].Value = TextBox1.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@invoice", SqlDbType.Date));
            cmd_Gestion.Parameters["@invoice"].Value = Calendar3.SelectedDate;

            cmd_Gestion.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
            cmd_Gestion.Parameters["@fecha"].Value = DateTime.Now.ToShortDateString();

            cmd_Gestion.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@login"].Value = Session["login"].ToString();

            cmd_Gestion.Parameters.Add(new SqlParameter("@fee", SqlDbType.Decimal));
            cmd_Gestion.Parameters["@fee"].Value = Decimal.Parse(TextBox4.Text);

            cmd_Gestion.Parameters.Add(new SqlParameter("@payment", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@payment"].Value = DropDownList6.SelectedItem.ToString();

            cmd_Gestion.Parameters.Add(new SqlParameter("@client", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@client"].Value = DropDownList8.SelectedItem.Text;

            cmd_Gestion.Parameters.Add(new SqlParameter("@vendedor", SqlDbType.VarChar, 50));
            cmd_Gestion.Parameters["@vendedor"].Value = TextBox6.Text;




            conexion.Open();
            SqlTransaction trans_1;
            
            trans_1 = conexion.BeginTransaction();
            
            cmd_Gestion.Transaction = trans_1;

            try
            {

                cmd_Gestion.ExecuteNonQuery();
                class_rpr.control_operaciones(Session["login"].ToString(), "Creo un invoice:"+Calendar3.SelectedDate.ToShortDateString(), "Jamaica", Label1.Text, Label2.Text, Label3.Text, int.Parse(TextBox1.Text), decimal.Parse(TextBox4.Text));
                Label4.Text = "Invoice gestionado con exito";
                int restante = cantidad - pedido;
                SqlCommand cmd_Gestion_Act = new SqlCommand("UPDATE tb_entrepot_jamaica SET cantidad=@restante WHERE id_gestion_jamaica=@id", conexion);

                cmd_Gestion_Act.Parameters.Add(new SqlParameter("@restante", SqlDbType.Int));
                cmd_Gestion_Act.Parameters["@restante"].Value = restante;

                cmd_Gestion_Act.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd_Gestion_Act.Parameters["@id"].Value = int.Parse(Label5.Text.ToString());

                cmd_Gestion_Act.Transaction = trans_1;

                try
                {
                    cmd_Gestion_Act.ExecuteNonQuery();
                    trans_1.Commit();
                    TextBox1.Text = "";
                    //TextBox3.Text = "";
                }
                catch (Exception ex)
                {
                    Label4.Text = ex.Message;//"Problemas rebajando entrada";
                    trans_1.Rollback();
                }


            }

            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Label4.Text = ex.Message;
                }
                else
                {
                    Label4.Text = ex.Message;
                }

                trans_1.Rollback();

            }
            catch (Exception eg)
            {
                Label4.Text = eg.Message;
                trans_1.Rollback();

            }

            finally
            {
                Button1.Enabled = false;
                conexion.Close();
                BindGrid();

            }

        }

        else
        {
            Label4.Text = "Su pedido sobrepasa la disponibilidad actual";

        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];
        string id_registro = row.Cells[2].Text.ToString();

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlCommand cmd = new SqlCommand("DELETE FROM tb_entrepot_jamaica WHERE id_gestion_jamaica=@id_gestion", Conexion);


        cmd.Parameters.Add(new SqlParameter("@id_gestion", SqlDbType.Int));
        cmd.Parameters["@id_gestion"].Value = id_registro;


        Conexion.Open();

        try
        {
            cmd.ExecuteNonQuery();
            Label8.Text = "Producto eliminado";
            BindGrid();
        }
        catch (SqlException ex)
        {

            Label8.Text = ex.Message;
        }
        catch
        {
            Label8.Text = "error desconocido";

        }
        finally
        {
            Conexion.Close();
        }



    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SELECT id_vitola,vitola FROM tb_vitola ORDER BY vitola", "vitola", "id_vitola", DropDownList5);

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

        class_rpr.Combo("SELECT id_capa,capa FROM tb_capa  ORDER BY capa", "capa", "id_capa", DropDownList2);

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        class_rpr.Combo("SP_see_liga", "liga", "id_liga", DropDownList3);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        int p_Vitola = int.Parse(DropDownList5.SelectedValue.ToString());
        int p_Capa = int.Parse(DropDownList2.SelectedValue.ToString());
        int p_Liga = int.Parse(DropDownList3.SelectedValue.ToString());

        int cantidad = int.Parse(TextBox2.Text.ToString());
        //string fecha = Calendar1.SelectedDate.ToShortDateString();

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlCommand cmd = new SqlCommand("INSERT INTO tb_entrepot_jamaica (vitola,capa,liga,cantidad) VALUES (@vitola,@capa,@liga,@cantidad)", Conexion);


        cmd.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
        cmd.Parameters["@vitola"].Value = p_Vitola;
        cmd.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
        cmd.Parameters["@capa"].Value = p_Capa;
        cmd.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
        cmd.Parameters["@liga"].Value = p_Liga;
        cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
        cmd.Parameters["@cantidad"].Value = cantidad;

        Conexion.Open();

        SqlTransaction trans;
        trans = Conexion.BeginTransaction();

        cmd.Transaction = trans;


        try
        {


            cmd.ExecuteNonQuery();
            trans.Commit();
            Label8.Text = "The record was successfully added.";

            class_rpr.control_operaciones(Session["login"].ToString(), "The record was successfully added.", "Jamaica", DropDownList5.SelectedItem.ToString(), DropDownList2.SelectedItem.ToString(), DropDownList3.SelectedItem.ToString(), int.Parse(TextBox2.Text.ToString()), 0);

            TextBox2.Text = "";
            BindGrid();


        }

        catch (SqlException ex)
        {

            trans.Rollback();

            if (ex.Number == 2627)
            {
                SqlConnection Conexion_auxiliar2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
                SqlCommand cmd_GestionPb = new SqlCommand("UPDATE tb_entrepot_jamaica SET cantidad=(cantidad+@cantidad) WHERE vitola=@vitola AND  capa=@capa AND liga=@liga", Conexion_auxiliar2);



                cmd_GestionPb.Parameters.Add(new SqlParameter("@vitola", SqlDbType.Int));
                cmd_GestionPb.Parameters["@vitola"].Value = p_Vitola;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
                cmd_GestionPb.Parameters["@capa"].Value = p_Capa;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
                cmd_GestionPb.Parameters["@liga"].Value = p_Liga;

                cmd_GestionPb.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                cmd_GestionPb.Parameters["@cantidad"].Value = cantidad;


                Conexion_auxiliar2.Open();

                SqlTransaction trans2;
                trans2 = Conexion_auxiliar2.BeginTransaction();

                cmd_GestionPb.Transaction = trans2;

                try
                {
                    cmd_GestionPb.ExecuteNonQuery();
                    trans2.Commit();
                    Label5.Text = "An amount is added to an existing product";
                    class_rpr.control_operaciones(Session["login"].ToString(), "added to an existing product", "Jamaica", DropDownList5.SelectedItem.ToString(), DropDownList2.SelectedItem.ToString(), DropDownList3.SelectedItem.ToString(), int.Parse(TextBox2.Text.ToString()), 0);
                    
                    //class_rpr.control_operaciones(Session["login"].ToString(), reporte.ToString());
                    TextBox2.Text = "";
                    BindGrid();
                    Label8.Text = "An amount is added to an existing product";
                }
                catch (Exception er)
                {
                    Label8.Text = "Problems add " + er.Message;
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
                Label8.Text = "Problems add ";
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
        BindGrid();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        GridView2.PageIndex = newPageIndex;       

        string indicativo = RadioButtonList1.SelectedItem.ToString();

        if (indicativo == "All")
        {
            BindGrid();
        }
        else
        {
            Grid_Pagado_Comprueba(indicativo);
        }

        

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int jj = GridView1.SelectedIndex;
        GridViewRow row = GridView1.SelectedRow;
        Label1.Text = row.Cells[3].Text.ToString();
        Label2.Text = row.Cells[4].Text.ToString();
        Label3.Text = row.Cells[5].Text.ToString();
        Label5.Text = row.Cells[2].Text.ToString();
        Label7.Text = row.Cells[6].Text.ToString();
        Button1.Enabled = true;



    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        BindGrid();

    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {



        GridViewRow row = GridView2.Rows[e.RowIndex];
        string pago_string = ((TextBox)(row.Cells[12].Controls[0])).Text.ToString();
        int pago_int = int.Parse(pago_string.ToString());


        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand comando = new SqlCommand("UPDATE tb_entrepot_jamaica_venta SET estado='No Paid' WHERE id=@id", conexion);

        comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        comando.Parameters["@id"].Value = pago_int;

        conexion.Open();

        try
        {
            comando.ExecuteNonQuery();
            GridView2.EditIndex = -1;

        }
        catch (SqlException ec)
        {
            GridView2.Caption = ec.Message;
        }

        finally
        {
            conexion.Close();
            BindGrid();

        }

    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {      
        
        
        GridViewRow row = GridView2.Rows[e.RowIndex];
        string pago_string= ((TextBox)(row.Cells[12].Controls[0])).Text.ToString();
        int pago_int = int.Parse(pago_string.ToString());


        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand comando = new SqlCommand("UPDATE tb_entrepot_jamaica_venta SET estado='Paid' WHERE id=@id", conexion);

        comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        comando.Parameters["@id"].Value = pago_int;

        conexion.Open();

        try
        {
            comando.ExecuteNonQuery();
            GridView2.EditIndex = -1;
           
            


        }
        catch (SqlException ec)
        {
            GridView2.Caption = ec.Message;
        }

        finally
        {
            conexion.Close();
            BindGrid();

        }

        
        
      
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = GridView2.EditIndex;
        GridViewRow row = GridView2.Rows[index];
        TextBox txt_Pago = (TextBox)row.FindControl("TextBox2");
        DropDownList ddl_Pago = (DropDownList)row.FindControl("DropDownList7");
        txt_Pago.Text = ddl_Pago.SelectedItem.Text;
    }


    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        GridView2.EditIndex = -1;
        BindGrid();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string indicativo = RadioButtonList1.SelectedValue;

        switch (indicativo)
        {
            case "Paid":
                {
                    Grid_Pagado_Comprueba("Paid");
                    MultiView3.ActiveViewIndex = -1;
                }

                break;

            case "NoPaid":
                {
                    Grid_Pagado_Comprueba("No Paid");
                    MultiView3.ActiveViewIndex = -1;
                }
                break;

            case "Date & Client":
                {
                    MultiView3.ActiveViewIndex = 0;
                    class_rpr.Combo("SELECT DISTINCT client,client AS id FROM tb_entrepot_jamaica_venta ORDER BY client", "client", "id", DropDownList7);
                    break;
                }

            case "All":
                {
                    BindGrid();
                    MultiView3.ActiveViewIndex = -1;
                    break;
                }

        
        }
        
        //class_rpr.TConexionGrid("SELECT id_gestion_jamaica,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,cantidad FROM (((tb_entrepot_jamaica LEFT JOIN tb_vitola ON tb_entrepot_jamaica.vitola = tb_vitola.id_vitola) LEFT JOIN tb_capa ON tb_entrepot_jamaica.capa=tb_capa.id_capa) LEFT JOIN tb_liga ON tb_entrepot_jamaica.liga=tb_liga.id_liga)  GROUP BY id_gestion_jamaica,tb_entrepot_jamaica.Vitola,tb_vitola.vitola,tb_capa.capa,tb_liga.Liga,Cantidad ORDER BY tb_vitola.Vitola,tb_capa.Capa,tb_liga.Liga", GridView1);
    }

    protected void Grid_Pagado_Comprueba(string indicativo)
    {
        class_rpr.TConexionGrid("SELECT vitola,capa,liga,cantidad,tb_entrepot_jamaica_venta.invoice,tb_entrepot_jamaica_venta.fecha,login,importe,estado,client,vendedor,id,date_paid,tb_entrepot_jamaica_venta_parcial.amount AS parcial FROM tb_entrepot_jamaica_venta LEFT JOIN tb_entrepot_jamaica_venta_parcial ON tb_entrepot_jamaica_venta.invoice=tb_entrepot_jamaica_venta_parcial.invoice  WHERE estado='" + indicativo + "' ORDER BY id DESC", GridView2);
    }

    protected void Label_Pagado_Comprueba()
    {
      
        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString());
        SqlCommand cmd_1 = new SqlCommand("SELECT CONVERT(DECIMAL(10,2),SUM(importe))  AS Estado_Sum FROM tb_entrepot_jamaica_venta WHERE estado ='No paid'", conexion);
        SqlCommand cmd_2 = new SqlCommand("SELECT CONVERT(DECIMAL(10,2),SUM(importe))  AS Estado_Sum FROM tb_entrepot_jamaica_venta WHERE estado ='paid'", conexion);
        SqlCommand cmd_3 = new SqlCommand("SELECT CONVERT(DECIMAL(10,2),SUM(importe))  AS Estado_Sum FROM tb_entrepot_jamaica_venta", conexion);

        conexion.Open();
        try
        {
           
           
            Label13.Text = cmd_1.ExecuteScalar().ToString();
            Label12.Text = cmd_2.ExecuteScalar().ToString();
            Label14.Text = cmd_3.ExecuteScalar().ToString();


        }
        catch(SqlException bef)
        {
            Label13.Text = bef.Message;
        }
        finally
            {

                conexion.Close();
        }
           
        
    }




    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        GridViewRow row = GridView2.SelectedRow;
        Label16.Text = row.Cells[14].Text.ToString();
        Label15.Text = row.Cells[5].Text.ToString();
        MultiView1.ActiveViewIndex = 1;
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cad_invoice="";
        string cad_parciel = "";


        string pa_ida = Label16.Text;
        string pa_id = pa_ida.Remove(pa_ida.Length - 2);

        cad_invoice=Label15.Text.ToString();
        cad_parciel = TextBox7.Text.ToString(); 
       
        int contador_invoice= cad_invoice.Length;
        int contador_parciel = cad_parciel.Length;

        if (contador_invoice == 12 && contador_parciel > 0)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

            string invoice_p = cad_invoice.Substring(0, 10);
           
            DateTime invoice = DateTime.Parse(invoice_p, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            Button3.Text = class_rpr.change_state_parciel(invoice, Calendar1.SelectedDate, Decimal.Parse(cad_parciel.ToString()), int.Parse(pa_id));
                
          
        }


        if (contador_parciel == 0)
        {


            foreach (GridViewRow row in GridView2.Rows)
            {

                Label lb_id = (Label)row.FindControl("label1");
                CheckBox Cheked = (CheckBox)row.FindControl("checkbox1");

                if (Cheked.Checked)
                {
                    int p_id = int.Parse(lb_id.Text.ToString());
                    class_rpr.change_state_multiple(p_id, Calendar1.SelectedDate);

                }

            }
        }

        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Label16.Text ="";
        Label15.Text = "";
        List<int> lista = new List<int>();
        List<string> lista_invoice = new List<string>();
        
        foreach (GridViewRow row in GridView2.Rows)
        {

            Label lb_id = (Label)row.FindControl("label1");
            Label lb_invoice = (Label)row.FindControl("label2");
            CheckBox Cheked = (CheckBox)row.FindControl("checkbox1");

            if (Cheked.Checked)
            {
                lista.Add(int.Parse(lb_id.Text.ToString()));
                lista_invoice.Add(lb_invoice.Text.ToString());
            }
           
        }

        foreach( int valor in lista)
        {

            Label16.Text += valor.ToString()+"||";
        }
        foreach (string valor in lista_invoice)
        {

            Label15.Text += valor.ToString() + "||";
        }



        MultiView1.ActiveViewIndex = 1;

        
       
        
    }
   



    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        class_rpr.TConexionGrid("SELECT vitola,capa,liga,cantidad,tb_entrepot_jamaica_venta.invoice,tb_entrepot_jamaica_venta.fecha,login,importe,estado,client,vendedor,id,date_paid,tb_entrepot_jamaica_venta_parcial.amount AS parcial FROM tb_entrepot_jamaica_venta LEFT JOIN tb_entrepot_jamaica_venta_parcial ON tb_entrepot_jamaica_venta.id=tb_entrepot_jamaica_venta_parcial.id_registro  ORDER BY id DESC", GridView2, Calendar2.SelectedDate);
    }
    protected void DropDownList7_SelectedIndexChanged1(object sender, EventArgs e)
    {
        class_rpr.TConexionGrid("SELECT vitola,capa,liga,cantidad,tb_entrepot_jamaica_venta.invoice,tb_entrepot_jamaica_venta.fecha,login,importe,estado,client,vendedor,id,date_paid,tb_entrepot_jamaica_venta_parcial.amount AS parcial FROM tb_entrepot_jamaica_venta LEFT JOIN tb_entrepot_jamaica_venta_parcial ON tb_entrepot_jamaica_venta.id=tb_entrepot_jamaica_venta_parcial.id_registro WHERE client=@parametro ORDER BY id DESC ", GridView2, DropDownList7.SelectedItem.Text);
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        class_rpr.Combo("SELECT id_client,client FROM tb_entrepot_jamaica_cliente ORDER BY Client", "client", "id_client", DropDownList8);
    }
}