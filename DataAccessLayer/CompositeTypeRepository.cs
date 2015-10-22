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
                    Id = 1,
                    BoolValue = false,
                    StringValue = "some data "
                }
            };
        }

        public bool Create(CompositeTypeEntity entity)
        {
            var maxId = this.data.Count == 0 ? 0 : this.data.Max(item => item.Id);
            entity.Id = ++maxId;

            this.data.Add(entity);
            return true;
        }

        public bool Delete(int id)
        {
            bool removed = false;
            var removeableEntity = this.data.Where(item => item.Id == id).FirstOrDefault();

            if (removeableEntity != null)
            {
                this.data.Remove(removeableEntity);
                removed = true;
            }

            return removed;
        }

        public IEnumerable<CompositeTypeEntity> Read()
        {
            return this.data.ToList();
        }

        public bool Update(int id, CompositeTypeEntity entity)
        {
            bool updated = false;

            var updateableEntity = this.data.Where(item => item.Id == entity.Id).FirstOrDefault();

            if (updateableEntity != null)
            {
                updateableEntity.BoolValue = entity.BoolValue;
                updateableEntity.StringValue = entity.StringValue;
                updated = true;
            }

            return updated;
        }
    }
}
