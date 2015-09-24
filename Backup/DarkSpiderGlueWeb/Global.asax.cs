using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using DarkSpiderGlueWeb.API;


namespace DarkSpiderGlueWeb
{
    public class Global : System.Web.HttpApplication
    {
        internal static ProcessMngr prosmngr = new ProcessMngr();
       public static  string rootpath,apppath;
        internal static System.Diagnostics.Process pr;
       internal static  System.Diagnostics.ProcessStartInfo info;
        //IntPtr handle;
          
        void Application_Start(object sender, EventArgs e)
        {
            try
            {
                // Code that runs on application startup
                apppath = System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath);
                // Code that runs on application startup
                rootpath = System.IO.Path.Combine(apppath, "App_Data");
                pr = new System.Diagnostics.Process();
                info = new System.Diagnostics.ProcessStartInfo();
                info.CreateNoWindow = true;
                info.FileName = Path.Combine(apppath, "Bin") + "\\DarkSpiderGlueHost.exe";
                info.Arguments = "\"" + rootpath + "\"" + " \"" + Path.Combine(rootpath,"Temp") + "\"";

                if (!File.Exists(rootpath + "\\Services\\DarkSpiderGlue.dll"))
                {
                    File.Copy(Path.Combine(apppath, "Bin") + "\\DarkSpiderGlue.dll", rootpath + "\\Services\\DarkSpiderGlue.dll");
                }


                pr = Global.prosmngr.Start(info);
                
                
            }
            catch (Exception ex)
            {

            }
           
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            try
            { 
                string [] files  = Directory.GetFiles(Path.Combine(rootpath,"Temp"),"*.run");
                foreach( string f in files)
                {
                    File.Delete(f);

                }

            }
            catch (Exception ex)
            {

            }

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
