using Evolent.Demo.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Text;
using Evolent.Demo.Data.Entity.Master;

namespace Evolent.Demo.Data.Core
{
    public class GenericRepository<TEntity> : BaseRepository, IGenericRepository<TEntity> where TEntity : class
    {

        public GenericRepository(string connectionString):base(connectionString)
        {

        }
        public long Add(TEntity entity)
        {
            using (IDbConnection dbConnection = base.GetConnection())
            {
                return dbConnection.Insert(entity);
            }
        }

        public bool Update(TEntity entity)
        {
            using (IDbConnection dbConnection = base.GetConnection())
            {
                return dbConnection.Update(entity);
            }

        }

        public bool Delete(TEntity entity)
        {
            using (IDbConnection dbConnection = base.GetConnection())
            {
                return dbConnection.Delete(entity);
            }

        }

        public IEnumerable<TEntity> GetAll()
        {
            using (IDbConnection dbConnection = base.GetConnection())
            {
               return dbConnection.GetAll<TEntity>();
            }
        }

        public TEntity Find(int id)
        {
            using (IDbConnection dbConnection = base.GetConnection())
            {
                return dbConnection.Get<TEntity>(id);
            }
        }
    }
}
