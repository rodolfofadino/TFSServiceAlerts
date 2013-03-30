using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TFSServiceAlerts
{
    public class EventServiceListen:IEventServiceListen
    {
        public void Notify(string eventXml, string tfsIdentityXml)
        {
            var xml = XElement.Parse(eventXml);

            switch (xml.Name.LocalName)
            {
                case "CheckinEvent":
                    var checkinEvent = DeserializeXmlToType<CheckinEvent>(eventXml);
                    Console.WriteLine("Checkin");
                    Console.WriteLine("Autor:{0}",checkinEvent.Committer);
                    Console.WriteLine("Comments:{0}",checkinEvent.Comment);
                    Console.WriteLine("");
                    //TODO: persistir evento
                    break;
                case "BuildCompletionEvent":
                    var buildEvent = DeserializeXmlToType<BuildCompletionEvent>(eventXml);
                    Console.WriteLine("Build");
                    Console.WriteLine("Title:{0}",buildEvent.Title);
                    Console.WriteLine("Status:{0}",buildEvent.CompletionStatus);
                    Console.WriteLine("");
                    //TODO: persistir evento
                    break;
                default:
                    throw new NotSupportedException("Evento não suportado");
            }
        }

        private static T DeserializeXmlToType<T>(string eventXml) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(eventXml))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
    }
}
