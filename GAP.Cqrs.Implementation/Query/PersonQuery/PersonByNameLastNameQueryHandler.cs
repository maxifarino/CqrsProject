using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.CqrsCore.Querys;

using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GAP.Cqrs.Implementation.QueryHandler
{
    public class PersonByNameLastNameQueryHandler : IQueryHandler<PersonByNameLastNameQuery, PersonByNameLastNameQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonByNameLastNameQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonByNameLastNameQueryResult Retrieve(PersonByNameLastNameQuery query)
        {
            var queryResult = new PersonByNameLastNameQueryResult();

            //IdNombreDto IdNombreDto = null;

            var queryOver = _repositryLocalScheme.Session.QueryOver<Person>();
            //    .WhereRestrictionOn(x => x.Name).IsLike("%" + query.Name + "%")
            //.SelectList(list => list
            //.Select(p => p.Name).WithAlias(() => IdNombreDto.Nombre))
            //.TransformUsing(Transformers.AliasToBean<IdNombreDto>());

            var list = (List<Person>)queryOver.List<Person>();

            //queryResult.PersonDto = (List<IdNombreDto>)queryOver.List<IdNombreDto>();

            return queryResult;
        }


        private void validateQuery() { }

    }

}


