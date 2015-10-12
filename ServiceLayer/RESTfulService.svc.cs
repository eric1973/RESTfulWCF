using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer;

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
        private static IRepository<CompositeTypeEntity> repository;

        static RESTfulService()
        {
            repository = new CompositeTypeRepository();
        }

        private List<CompositeType> InnerGetData(string value)
        {
            return repository.Read().Select<CompositeTypeEntity, CompositeType>(
                compositeEntity =>
                
                    new CompositeType
                    {
                        BoolValue = compositeEntity.BoolValue,
                        StringValue = compositeEntity.StringValue
                    }

                ).ToList();
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

            var entity = new CompositeTypeEntity
            {
                BoolValue = composite.BoolValue,
                StringValue = composite.StringValue
            };

            repository.Create(entity);

            return composite;
        }
    }
}
