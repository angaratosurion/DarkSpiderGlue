using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkSpiderGlue.Interfaces
{
    public interface IGlueHost
    {
        void Init(string assemblyFilePath);
        void Start();
        void Shutdown();
       List<string[]> GetAllEndpoints();
        string WcfLibaryName();
    }
}
