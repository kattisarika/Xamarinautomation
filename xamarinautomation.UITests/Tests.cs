using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace xamarinautomation.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
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
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void CCEntry_LessThan5Digit_Wrong()
        {
            app.EnterText("CreditCardEntry", "1234");
            app.Tap("ValidateCC");
            app.WaitForElement("message");
            Assert.IsTrue(app.Query(x => x.Id("message").Text("Wrong")).Any());
            //SaveScreenshot();
        }

        [Test]
        public void CCEntry_MoreOrEqual5Digit_Correct()
        {
            app.EnterText("CreditCardEntry", "12345");
            app.Tap("ValidateCC");
            app.WaitForElement("message");
            Assert.IsTrue(app.Query(x => x.Id("message").Text("Correct")).Any());
            //SaveScreenshot();
        }

        [Test]
        public void TextIsDisplayed()
        {
            app.Repl();
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Home Page!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }
    }
}
