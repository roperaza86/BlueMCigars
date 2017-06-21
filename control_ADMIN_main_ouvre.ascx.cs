using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
//using Microsoft.Reporting.WebForms;

public partial class control_ADMIN_main_ouvre : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        class_rpr.TConexionGridProc("SP_pagos_general", GridView1, Calendar1.SelectedDate, Calendar2.SelectedDate);


        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlDataAdapter aSDA = new SqlDataAdapter("SP_pagos_general", Conexion);
        aSDA.SelectCommand.CommandType = CommandType.StoredProcedure;

        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro1", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro1"].Value = Calendar1.SelectedDate;
        aSDA.SelectCommand.Parameters.Add(new SqlParameter("@parametro2", SqlDbType.VarChar, 50));
        aSDA.SelectCommand.Parameters["@parametro2"].Value = Calendar2.SelectedDate;

        DataTable ResultsTable = new DataTable();

       

        try
        {
            
            aSDA.Fill(ResultsTable);
        }

        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            if (Conexion != null)
            {
                Conexion.Close();
            }
        }


      
        //ReportViewer1.Visible = true;
        //ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
        //ReportViewer1.LocalReport.DataSources.Clear();
        //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ResultsTable));

    }
}