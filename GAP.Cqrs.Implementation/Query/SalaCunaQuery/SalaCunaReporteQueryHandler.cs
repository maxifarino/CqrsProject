using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.SalasCuna;
using GAP.Base.Helper;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query.AdministrarConvenios;
using GAP.Cqrs.Implementation.Query.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.AdministrarConvenios;
using GAP.Cqrs.Implementation.QueryResult.AdministrarRequisitos;
using GAP.Cqrs.Implementation.QueryResult.Inmueble;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.SalaCunaQuery
{
    public class SalaCunaReporteQueryHandler : IQueryHandler<SalaCunaReporteQuery, SalaCunaReporteQueryResult>
    {

        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public SalaCunaReporteQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public SalaCunaReporteQueryResult Retrieve(SalaCunaReporteQuery query)
        {
            SalaCunaReporteQueryResult queryResult = new SalaCunaReporteQueryResult();
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();

            if (GlobalVars.MockedMode)
            {
                SalasCunaDtoMocked salasCunaMocked = SalasCunaDtoMocked.GetInstance();
                queryResult.SalasCuna = salasCunaMocked.GetReporteMocked();
            }
            else
            {
                Int64 cero = 0;

                var querySession = _repositryLocalScheme.Session.CallFunction<SalasCunaReporteDto>("PR_CONS_REP_SALAS_CUNA (?,?,?,?,?,?,?,?,?,?,?,?,?) ");

                querySession.SetParameter(0, DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde));
                querySession.SetParameter(1, DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta));
                querySession.SetParameter(2, query.PersonaJuridicaId != null? query.PersonaJuridicaId : -1);
                querySession.SetParameter(3, query.SalaCunaId != null ? query.SalaCunaId : -1);
                querySession.SetParameter(4, query.EstadoCorrecto ? 'S' : 'N');
                querySession.SetParameter(5, query.DadosBaja ? 'S' : 'N');
                querySession.SetParameter(6, query.DepartamentoId != cero ? query.DepartamentoId : -1 );
                querySession.SetParameter(7, query.LocalidadId != cero ? query.LocalidadId : -1);
                querySession.SetParameter(8, query.BarrioId != cero ? query.BarrioId : -1);
                querySession.SetParameter(9, query.Codigo);
                querySession.SetParameter(10, query.Zona == 0? 1 : query.Zona);
                querySession.SetParameter(11, query.PaginationFrom);
                querySession.SetParameter(12, query.PaginationTo);
                

                queryResult.SalasCuna = (List<SalasCunaReporteDto>)querySession.List<SalasCunaReporteDto>();

                foreach(SalasCunaReporteDto salaCuna in queryResult.SalasCuna)
                {
                    //convenios
                    var queryConvenios = new ConveniosDeSalaByFiltersQuery { SalaCunaId = (int) salaCuna.SalaCunaId };
                    var resultadoConvenios = _queryDispatcher.Dispatch<ConveniosDeSalaByFiltersQuery, ConveniosDeSalaCunaQueryResult>(queryConvenios);

                    salaCuna.Convenios = resultadoConvenios.ConveniosDeSalaCunaDto;
                    //fin convenios

                    //requisitos
                    var queryRequisitos = new RequisitosDeSalaByFiltersQuery { IdSalaCuna = (int) salaCuna.SalaCunaId };
                    var resultadoRequisitos = _queryDispatcher.Dispatch<RequisitosDeSalaByFiltersQuery, RequisitosReporteSalaCunaQueryResult>(queryRequisitos);

                    salaCuna.ListRequisitos = resultadoRequisitos.RequisitosPresentadosDto;
                    //fin requisitos

                    //inmuebles
                    var queryInmuebles = new InmuebleByFiltersQuery { SalaCunaId = (int) salaCuna.SalaCunaId };
                    var resultadoInmuebles = _queryDispatcher.Dispatch<InmuebleByFiltersQuery, InmuebleByFiltersQueryResult>(queryInmuebles);

                    double monto = 0;
                    foreach (InmuebleDto inmueble in resultadoInmuebles.InmueblesDto)
                    {
                        monto += inmueble.Monto;
                    }

                    salaCuna.MontoRefacciones = monto;
                    salaCuna.Inmuebles = resultadoInmuebles.InmueblesDto;
                    //fin inmuebles
                }

            }

            return queryResult;
        }
    }
}
