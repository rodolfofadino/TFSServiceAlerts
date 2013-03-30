using System;

namespace TFSServiceAlerts
{
    public class EventServiceListen:IEventServiceListen
    {
        public void Notify(string eventXml, string tfsIdentityXml)
        {
            throw new NotImplementedException();
        }
    }
}
