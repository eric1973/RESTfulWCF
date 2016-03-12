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
using ServiceLayer.DataContract;

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
                        Id = GetIntValue(value, compositeEntity.Id),
                        BoolValue = compositeEntity.BoolValue,
                        StringValue = compositeEntity.StringValue
                    }

                ).ToList();
        }

        private int GetIntValue(string value, int repositoryId)
        {
            int intValue;

            if (!Int32.TryParse(value, out intValue))
            {
                intValue = repositoryId;
            }

            return intValue;
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

        public bool DeleteData(string id)
        {
            int entityId = -1;

            try {

                entityId = Convert.ToInt32(id);

            } catch (Exception)
            {
                return false;
            }

            return repository.Delete(entityId);
        }

        public bool UpdateData(string id, CompositeType composite)
        {
            int entityId = -1;

            try
            {

                entityId = Convert.ToInt32(id);

            }
            catch (Exception)
            {
                return false;
            }

            var compositeEntity = new CompositeTypeEntity
            {
                Id = entityId,
                BoolValue = composite.BoolValue,
                StringValue = composite.StringValue
            };

            return repository.Update(entityId, compositeEntity);
        }
    }
}
