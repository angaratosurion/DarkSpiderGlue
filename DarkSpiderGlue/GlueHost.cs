using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.ServiceModel;
using System.Xml.Linq;
using System.ServiceModel.Configuration;
using System.Net.Security;
using System.Net;
using DarkSpiderGlue.Interfaces;

namespace DarkSpiderGlue
{
    /// <summary>
    /// The Generic Host class which will host all the services contained within a wcfLibrary
    /// </summary>
    public class GlueHost : MarshalByRefObject, IGlueHost
    {
        IList<Type> _services;
        List<ServiceHost> _hosts;
        List<String> _servicenames;
        string wcfname;
       /// <summary>
       /// Ininitialisesall service's included in the given assembly and creates/configures a servicehost
       /// </summary>
       /// <param name="assemblyFilePath">full path of the assembly file</param>
        public void Init(string assemblyFilePath)
        {
            try
            {
                _services = new List<Type>();
                _servicenames = new List<string>();
                Assembly serviceAssembly = Assembly.LoadFrom(assemblyFilePath);
                wcfname = serviceAssembly.GetName().Name;
                System.Configuration.Configuration config =
                  System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

                ServiceModelSectionGroup serviceModelSectionGroup = config.GetSectionGroup("system.serviceModel") as ServiceModelSectionGroup;

                foreach (ServiceElement serviceElement in serviceModelSectionGroup.Services.Services)
                {
                    _services.Add(serviceAssembly.GetType(serviceElement.Name));
                    _servicenames.Add(serviceAssembly.GetName().Name);
                 
                }

            }
            catch (Exception ex)
            {


            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyFilePath"></param>
        private static void EnsureServiceHostHelpperAssemblyExists(string assemblyFilePath)
        {
            try
            {
                File.Copy(Assembly.GetExecutingAssembly().Location, Path.Combine(Path.GetDirectoryName(assemblyFilePath), Path.GetFileName(Assembly.GetExecutingAssembly().Location)), true);
            }
            catch
            {
            }
        }
        //public Uri ConfigGlueEndpoint(string  hostname)
        //{
        //    try
        //    {
        //        Uri url=null ;
        //        //if (host != null)
        //        {
        //            Uri localaddress = null;// new Uri("http://" + Dns.GetHostByName(Environment.MachineName).AddressList[0] + "/" +hostname);
        //            url = localaddress;
                  
        //        }

              



        //     return url;


        //    }
        //    catch (Exception ex)
        //    {
        //      return null;

        //    }

        //}

        /// <summary>
        /// Starts all the services that are included in the given assembly
        /// </summary>
        public void Start()
        {

            try
            {
                _hosts = new List<ServiceHost>();

                foreach (Type serviceType in _services)
                {
                    ServiceHost servhost ;
                   

                  
                        servhost = new ServiceHost(serviceType);
                    
                    _hosts.Add(servhost);
                    servhost.Open();
                    



                }


            }
            catch (Exception ex)
            {


            }

        }
        /// <summary>
        /// Stops all the services in the given assembly
        /// </summary>
        public void Shutdown()
        {
            try
            {
                foreach (ServiceHost serviceHost in _hosts)
                {
                    serviceHost.Close();
                    //System.Diagnostics.Trace.WriteLine("Host for {0} has been closed...", serviceHost.Description.ServiceType.Name);
                }
            }
            catch (Exception ex)
            {


            }
        }
        /// <summary>
        /// Returns the full list of the endpoints  from the given assemblies
        /// </summary>
        /// <returns></returns>
        public List<string[]> GetAllEndpoints()
       {

           try{
              
               List<string[]> ap;
               ap = new List<string []>();

               foreach (ServiceHost host in _hosts)
               {
                   string [] tp = new string[host.Description.Endpoints.Count];
                   for (int i = 0; i < host.Description.Endpoints.Count; i++)
                   {
                       tp[i] = host.Description.Endpoints[i].Address.ToString();

                   }
                   ap.Add(tp);


               }



               return ap;
           }
           catch( Exception ex)
           {
               return null;

           }

       }
        /// <summary>
        /// Loads the WCF Library's configuration and the assembly code in the memory and returns all the contained
        /// services hosted within a GlueHost
        /// </summary>
        /// <param name="assemblyFilePath">full path of the WCG Library</param>
        /// <returns>returns all the contained
        /// services hosted within a GlueHost</returns>
        public static IGlueHost HostServices(string assemblyFilePath)
        {

            try
            {
                AppDomainSetup setup = new AppDomainSetup();
                setup.ApplicationBase = Path.GetDirectoryName(assemblyFilePath);
                setup.ApplicationName = Path.GetFileNameWithoutExtension(assemblyFilePath);
                setup.ConfigurationFile = assemblyFilePath.Replace(".service",".dll") + ".config";

                EnsureServiceHostHelpperAssemblyExists(assemblyFilePath);

                AppDomain hostAppDomain = AppDomain.CreateDomain(setup.ApplicationName, AppDomain.CurrentDomain.Evidence, setup);
                IGlueHost host = hostAppDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "DarkSpiderGlue.GlueHost") as IGlueHost;
                host.Init(assemblyFilePath);

                return host;
            }
            catch (Exception ex)
            {

               return null;
            }
        }
        /// <summary>
        /// Returns the List with names of the Loaded Services
        /// </summary>
        /// <returns> Returns the List with names of the Loaded Services</returns>
        public string [] GetServicesList()
        {
            try
            {
                string [] ap = null;

                if (_services != null)
                {
                    ap = new string[_servicenames.Count];
                    for (int i = 0; i < ap.Length; i++)
                    {
                        ap[i] = _servicenames[i];

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
        /// Property which has the name of the WCFLibary ,assmbly
        /// </summary>
        /// <returns>name of the WCFLibary ,assmbly</returns>
        public string WcfLibaryName()
        {
            try
            {


                return wcfname;
            }

            catch (Exception ex)
            {

                return null;
            }

        }
   
   
   
   }
}
