using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UICrossPlatformTest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        private bool ifLoggedIn;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void LoginPageTest()
        {
            if (!ifLoggedIn)
            {
                app.Tap("UsernameTest");
                app.EnterText("jacksparrow");
                app.DismissKeyboard();

                app.Screenshot("First screenshot");

                app.Tap("PasswordTest");
                app.EnterText("test");
                app.DismissKeyboard();

                app.Screenshot("Second screenshot");

                app.Tap("LoginButtonTest");
                app.WaitForElement("LabelTest");

                app.Screenshot("Third screenshot");

                bool result = app.Query(e => e.Text("jacksparrow")).Any();
                Assert.IsTrue(result);


                ifLoggedIn = true;
            }

            app.Tap("NRTest");
            app.WaitForElement("ChangeLabelTest");
            app.Screenshot("Fourth screenshot");

            AppResult[] state = app.Query(e => e.Marked("Not Registered"));
            int count = state.Count();
            Assert.That(count == 2);
        }
    }
}
