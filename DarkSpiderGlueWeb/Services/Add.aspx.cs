using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ICSharpCode.SharpZipLib.Zip ;

namespace DarkSpiderGlueWeb.Services
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
              try
            {
              Random rnd = new Random();
               //if(( fileUpload.HasFile) &&(fileUpload.PostedFile.ContentType=="imgae/jpeg"))
              {
                  int num = rnd.Next();
                    string tfile = Path.Combine(Global.rootpath,"Temp")+"\\"+Convert.ToString(num)+".zip" ;
                  //  if (flUpload.PostedFile.ContentType == "application/zip")
                    {
                        this.flUpload.SaveAs(tfile);
                        FastZip zip = new FastZip();
                       // Directory.CreateDirectory(Global.rootpath + "\\Temp\\" + Convert.ToString(num));
                        zip.ExtractZip(tfile, Global.rootpath + "\\Services", "");
                      //  this.lblServiceFiles.Text += tfile;
                       // Console.WriteLine(Global.rootpath + "\\Services");
                      Global.pr=  Global.prosmngr.Restart(Global.info);
                    }
                   // else
                    {

                    }
                   
                 


                }

            }
              catch (Exception ex)
              {

                

              }
        }
    }
}