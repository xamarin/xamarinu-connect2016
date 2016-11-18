using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using eXam.Services;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

[assembly:MetaData("net.hockeyapp.android.appIdentifier", Value= HockeyAppHelper.AppIds.HockeyAppId_droid)]
namespace eXam.Droid
{
    [Activity(Label = "eXam", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            InitializeHockeyApp();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            LoadApplication(new App());
        }

        private void InitializeHockeyApp()
        {
            CrashManager.Register(this);
            MetricsManager.Register(Application);
        }
    }
}

