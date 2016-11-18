using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eXam.Services;
using eXam.UWP;

[assembly:Xamarin.Forms.Dependency(typeof(HockeyAppEventService_UWP))]
namespace eXam.UWP
{
    public class HockeyAppEventService_UWP : IHockeyEventService
    {
        public void TrackEvent(string eventName)
        {
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(eventName);
        }
    }
}
