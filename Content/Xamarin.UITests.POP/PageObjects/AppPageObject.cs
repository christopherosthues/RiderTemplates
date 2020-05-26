using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Xamarin.UITests.POP.PageObjects
{
    public class AppPageObject : BasePageObject
    {
        private readonly Query TitleText;
        private readonly Query OKButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android =x => x.Marked("Welcome to Xamarin.Forms!"),
            iOS = x => x.Marked("Welcome to Xamarin.Forms!")
        };

        public AppPageObject()
        {
            if (OnAndroid)
            {
                TitleText = x => x.Marked("Welcome to Xamarin.Forms!");
            }

            if (OniOS)
            {
                TitleText = x => x.Marked("Welcome to Xamarin.Forms!");
            }

            OKButton = x => x.Text("OK");
        }

        public AppPageObject TapOKButton()
        {
            App.Tap(OKButton);

            return this;
        }
    }
}