using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;
namespace DarkSpiderGlueWeb.API
{
    //using System.IO;
    public class ProcessMngr
    { 
        internal static ProcessStartInfo srtinf;
        static Process pr1;
        public Process Start(System.Diagnostics.ProcessStartInfo info)
        {
            try
            {  Process pr=null;
                if (info != null)
                {

                    pr= new System.Diagnostics.Process();
                    pr.StartInfo = info;
                    ProcessMngr.srtinf = info;
                    pr.Start();
                    pr1 = pr;

                }
                return pr;
                
            }
            catch (Exception ex)
            {

                return null;

            }
        }
        public void Stop()
        {

            try
            {
               
                if (pr1  != null)
                {
                    pr1.Kill();
                   

                }
               
            }
            catch (Exception ex)
            {

                

            }

        }
        public Process Restart(ProcessStartInfo info)
        {

            try
            {
                Process pr = null;
                if (info != null)
                {

                    this.Stop();
                   pr= this.Start(info);
                   pr1 = pr;

                }
                return pr;

            }
            catch (Exception ex)
            {

                return null;

            }

        }
    }
}