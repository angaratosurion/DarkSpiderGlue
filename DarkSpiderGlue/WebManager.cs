using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ServiceHostHelpper;
using System.IO;
using DarkSpiderGlue.Interfaces;

namespace DarkSpiderGlue
{
    /// <summary>
    /// Implementation of SpiderWeb Class to a WCF Service
    /// </summary>
    public class WebManager : ISpiderWebService
    {

        
        /// <summary>
        /// Shutdowns all the hosted libraries
        /// </summary>
        public void ShutdownAll()
        {
            SpiderWeb.ShutdownAll();
        }
        /// <summary>
        /// Returns the full list Of endpoints that are hosted within DarkSpiderGlue
        /// </summary>
        /// <returns>Returns the full list Of endpoints that are hosted within DarkSpiderGlue</returns>
        public List<List<string[]>> GetEndpoints()
        {
            return SpiderWeb.GetEndpoints();
        }
        /// <summary>
        /// Finds the WCF service library with the given name
        /// </summary>
        /// <param name="name">name of the WCF library</param>
        /// <returns>the WCF service library with the given name</returns>
        public IGlueHost FindService(string name)
        {
            SpiderWeb spwb = new SpiderWeb();
            return spwb.FindService(name);
        }
        /// <summary>
        /// Closes the services wich are contained in the provided  WCF Service Library 
        /// </summary>
        /// <param name="name"> the name of the WCF Library</param>
        public void ShutownContainedServices(string name)
        {
            SpiderWeb spwb = new SpiderWeb();
            spwb.ShutownContainedServices(name);

        }
        // <summary>
        /// Hosts all WCF Services that are in the services path and starts them
        /// </summary>
        /// <param name="servicesrootpath">The path of the folder whitch the service folder exists</param>
        public void HostAll(string servicesrootpath)
        {
            SpiderWeb.HostAll(servicesrootpath);
        }
        /// <summary>
        /// Returns the runing services and their endpoints in 2D table 
        /// </summary>
        /// <returns> runing services and their endpoints in 2D table</returns>
        public List<string[]> ListServices()
        {

            return SpiderWeb.ListServices();
        }



    }

}