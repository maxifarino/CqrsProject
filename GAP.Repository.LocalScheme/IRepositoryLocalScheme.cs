using GAP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Repository.LocalScheme
{
    public abstract class IRepositoryLocalScheme
    {
        public virtual TEntity GetById<TEntity>(int id) where TEntity : EntityBase
        {
            return default(TEntity);
        }

        public virtual void Create<TEntity>(TEntity entity) where TEntity : EntityBase
        { }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        { }

        public virtual void Delete(int id)
        { }

        public virtual void Delete<TEntity>(TEntity tentity) where TEntity : EntityBase
        { }
    }
}
