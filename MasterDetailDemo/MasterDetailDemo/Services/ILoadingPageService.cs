using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MasterDetailDemo.Services
{
    public interface ILoadingPageService
    {
        void InitLoadingPage(ContentPage loadingIndicatorPage = null);
        void ShowLoadingPage();
        void HideLoadingPage();
    }
}
