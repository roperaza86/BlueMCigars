<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

      //  Application["ano"] = DateTime.Now.Year.ToString();

        //ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        //{
        //    Path = "~/Scripts/jquery-3.1.0.min.js",
        //    DebugPath = "~/Scripts/jquery-3.1.0.js",
        //    CdnPath = "http://code.jquery.com/jquery-3.1.1.js",
        //    CdnDebugPath = "http://code.jquery.com/jquery-3.1.1.min.js"
        //});

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Session["nivel"] = null;
        Session["login"] = null;

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
      //  class_rpr.control_operaciones(Session["login"].ToString(), "Cerró sesion(Time Out)");
      //  Session["nivel"] = null;
        //Session["login"] = null;
        //FormsAuthentication.SignOut();
       // FormsAuthentication.RedirectToLoginPage();
       
       

    }
       
</script>
