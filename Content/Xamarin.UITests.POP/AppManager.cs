using System;
using System.IO;
using Xamarin.UITest;

namespace Xamarin.UITests.POP
{
    public static class AppManager
    {
        private static readonly char PathSeparator = Path.DirectorySeparatorChar;

        private const string AndroidProject = "AppName.Droid";
        private const string ApkFile = "com.companyname.appname.DEV-Signed.apk";

        private static readonly string ApkPath = $"..{PathSeparator}..{PathSeparator}..{PathSeparator}" +
                                                 $"..{PathSeparator}..{PathSeparator}src{PathSeparator}" +
                                                 $"{AndroidProject}{PathSeparator}bin{PathSeparator}" +
                                                 $"DebugUITest{PathSeparator}{ApkFile}";

        private const string IOSProject = "AppName.iOS";
        private static readonly string AppFile = $"{IOSProject}.app";
        private static readonly string AppPath = $"..{PathSeparator}..{PathSeparator}..{PathSeparator}" +
                                                 $"..{PathSeparator}..{PathSeparator}src{PathSeparator}" +
                                                 $"{IOSProject}{PathSeparator}bin{PathSeparator}" +
                                                 $"DebugUITest{PathSeparator}{AppFile}";


        static IApp _app;
        public static IApp App
        {
            get
            {
                if (_app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return _app;
            }
            set => _app = value;
        }

        static Platform? _platform;
        public static Platform Platform
        {
            get
            {
                if (_platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return _platform.Value;
            }

            set => _platform = value;
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                _app = ConfigureApp.Android.EnableLocalScreenshots().ApkFile(GetIDEAppPath(ApkPath)).StartApp();
            }

            if (Platform == Platform.iOS)
            {
                _app = ConfigureApp.iOS.EnableLocalScreenshots().AppBundle(GetIDEAppPath(AppPath)).StartApp();
            }
        }

        private static string GetIDEAppPath(string appPath)
        {
            var startupPathVisualStudio = Environment.CurrentDirectory;
            var startupPathRider = AppDomain.CurrentDomain.BaseDirectory;

            var ideAppPath = Path.Combine(startupPathRider, appPath);

            if (!File.Exists(ideAppPath))
            {
                Console.WriteLine("Trying file path for Visual Studio.");
                ideAppPath = Path.Combine(startupPathVisualStudio, appPath);
            }

            return ideAppPath;
        }
    }
}