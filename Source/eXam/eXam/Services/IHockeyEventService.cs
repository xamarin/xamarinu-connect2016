using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXam.Services
{
    public interface IHockeyEventService
    {
        void TrackEvent(string eventName);
    }
}
