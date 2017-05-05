using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Dao_Miami
/// </summary>
public class Dao_Miami
{
   //atributes
   private List<string> listeContenuGridview;
   private List<ProductMiami> listeProd; 


	public Dao_Miami()
	{

        listeProd = null;
		//
		// TODO: Add constructor logic here
		//
	}

    ///getter setter
    ///

    public List<string> get_listeContenuGridview()
    {
        return this.listeContenuGridview;
    
    }
    

    public void getDataGridView(GridView gridView, int nbCell, int nbCellReference)
    {
        List<string> liste = new List<string>();
       

        foreach (GridViewRow row in gridView.Rows)
        {

            CheckBox chkRow = (row.Cells[nbCellReference].FindControl("CheckBox1") as CheckBox);
            if (chkRow.Checked)
            {
                liste.Add(row.Cells[nbCell].Text.ToString());
                chkRow.Checked = false;
            }
            
                
                       
                 
           
        }

        listeContenuGridview = liste;
    }

    public int deleteDataIninventario(string query)
    {
       
        int qte = this.get_listeContenuGridview().Count;
        int qteAffecte=0;

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection Conexion = new SqlConnection(CadConexion);

        SqlCommand cmd = new SqlCommand(query, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
        
        
        for (int i = 0; i < qte; i++)
        {

            cmd.Parameters["@id"].Value = int.Parse(listeContenuGridview[i]);

            try {
                Conexion.Open();
                qteAffecte += cmd.ExecuteNonQuery();                             
            
            }
            catch(SqlException ex)
            {
                ex.StackTrace.ToString();
            }

            finally
            {
            Conexion.Close();
            
            }
        
        }

        return qteAffecte;
    
    }



    public String getDataIninventario(string query)
    {
        SqlDataReader reader;
        String lol = "";
        List<ProductMiami> listeProd = new List<ProductMiami>();
        ProductMiami prod;
        
        int qte = this.get_listeContenuGridview().Count;
       

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection conexion = new SqlConnection(CadConexion);

        SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        
        try
        {
            
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            conexion.Open();

            for (int i = 0; i < qte; i++)
            {
               
                adapter.SelectCommand.Parameters["@id"].Value = int.Parse(listeContenuGridview[i]);
                
                reader = adapter.SelectCommand.ExecuteReader();

                while (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        String vitola = reader.GetString(0);
                        String capa = reader.GetString(1);
                        String liga = reader.GetString(2);
                        int cantidad = reader.GetInt32(3);
                        String entry = reader.GetString(4);
                        String invoice = reader.GetString(5);
                       
                        prod=new ProductMiami(vitola, capa, liga, invoice, entry, cantidad);
                        listeProd.Add(prod);
                        

                    }

                    reader.NextResult();
                }
                reader.Close();

            }
        }

        catch (SqlException ex)
        {
            lol = ex.Message;

        }

        finally
        {
            conexion.Close();
            this.listeProd = listeProd;
           



        
        }

     return lol;
            
           
      
        }


    public String fromHistoryToInventary(string query) {

        string mensaje = "";
        int vitola=-1;
        int capa = -1;
        int liga=-1;

        string CadConexion = WebConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
        SqlConnection conexion = new SqlConnection(CadConexion);


        SqlCommand cmdUpdateInventary = new SqlCommand(query, conexion);
        cmdUpdateInventary.CommandType = CommandType.StoredProcedure;

         cmdUpdateInventary.Parameters.Add(new SqlParameter("@vitola",SqlDbType.Int));
         cmdUpdateInventary.Parameters.Add(new SqlParameter("@capa", SqlDbType.Int));
         cmdUpdateInventary.Parameters.Add(new SqlParameter("@liga", SqlDbType.Int));
         cmdUpdateInventary.Parameters.Add(new SqlParameter("@entry", SqlDbType.VarChar,25));
         cmdUpdateInventary.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));

         foreach (ProductMiami p in this.listeProd)
         {



             SqlCommand cmdVitola = new SqlCommand("SELECT id_vitola FROM tb_vitola WHERE vitola=@vitola", conexion);
             cmdVitola.Parameters.Add(new SqlParameter("@vitola",SqlDbType.VarChar));
             cmdVitola.Parameters["@vitola"].Value =p.getVitola();

             SqlCommand cmdCapa = new SqlCommand("SELECT id_capa FROM tb_capa WHERE capa=@capa", conexion);
             cmdCapa.Parameters.Add(new SqlParameter("@capa",SqlDbType.VarChar));
             cmdCapa.Parameters["@capa"].Value =p.getCapa();


             SqlCommand cmdLiga = new SqlCommand("SELECT id_liga FROM tb_liga WHERE liga=@liga", conexion);
             cmdLiga.Parameters.Add(new SqlParameter("@liga", SqlDbType.VarChar));
             cmdLiga.Parameters["@liga"].Value = p.getLiga();

             try
             {
                 conexion.Open();
                 vitola = (int)cmdVitola.ExecuteScalar();
             }
             catch (SqlException ex)
             {
                 mensaje = ex.Message+ex.LineNumber.ToString();

             }

             finally
             {
                 conexion.Close();

             }

             try
             {
                 conexion.Open();
                 capa = (int)cmdCapa.ExecuteScalar();
             }
             catch (SqlException ex)
             {

                 mensaje = ex.Message + ex.LineNumber.ToString();
             }

             finally
             {
                 conexion.Close();

             }



             try
             {
                 conexion.Open();
                 liga = (int)cmdLiga.ExecuteScalar();
             }
             catch (SqlException ex)
             {
                 mensaje = ex.Message + ex.LineNumber.ToString();

             }

             finally
             {
                 conexion.Close();

             }


             cmdUpdateInventary.Parameters["@vitola"].Value = vitola;
             cmdUpdateInventary.Parameters["@capa"].Value = capa;
             cmdUpdateInventary.Parameters["@liga"].Value = liga;            
             cmdUpdateInventary.Parameters["@entry"].Value =p.getEntry();
             cmdUpdateInventary.Parameters["@cantidad"].Value = p.getCant();

               try
             {
              conexion.Open();
              int k=cmdUpdateInventary.ExecuteNonQuery();
              mensaje = "Borrado(s) del historial ";
              
             }
             catch (SqlException ex)
             {

                 mensaje = ex.Message + ex.LineNumber.ToString();
             }

             finally
             {
                 conexion.Close();

             }


            

            
         
         
         
         }


         return mensaje;
    
    }

        

    }
    
    
