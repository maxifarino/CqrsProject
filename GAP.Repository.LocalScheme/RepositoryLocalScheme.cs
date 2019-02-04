using GAP.Base;
using GAP.Base.Dto;
using GAP.DataAcces;
using GAP.Domain;
using GAP.RepositoryBase;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Repository.LocalScheme
{
    public class RepositoryLocalScheme : IRepositoryLocalScheme, IRepository
    {

        public ISession Session
        {
            get { return NHSessionManager.Instance.GetSession(); }
        }

        public override TEntity GetById<TEntity>(int id)
        {
            TEntity entity = Session.Get<TEntity>(id);
            return entity;
        }

        public override void Create<TEntity>(TEntity entity)
        {
            Session.Save(entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            try
            {
                Session.SaveOrUpdate(entity);
            }
            catch (NonUniqueObjectException)
            {

                entity = Session.Merge(entity);
            }
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            this.Update(entity);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }


        public void SP()
        {
            var query1 = Session.CallFunction<IdNombreDto>("SP_OBTENER_PERSONAS (?)");
            query1.SetParameter(0, 2);

            var result2 = (List<IdNombreDto>)query1.List<IdNombreDto>();

        }

    }
}
