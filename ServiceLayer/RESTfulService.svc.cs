using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RESTfulService : IRestfulService
    {
        private static List<CompositeType> data;

        static RESTfulService()
        {
            data = new List<CompositeType>
            {
                new CompositeType
                {
                    BoolValue = false,
                    StringValue = "some data #1"
                }
            };
        }

        public List<CompositeType> GetData(string value)
        {
            return data;
        }

        public CompositeType AddData(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }

            data.Add(composite);

            return composite;
        }
    }
}
