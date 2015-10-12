using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class CompositeTypeRepository : IRepository<CompositeTypeEntity>
    {
        private readonly List<CompositeTypeEntity> data;

        public CompositeTypeRepository()
        {
            data = new List<CompositeTypeEntity>
            {
                new CompositeTypeEntity
                {
                    BoolValue = false,
                    StringValue = "some data "
                }
            };
        }

        public bool Create(CompositeTypeEntity entity)
        {
            this.data.Add(entity);
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompositeTypeEntity> Read()
        {
            return this.data.ToList();
        }

        public bool Update(int id, CompositeTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
