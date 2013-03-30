using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

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
