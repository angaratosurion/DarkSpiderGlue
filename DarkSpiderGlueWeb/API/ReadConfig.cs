using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
namespace DarkSpiderGlueWeb.API
{
    public class ReadConfig
    {
        public const string configfile = "spider_config.xml";
        DataSet set = new DataSet();
        public void Readconfig()
        {
            try
            {
                set.ReadXml(Global.rootpath + "\\" + configfile);
                if (set.Tables.Count > 0)
                {

                    

                }
            }
            catch (Exception ex)
            {


            }


        }
        public Boolean createUser
        {
            get
            {
                this.Readconfig();
                return Boolean.Parse(set.Tables[0].Rows[0].ItemArray[set.Tables[0].Columns["createuser"].Ordinal].ToString());

            }

        }
    }
}