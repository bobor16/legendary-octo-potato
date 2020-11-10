using System;
using System.IO;
using Totalview.Services;
using Xamarin.Forms;

namespace Totalview
{
    public partial class App : Application
    {
        static DataDummy dummy;

        public static DataDummy DataDummy
        {
            get
            {
                if (dummy == null)
                {
                    dummy = new DataDummy(
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData)
                            , "dummy.db3"));
                }
                return dummy;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
