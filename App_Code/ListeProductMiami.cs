using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListeProductMiami
/// </summary>
public class ListeProductMiami
{
     ///atributes
    private List<ProductMiami> listeProd;

    //constructor
	public ListeProductMiami(List<ProductMiami> liste)
	{
        listeProd = liste;
	}

    ///methodes


    public void addProdListe(ProductMiami prod)
    {
        listeProd.Add(prod);
    
    }

}