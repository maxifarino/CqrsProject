using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery.States;
using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.QueryHandler.Domicilio.States;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.DomicilioQuery
{
    public class DomicilioByFiltersQueryHandler : IQueryHandler<DomicilioByFilterQuery, DomicilioQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public DomicilioByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public DomicilioQueryResult Retrieve(DomicilioByFilterQuery query)
        {
            return GetDomicilioByState(query);
        }


        public virtual DomicilioQueryResult GetDomicilioByState(DomicilioByFilterQuery query)
        {
            switch (query.StateDomicilio)
            {
                
                case DomicilioStateEnum.Departamento:
                    return StateDepartamento.GetInstance(_repositryLocalScheme).ExecuteState(query);

                case DomicilioStateEnum.Localidad:
                    return StateLocalidad.GetInstance(_repositryLocalScheme).ExecuteState(query);

                case DomicilioStateEnum.Barrio_TipoCalle:
                    return StateBarrio.GetInstance(_repositryLocalScheme).ExecuteState(query);

                case DomicilioStateEnum.Calle:
                    return StateCalle.GetInstance(_repositryLocalScheme).ExecuteState(query);

                case DomicilioStateEnum.Provincia:
                    return StateProvincia.GetInstance(_repositryLocalScheme).ExecuteState(query);
                case DomicilioStateEnum.DepartamentoProvincia:
                     return StateDepartamentoOrigen.GetInstance(_repositryLocalScheme).ExecuteState(query);
            }

            return default(DomicilioQueryResult);
        }

    }
}
