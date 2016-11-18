using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eXam.Services
{
    public static class HockeyAppHelper
    {
        public static class AppIds
        {
            public const string HockeyAppId_iOS = "__HOCKEYAPP_IOS_APPID__";
            public const string HockeyAppId_droid = "__HOCKEYAPP_ANDROID_APPID__";
            public const string HockeyAppId_UWP = "__HOCKEYAPP_UWP_APPID__";
        }

        public static class Events
        {
            public const string ExamStarted = "User Started Exam";
        }

        public static void TrackEvent (string eventName)
        {
            if (Device.OS == TargetPlatform.Windows)
                DependencyService.Get<IHockeyEventService>()?.TrackEvent(eventName);
            else
                HockeyApp.MetricsManager.TrackEvent(eventName);
        }
    }
}
