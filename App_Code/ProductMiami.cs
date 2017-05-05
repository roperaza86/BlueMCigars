using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductMiami
/// </summary>
public class ProductMiami
{

    //atributes
    private String vitola, capa, liga, invoice, entry;
    private int cant;
    ///constructor
	public ProductMiami(String pvitola,String pcapa,String pliga,String pinvoice,String pentry,int pcant)
	{
        vitola = pvitola;
        capa = pcapa;
        liga = pliga;
        invoice = pinvoice;
        entry = pentry;
        cant = pcant;
		
	}
//getter 
    public String getVitola()
    {
        return vitola;    
    }
    public String getCapa()
    {
        return capa;
    }
    public String getLiga()
    {
        return liga;
    }
    public String getInvoice()
    {
        return invoice;
    }
    public String getEntry()
    {
        return entry;
    }
    public int getCant()
    {
        return cant;
    }



}