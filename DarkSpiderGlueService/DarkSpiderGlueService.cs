using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.ServiceModel;
using System.Text;
using DarkSpiderGlue;

namespace DarkSpiderGlueService
{
    partial class DarkSpiderGlueService : ServiceBase
    {
        ServiceHost host = new ServiceHost(typeof(DarkSpiderGlue.SpiderWeb));

        public DarkSpiderGlueService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            SpiderWeb.HostAll();


            host.Open();
            
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.

            host.Close();
        
        }
    }
}
