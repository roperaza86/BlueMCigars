using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {     
      


    }/*
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {

            string cad_conex = "Server=yew.arvixe.com;Database=nicaragua;User id=roberto;Pwd=12345";

            SqlConnection conexion = new SqlConnection(cad_conex);

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tb_consumo_material", conexion);
            DataSet DS = new DataSet();            
            adapter.Fill(DS);
            GridView1.DataSource = DS.Tables[0].DefaultView;
            GridView1.DataBind();
            Label1.Text = "ok";
        }
        catch (SystemException ex)
        {
            Label1.Text = ex.Message;

        }
    }*/
   
}