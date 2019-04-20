using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetailDemo.Services
{
    public interface IAssemblyService
    {
        string GetPackageName();
        string GetVersionName();
        int GetVersionCode();
    }
}
