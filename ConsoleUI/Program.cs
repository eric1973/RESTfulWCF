using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.ServiceReference1;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var wcfProxy = new RestfulServiceClient())
            {

                var data = wcfProxy.GetJsonData(value: "1");
                data = wcfProxy.GetXmlData(value: "2");

                var compositeInstance = new CompositeType
                {
                    BoolValue = true,
                    StringValue = "new data from consoleUI"
                };

                CompositeType result = wcfProxy.AddData(composite: compositeInstance);

                Console.WriteLine("Press any key to exit ...");
                Console.ReadKey();
            }
        }
    }
}
