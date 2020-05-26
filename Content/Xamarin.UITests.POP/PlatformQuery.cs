using System;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Xamarin.UITests.POP
{
    public class PlatformQuery
    {
        public Query Android
        {
            set
            {
                if (AppManager.Platform == Platform.Android)
                {
                    _current = value;
                }
            }
        }

        public Query iOS
        {
            set
            {
                if (AppManager.Platform == Platform.iOS)
                {
                    _current = value;
                }
            }
        }

        Query _current;
        public Query Current
        {
            get
            {
                if (_current == null)
                {
                    throw new NullReferenceException("Trait not set for current platform");
                }

                return _current;
            }
        }
    }
}