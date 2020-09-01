using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using ObjCRuntime;
using MvvmAspire.Services;

namespace MvvmAspire
{
    public class Bootstrap
    {
        static iOSGlobals globals;

		public static HardwareVersion Version { get; private set; }

        public static void Init()
        {
            globals = new iOSGlobals();
            int scaleFactor = (int)(UIScreen.MainScreen.Scale * 100);
            globals.ResolutionScale = (ResolutionScale)scaleFactor;
            if (UIScreen.MainScreen.RespondsToSelector(new Selector("nativeBounds")))
            {
				if (globals.ResolutionScale == ResolutionScale.Scale300Percent && 
					Runtime.Arch == Arch.DEVICE &&
					UIScreen.MainScreen.NativeBounds.Width == 1080)
				{ // for iPhone 6 Plus
					globals.ScreenHeight = (double)UIScreen.MainScreen.NativeBounds.Height * 1.15;
					globals.ScreenWidth = (double)UIScreen.MainScreen.NativeBounds.Width * 1.15;
				}
				else
				{
					globals.ScreenHeight = (double)UIScreen.MainScreen.NativeBounds.Height;
					globals.ScreenWidth = (double)UIScreen.MainScreen.NativeBounds.Width;
				}
            }
            else
            {
                globals.ScreenHeight = (double)(UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale);
                globals.ScreenWidth = (double)(UIScreen.MainScreen.Bounds.Width * UIScreen.MainScreen.Scale);
            }

            string appName = (NSString)NSBundle.MainBundle.InfoDictionary.ObjectForKey(new NSString("CFBundleName"));
            globals.ApplicationName = appName;
            string version = (NSString)NSBundle.MainBundle.InfoDictionary.ObjectForKey(new NSString("CFBundleShortVersionString"));
            globals.Version = new System.Version(string.IsNullOrEmpty(version) ? "0.0.1" : version);
            string bundleName = (NSString)NSBundle.MainBundle.BundleIdentifier;
            globals.PackageName = bundleName;
            globals.OSVersion = UIDevice.CurrentDevice.SystemName + " " + UIDevice.CurrentDevice.SystemVersion;
			globals.Build = DeviceHardware.Version;
			Version = DeviceHardware.GetHardwareVersion(globals.Build);
			globals.Model = DeviceHardware.GetDisplayVersion(Version, globals.Build);
			globals.Manufacturer = "Apple";
			globals.UserAgent = string.Format("{0}/{1} ({2}; {3}/{4})", globals.ApplicationName,
				globals.Version, globals.OSVersion, globals.Model, globals.Build);

            globals.DocumentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            globals.LibraryFolder = System.IO.Path.Combine(globals.DocumentsFolder, "..", "Library");
            globals.CountryCode = GetCountryCode();
            
            Globals.SetGlobals(globals);

            RegisterDependencies();

            // Force setting of default language.
            var lng = Globals.Language;
        }

        public static string GetCountryCode()
        {
            NSLocale locale = NSLocale.CurrentLocale;
            return locale.CountryCode.ToUpper();
        }

        static void LifecycleEvents_Resume(object sender, EventArgs e)
        {
            globals.RunningInBackground = false;
        }

        static void LifecycleEvents_Sleep(object sender, EventArgs e)
        {
            globals.RunningInBackground = true;
        }

        public static void RegisterDependencies()
        {

            Resolver.Register<IEncryptionService, EncryptionService>();
        }

        class iOSGlobals : CommonGlobals
        {
            private string dbFolder;
            public override string DatabasesFolder
            {
                get
                {
                    if (string.IsNullOrEmpty(dbFolder))
                    {
                        dbFolder = System.IO.Path.Combine(this.LibraryFolder, "Databases");
                        if (!System.IO.Directory.Exists(dbFolder))
                        {
                            System.IO.Directory.CreateDirectory(dbFolder);
                        }
                    }
                    return dbFolder;
                }
                set
                {

                }
            }

            public override string GetDefaultLanguage()
            {
				return NSLocale.CurrentLocale.LanguageCode;
            }
        }
    }
}