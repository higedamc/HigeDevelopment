using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetailDemo.Services
{
    public interface IDeviceService
    {
        void PlayVibrate();
        void DisableSleep();
        void EnableSleep();
    }
}
