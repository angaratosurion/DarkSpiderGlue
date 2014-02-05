using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ServiceHostHelpper;
using System.IO;
using DarkSpiderGlue.Interfaces;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace DarkSpiderGlue
{
  public   class SpiderWeb
    {
      internal  static List<IGlueHost> _hosts = new List<IGlueHost>();
      /// <summary>
      /// Hosts all WCF Services that are in the application folder\services path and starts them
      /// </summary>
       public static void HostAll()
        {
         try 
         {
             string [] assemblyFiles = Directory.GetFiles( System.Windows.Forms.Application.StartupPath+"\\Services", "*.service", SearchOption.TopDirectoryOnly);
            // System.Windows.Forms.MessageBox.Show(System.Windows.Forms.Application.StartupPath + "\\Services"+ "\n" + assemblyFiles.Length.ToString() );
            foreach (string assemblyFile in assemblyFiles)
            {
                IGlueHost host = GlueHost.HostServices(assemblyFile);
                _hosts.Add(host);
                host.Start();
            }
         }
           catch(Exception ex)
         {


           }
        }
       // <summary>
       /// Hosts all WCF Services that are in the services path and starts them
       /// </summary>
       /// <param name="servicesrootpath">The path of the folder whitch the service folder exists</param>
       public static void HostAll(string servicesrootpath)
       {
           try
           {
              if ((servicesrootpath != null)&&(Directory.Exists(servicesrootpath)))
               {
                   string[] assemblyFiles = Directory.GetFiles(servicesrootpath+ "\\Services", "*.service", SearchOption.TopDirectoryOnly);
                   // System.Windows.Forms.MessageBox.Show(System.Windows.Forms.Application.StartupPath + "\\Services"+ "\n" + assemblyFiles.Length.ToString() );
                  // Console.WriteLine(assemblyFiles[0]);
                   foreach (string assemblyFile in assemblyFiles)
                   {
                       IGlueHost host = GlueHost.HostServices(assemblyFile);
                       _hosts.Add(host);
                       host.Start();
                   }
               }
           }
           catch (Exception ex)
           {


           }
       }
       ///// <summary>
       ///// Hosts all WCF Services that are in the application folder\services path and starts them
       ///// use it with asp.net sites
       ///// </summary>
       //public static void HostAllWeb()
       //{
       //    try
       //    {
       //        string[] assemblyFiles = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/bin") + "\\Services", "*.service", SearchOption.TopDirectoryOnly);
       //        // System.Windows.Forms.MessageBox.Show(System.Windows.Forms.Application.StartupPath + "\\Services"+ "\n" + assemblyFiles.Length.ToString() );
       //        foreach (string assemblyFile in assemblyFiles)
       //        {
       //            IGlueHost host = GlueHost.HostServices(assemblyFile);
       //            _hosts.Add(host);
       //            host.Start();
       //        }
       //    }
       //    catch (Exception ex)
       //    {


       //    }
       //}
      /// <summary>
      /// Shutdowns all the hosted libraries
      /// </summary>
       public  static void ShutdownAll()
        {
             try 
         {
            _hosts.ForEach((host) => host.Shutdown());
             
             }
        
       catch(Exception ex) 
        {


           }
    }
      /// <summary>
      /// Returns the full list Of endpoints that are hosted within DarkSpiderGlue
      /// </summary>
       /// <returns>Returns the full list Of endpoints that are hosted within DarkSpiderGlue</returns>
       public static  List<List<string[]>> GetEndpoints()
       {

           try
           {
               List<List<string[]>> ap = new List<List<string[]>>();

               foreach (IGlueHost host in _hosts)
               {
                   ap.Add(host.GetAllEndpoints());
                   
               }


               return ap;


           }
           catch (Exception ex)
           {
               return null;

           }

       }

      /// <summary>
      /// Finds the WCF service library with the given name
      /// </summary>
      /// <param name="name">name of the WCF library</param>
       /// <returns>the WCF service library with the given name</returns>
       public IGlueHost FindService(string name)
       {
           try
           {
               IGlueHost ap = null;

               if (name != null)
               {
                   foreach (IGlueHost host in _hosts)
                   {

                       if (host.WcfLibaryName().Equals(name))
                       {

                           ap = host;
                           return ap;
                       }

                   }

               }

               return ap;

           }

           catch (Exception ex)
           {
               return null;

           }

       }
      /// <summary>
      /// Closes the services wich are contained in the provided  WCF Service Library 
      /// </summary>
      /// <param name="name"> the name of the WCF Library</param>
       public void ShutownContainedServices(string name)
       {

           try
           {
               IGlueHost ap = null;

               if (name != null)
               {
                   this.FindService(name).Shutdown();
               }

             //  return ap;

           }

           catch (Exception ex)
           {
              // return null;

           }

       }
      /// <summary>
      /// Returns the runing services and their endpoints in 2D table 
      /// </summary>
       /// <returns> runing services and their endpoints in 2D table</returns>
       public static List<string[]> ListServices()
       {

           try
           {
               List<string[]> ap = null;

               if (_hosts != null)
               {
                   ap = new List<string[]>();
                   foreach (IGlueHost host in _hosts)
                   {
                       string [] inf = new string[3];
                       inf[0] = host.WcfLibaryName();
                       List<string[]> end = host.GetAllEndpoints();
                       string he="";

                       foreach (string[] o in end)
                       {

                           foreach (string i in o)
                           {

                               he += "\n" + i;
                           }

                       }
                       inf[1] = he;

                   }

               }

               return ap;

           }

           catch (Exception ex)
           {
               return null;

           }

       }
  
    }
}
