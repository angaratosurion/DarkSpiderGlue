using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ServiceHostHelpper;
using System.IO;
using DarkSpiderGlue.Interfaces;
using DarkSpiderGlue;
using System.ServiceModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.ServiceModel;
using System.Net;
namespace DarkSpiderGlueHost
{
   public  class Program
    {
        static Mutex mtx;
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public static List<List<string[]>> end;
       public static  string[] services;
      
      //static  darkspiderglueclient.SpiderWebServiceClient client;// = new darkspiderglueclient.SpiderWebServiceClient();

       static  ServiceHost servhost;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Press Enter to Exit ");
            end = new List<List<string[]>>();
            
            Console.WriteLine("end points");
           
            Console.Title = System.Windows.Forms.Application.ProductName;
            mtx = new Mutex(false,Console.Title);
          //  Console.WriteLine(args.Length.ToString() + "\n" + args[0]);
            if (mtx.WaitOne(0, false))
            {


                if (args.Length != 0)
                {
                    if (args.Length > 1)
                    {
                        SpiderWeb.HostAll(args[0]);
                        end = SpiderWeb.GetEndpoints();
                        services = Directory.GetFiles(args[0] + "\\Services", "*.service");
                        string te = "";
                        foreach (List<string[]> str in end)
                        {
                            foreach (string[] ar in str )
                            {

                                for (int i = 0; i < ar.Length; i++)
                                {
                                    Console.WriteLine("url :" + ar[i]);
                                    te += "\n" + ar[i];

                                }
                            }
                        }

                      //  Console.WriteLine(args.Length.ToString() + "\n" + args[1]+ services.Length);
                        foreach (string serv in services)
                        {
                            StreamWriter wri = File.CreateText(args[1] + "\\" + Path.GetFileNameWithoutExtension(serv) + ".run");
                            
                          
                            wri.WriteLine(te);
                            wri.Flush();
                            wri.Close();


                        }

                    }
                    else if (args.Length==1)
                    {
                        SpiderWeb.HostAll(args[0]);
                        end = SpiderWeb.GetEndpoints();
                        foreach (List<string[]> str in end)
                        {
                            foreach (string[] ar in str)
                            {

                                for (int i = 0; i < ar.Length; i++)
                                {
                                    Console.WriteLine("url :" + ar[i]);

                                }
                            }
                        }

                    }
                    




                    
                }
                else
                {
                    //SpiderWeb.HostAll();
                    end = SpiderWeb.GetEndpoints();
                   
                }

                if ((args.Length > 0) && (args[0].Contains("-w") == true))
                {
                    Console.WriteLine(args[0]);
                    IntPtr hWnd = FindWindow(null, System.Windows.Forms.Application.ProductName); //put your console window caption here
                    if (hWnd != IntPtr.Zero)
                    {
                        //Hide the window
                        ShowWindow(hWnd, 0); // 0 = SW_HIDE
                    }


                }
                else
                {
                    foreach (List<string[]> str in end)
                    {
                        foreach (string[] ar in str)
                        {

                            for (int i = 0; i < ar.Length; i++)
                            {
                                Console.WriteLine("url :" + ar[i]);

                            }
                        }

                    }



                }
                Console.ReadLine();
            }
            else
            {


            }
       
        }
    }
}
