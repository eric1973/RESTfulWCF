using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceLayer
{
    /// <summary>
    /// A singleton service. Service will allow only one call at a time.
    /// </summary>
   [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single, 
        ConcurrencyMode = ConcurrencyMode.Single)]
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
                    StringValue = "some data "
                }
            };
        }

        private List<CompositeType> InnerGetData(string value)
        {
            return data;
        }

        public List<CompositeType> GetJsonData(string value)
        {
            return this.InnerGetData(value);
        }

        public List<CompositeType> GetXmlData(string value)
        {
            return this.InnerGetData(value);
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
