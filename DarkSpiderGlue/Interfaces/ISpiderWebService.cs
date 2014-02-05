using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
//using System.ServiceModel.Web;
namespace DarkSpiderGlue.Interfaces
{
    [ServiceContract]
    interface ISpiderWebService
    {
         
         [OperationContract]
        void ShutdownAll();
         [OperationContract]
        List<List<string[]>> GetEndpoints();
         [OperationContract]
        IGlueHost FindService(string name);
         [OperationContract]
       void ShutownContainedServices(string name);
        [OperationContract]
          void HostAll(string servicesrootpath);
        [OperationContract]
        List<string[]> ListServices();


        
        
    }
}
