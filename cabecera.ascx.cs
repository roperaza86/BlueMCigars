using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class cabecera : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fecha = DateTime.Today.ToLongDateString();
        if (Session["login"] != null)
        {
            if (DateTime.Now.Hour < 12)
            {
                Label1.Text = "Buenos dias, " + Session["login"] + ", hoy es " + fecha;
            }
            else
            {
                Label1.Text = "Buenas tardes, " + Session["login"] + ", hoy es " + fecha;
            }
        }
        else 
        {
            if (DateTime.Now.Hour < 12)
            {
                Label1.Text = "Buenos dias, hoy es " + fecha;
            }
            else
            {
                Label1.Text = "Buenas tardes, hoy es " + fecha;
            }
        }
        if (Session["nivel"] != null)
        {
            string Tuser = Session["nivel"].ToString();

            switch (Tuser)
            {
                case "admin": MultiView1.ActiveViewIndex = 0;
                    break;
                case "user": MultiView1.ActiveViewIndex = 1;
                    break;
                case "user_miami": MultiView1.ActiveViewIndex = 2;
                    break;
                case "user_jamaica": MultiView1.ActiveViewIndex = 3;
                    break;
            }
        }

        else 
        {
            MultiView1.ActiveViewIndex = -1;
        }
    }

   
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 1;
        

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 2;
        
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 3;
        
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 0;
        
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 1;
        
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 2;
        
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 0;


    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Session["nivel"] = null;
        Session["login"] = null;
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
        

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["nivel"] = null;
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
//        class_rpr.control_operaciones(Session["login"].ToString(), "cerró sesión");
        Session["login"] = null;
        
        

    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 4;
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 3;
    }
    protected void LinkButton18_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 5;
    }
    protected void LinkButton22_Click(object sender, EventArgs e)
    {

        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 6;
    }
    protected void LinkButton23_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 7;
    }
    protected void LinkButton27_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder placeholder_master = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        MultiView mview_default = (MultiView)placeholder_master.FindControl("MultiView_Admin");
        mview_default.ActiveViewIndex = 8;
    }
}
