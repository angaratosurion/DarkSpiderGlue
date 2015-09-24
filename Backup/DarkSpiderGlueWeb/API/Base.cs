using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace DarkSpiderGlueWeb.API
{
    public class Base
    {
        public static string GetAppName()
        {
            try
            {
                return Assembly.GetExecutingAssembly().GetName().Name;

            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public static string GetModuleNamesAndVersions()
        {
            try
            {
                string ap = null;

                //
                // return Assembly.GetExecutingAssembly().GetName().
                if (Assembly.GetExecutingAssembly().GetModules() != null)
                {

                    ;
                    foreach (Module mod in Assembly.GetExecutingAssembly().GetModules())
                    {

                        ap += "\n" + mod.Name + " - " + mod.Assembly.GetName().Version.ToString();

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