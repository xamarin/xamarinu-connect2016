using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace eXam.AutomatedTests.TestRecorderTests
{
    [TestFixture]
    public class TestRecorderCheckTestBegins
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                    .Android
                    .ApkFile(@"..\..\..\eXam.Droid\bin\Release\eXam.Droid.apk")
                    .StartApp();
        }
    }
}
