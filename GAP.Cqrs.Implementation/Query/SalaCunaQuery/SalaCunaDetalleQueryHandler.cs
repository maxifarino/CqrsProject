using GAP.Base;
using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.Query.AdministrarConvenios;
using GAP.Cqrs.Implementation.Query.AdministrarRequisitos;
using GAP.Cqrs.Implementation.Query.BandejaSalasCunaQuery;
using GAP.Cqrs.Implementation.Query.DomicilioQuery;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.Cqrs.Implementation.Query.SalitaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios;
using GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.Inmueble;
using GAP.Cqrs.Implementation.QueryResult.SalasCunaQueryResult;
using GAP.Cqrs.Implementation.QueryResult.SalitaCunaQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.SalasCuna
{
    public class SalaCunaDetalleQueryHandler : IQueryHandler<SalaCunaDetalleQuery, SalaCunaDetalleQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaDetalleQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalaCunaDetalleQueryResult Retrieve(SalaCunaDetalleQuery query)
         {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new SalaCunaDetalleQueryResult();
                        
            var querySession = _repositryLocalScheme.Session.CallFunction<SalaCunaDetalleDto>("PR_OBTENER_DETALLE_SC (?,?) ")

            .SetParameter(0, query.IdSalaCuna)
            .SetParameter(1, GlobalVars.IdApplication);

            var resultado = (List<SalaCunaDetalleDto>)querySession.List<SalaCunaDetalleDto>();
            queryResult.SalaCunaDetalleDto = resultado.First();

            //si se requiere traer toda la informacion de la sala cuna,
            //cargo todas las listas de la misma (requisitos, convenios, inmuebles)
            if (query.Completo)
            {
                //convenios
                var queryConvenios = new ConveniosDeSalaByFiltersQuery { SalaCunaId = (int)query.IdSalaCuna };
                var resultadoConvenios = _queryDispatcher.Dispatch<ConveniosDeSalaByFiltersQuery, ConveniosDeSalaCunaQueryResult>(queryConvenios);

                queryResult.SalaCunaDetalleDto.Convenios = resultadoConvenios.ConveniosDeSalaCunaDto;
                //fin convenios

                //requisitos
                var queryRequisitos = new RequisitosDeSalaByFiltersQuery { IdSalaCuna = (int)query.IdSalaCuna };
                var resultadoRequisitos = _queryDispatcher.Dispatch<RequisitosDeSalaByFiltersQuery, RequisitosDeSalaCunaQueryResult>(queryRequisitos);

                queryResult.SalaCunaDetalleDto.Requisitos = resultadoRequisitos.RequisitosDeSalaCunaDto;
                //fin requisitos

                //inmuebles
                var queryInmuebles = new InmuebleByFiltersQuery { SalaCunaId = (int)query.IdSalaCuna };
                var resultadoInmuebles = _queryDispatcher.Dispatch<InmuebleByFiltersQuery, InmuebleByFiltersQueryResult>(queryInmuebles);

                queryResult.SalaCunaDetalleDto.Inmuebles = resultadoInmuebles.InmueblesDto;
                //fin inmuebles

                //salitas
                var querySalitas = new SalitaCunaAdminBenQuery { SalaCunaId = (int)query.IdSalaCuna, SeleccionBaja = 0 };
                var resultadoSalitas = _queryDispatcher.Dispatch<SalitaCunaAdminBenQuery, SalitaCunaAdminBenQueryResult>(querySalitas);

                queryResult.SalaCunaDetalleDto.Salitas = resultadoSalitas.SalitasCunaDto;
                //salitas

                //domicilio
                var queryDomicilio = new DomicilioByFilterQuery { IdDomicilio = Convert.ToString(queryResult.SalaCunaDetalleDto.DomicilioId)};
                var resultadoDomicilio = _queryDispatcher.Dispatch<DomicilioByFilterQuery, DomicilioEditQueryResult>(queryDomicilio);

                queryResult.SalaCunaDetalleDto.Torre = resultadoDomicilio.Domicilio.Torre;
                queryResult.SalaCunaDetalleDto.Manzana = resultadoDomicilio.Domicilio.Manzana;
                queryResult.SalaCunaDetalleDto.Lote = resultadoDomicilio.Domicilio.Parcela;
               //domicilio
            }

            return queryResult;
         }
    }
}
