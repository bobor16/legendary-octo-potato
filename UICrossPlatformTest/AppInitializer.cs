using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UICrossPlatformTest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("com.companyname.totalview")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}