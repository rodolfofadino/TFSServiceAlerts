using System;
using System.ServiceModel;

namespace TFSServiceAlerts
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(EventServiceListen)))
            {
                host.Open();
                Console.WriteLine("Serviço iniciado");
                Console.ReadLine();
            }
        }
    }
}
