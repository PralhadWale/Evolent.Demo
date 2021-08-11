using Evolent.Demo.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evolent.Demo.Data.Core
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        long Add(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
    }
}
