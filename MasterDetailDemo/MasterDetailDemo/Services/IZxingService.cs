using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetailDemo.Services
{
    public interface IZxingService
    {
        string GetDecodedValue(byte[] image);
    }
}
