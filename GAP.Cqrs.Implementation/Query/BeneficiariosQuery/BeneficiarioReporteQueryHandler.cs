using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Beneficiario;
using GAP.Base.Mock;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BeneficiariosQuery
{
    public class BeneficiarioReporteQueryHandler : IQueryHandler<BeneficiarioReporteQuery, BeneficiarioReporteQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public BeneficiarioReporteQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public BeneficiarioReporteQueryResult Retrieve(BeneficiarioReporteQuery query)
        {
            var queryResult = new BeneficiarioReporteQueryResult();

            if (GlobalVars.MockedMode)
            {
                BeneficiarioDtoMocked beneficiarioMocked = BeneficiarioDtoMocked.GetInstance();
                queryResult.Beneficiarios = beneficiarioMocked.GetReporteMocked();
            }
            else
            {
                Int64 cero = 0;


                var querySession = _repositryLocalScheme.Session.CallFunction<BeneficiarioReporteDto>("PR_REPORTE_BENEFICIARIOS (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

                .SetParameter(0, query.FechaDesde)
                .SetParameter(1, query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : query.FechaHasta)
                .SetParameter(2, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
                .SetParameter(3, query.SalaCunaId != null ? query.SalaCunaId : -1)
                .SetParameter(4, query.Codigo)
                .SetParameter(5, query.NroDocumento)
                .SetParameter(6, query.DadosBaja ? 'S' : 'N')
                .SetParameter(7, query.DepartamentoId != cero ? query.DepartamentoId : -1)
                .SetParameter(8, query.LocalidadId != cero ? query.LocalidadId : -1)
                .SetParameter(9, query.BarrioId != cero ? query.BarrioId : -1)
                .SetParameter(10, query.SituacionCritica)
                .SetParameter(11, query.TipoBeneficiario != null ? query.TipoBeneficiario : "0")
                .SetParameter(12, query.TipoDocumentoId)
                .SetParameter(13, query.PageNumber != null ? query.PaginationFrom : 0)
                .SetParameter(14, query.PageNumber != null ? query.PaginationTo : 10000)
                .SetParameter(15, -1);

                queryResult.Beneficiarios = (List<BeneficiarioReporteDto>)querySession.List<BeneficiarioReporteDto>();

                //var querySession2 = _repositryLocalScheme.Session.CallFunction<ContadorDto>("PR_CONS_REP_BENEF_COUNT(?,?,?,?,?,?,?,?,?,?,?,?,?)")

                //.SetParameter(0, query.FechaDesde)
                //.SetParameter(1, query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : query.FechaHasta)
                //.SetParameter(2, query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1)
                //.SetParameter(3, query.SalaCunaId != null ? query.SalaCunaId : -1)
                //.SetParameter(4, query.Codigo)
                //.SetParameter(5, query.NroDocumento)
                //.SetParameter(6, query.DadosBaja ? 'S' : 'N')
                //.SetParameter(7, query.DepartamentoId != cero ? query.DepartamentoId : -1)
                //.SetParameter(8, query.LocalidadId != cero ? query.LocalidadId : -1)
                //.SetParameter(9, query.BarrioId != cero ? query.BarrioId : -1)
                //.SetParameter(10, query.SituacionCritica)
                //.SetParameter(11, query.TipoBeneficiario != null ? query.TipoBeneficiario : "0")
                //.SetParameter(12, query.TipoDocumentoId)
                //.SetParameter(13, -1);


                //ContadorDto contador = (ContadorDto)querySession2.UniqueResult();

                //if (contador.Contador != 0 && queryResult.Beneficiarios.Count != 0)
                //{
                //    queryResult.Beneficiarios[0].Contador = contador.Contador;

                //}
            }

            return queryResult;
        }
    }
}
