using _03.StringCountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace _03.StringCountConsoleHost
{
    class Program
    {
        static void Main()
        {
            Uri serviceAddress = new Uri("http://localhost:1234/calc");
            ServiceHost selfHost = new ServiceHost(typeof(StringCount), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                System.Console.WriteLine("The service is started at endpoint " + serviceAddress);

                System.Console.WriteLine("Press [Enter] to exit.");
                System.Console.ReadLine();
            }
        }
    }
}
