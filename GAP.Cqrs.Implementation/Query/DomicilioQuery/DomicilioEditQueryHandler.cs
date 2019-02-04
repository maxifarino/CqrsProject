using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.QueryHandler.Domicilio.States;
using GAP.Cqrs.Implementation.QueryResult.DomicilioQuery;
using GAP.CqrsCore.Querys;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.DomicilioQuery
{
    public class DomicilioEditQueryHandler: IQueryHandler<DomicilioByFilterQuery, DomicilioEditQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public DomicilioEditQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public DomicilioEditQueryResult Retrieve(DomicilioByFilterQuery query)
        {
            return GetDomicilioById(query);
        }


        public virtual DomicilioEditQueryResult GetDomicilioById(DomicilioByFilterQuery query)
        {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();

            var queryResult = new DomicilioEditQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<DomicilioDto>("PR_OBTENER_DOMICILIO_BY_ID (?)")

            .SetParameter(0, query.IdDomicilio);

            queryResult.Domicilio = (DomicilioDto)querySession.UniqueResult();
            if (queryResult.Domicilio != null) { 

            var getQuery = new DomicilioByFilterQuery { 
                DepartamentoId = (int)queryResult.Domicilio.DepartamentoId,
                ProvinciaId = "X",
                StateDomicilio = DomicilioStateEnum.Localidad 
            };

            queryResult.Localidades = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioQueryResult>(getQuery).Localidades;

            getQuery = new DomicilioByFilterQuery { DepartamentoId = (int)queryResult.Domicilio.DepartamentoId, LocalidadId = (int)queryResult.Domicilio.LocalidadId, StateDomicilio = DomicilioStateEnum.Barrio_TipoCalle };

            queryResult.Barrios = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioQueryResult>(getQuery).Barrios;
            queryResult.TipoCalles = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioQueryResult>(getQuery).TipoCalles;

            getQuery = new DomicilioByFilterQuery { DepartamentoId = (int)queryResult.Domicilio.DepartamentoId, LocalidadId = (int)queryResult.Domicilio.LocalidadId, TipoCalleId = (int)queryResult.Domicilio.TipoCalleId, StateDomicilio = DomicilioStateEnum.Calle };

            queryResult.Calles = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioQueryResult>(getQuery).Calles;
            }
            return queryResult;
        }

    }
}
