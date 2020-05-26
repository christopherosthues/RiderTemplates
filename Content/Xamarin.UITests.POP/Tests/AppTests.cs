using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITests.POP.PageObjects;

namespace Xamarin.UITests.POP.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class AppTests : BaseTestFixture<AppPageObject>
    {
        public AppTests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            PageObject = Navigation.GoToWelcomePage();
            App.Screenshot("Welcome screen.");
        }
    }
}