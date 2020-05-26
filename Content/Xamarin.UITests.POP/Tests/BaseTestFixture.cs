using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITests.POP.PageObjects;

namespace Xamarin.UITests.POP.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class BaseTestFixture<T> where T : BasePageObject
    {
        protected IApp App => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;
        protected T PageObject { get; set; }

        protected BaseTestFixture(Platform platform)
        {
            AppManager.Platform = platform;
        }

        [SetUp]
        public virtual void SetUp()
        {
            AppManager.StartApp();
        }

        [TearDown]
        public virtual void TearDown()
        {
            AppManager.App = null;
            PageObject = null;
        }
    }
}