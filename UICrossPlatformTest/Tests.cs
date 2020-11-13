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
            app.Tap(x => x.Button("Next"));
            var result = app.WaitForElement(e => e.Marked("get from Database"));
            Assert.IsFalse(result.Any());
            app.Repl();

        }
    }
}
