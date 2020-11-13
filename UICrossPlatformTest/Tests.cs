using System;
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
            //Arrange
            app.Tap("UsernameTest");
            app.EnterText("Hellew");
            app.DismissKeyboard();

            app.Tap("PasswordTest");
            app.EnterText("Test");
            app.DismissKeyboard();

            //Act
            app.Tap("LoginButtonTest");
            app.WaitForElement("TestLabel");

            //Assert
            bool result = app.Query(e => e.Marked("TestLabel")).Any();
            Assert.IsTrue(result);
        }
    }
}
