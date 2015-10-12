using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> Read();
        bool Create(TEntity entity);
        bool Update(int id, TEntity entity);
        bool Delete(int id);
    }
}
