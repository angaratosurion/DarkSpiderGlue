using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DarkSpiderGlueHost;
using DarkSpiderGlue;
using System.IO;

namespace DarkSpiderGlueWeb.Services
{
    public partial class List : System.Web.UI.Page
    {
        AppDomain appdom;
        string[] services;
        protected void Page_Load(object sender, EventArgs e)
        {
          try
            {

                services = System.IO.Directory.GetFiles(Path.Combine(Global.rootpath, "Temp"), "*.run");
                  if (services != null)
                    {

                       // Console.WriteLine(services.Length);
                        foreach (string serv in services)
                        {
                            TableCell cell1 = new TableCell();
                            cell1.Text =Path.GetFileNameWithoutExtension(serv);
                            ServiceName.Cells.Add(cell1);
                            TableCell cel2 = new TableCell();
                            string[] tx = File.ReadAllLines(serv);
                            string t="";
                            foreach (string i in tx)
                            {

                                t += "\n"+i;
                            }
                            cel2.Text = t;
                            EndPoit.Cells.Add(cel2);



                        }
                    }

                

            }
            catch (Exception ex)
            {


            }

                
        }
    }
}