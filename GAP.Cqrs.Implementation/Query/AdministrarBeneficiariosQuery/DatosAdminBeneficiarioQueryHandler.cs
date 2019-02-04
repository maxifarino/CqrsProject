using GAP.Base.Dto;
using GAP.Cqrs.Implementation.Query.BeneficiariosQuery;
using GAP.Cqrs.Implementation.Query.SalaCunaQuery;
using GAP.Cqrs.Implementation.Query.SalitaCunaQuery;
using GAP.Cqrs.Implementation.QueryResult.Beneficiario;
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

namespace GAP.Cqrs.Implementation.QueryHandler.Beneficiario
{
    public class DatosAdminBeneficiarioQueryHandler : IQueryHandler<DatosAdminBeneficiarioQuery, DatosAdminBeneficiarioQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public DatosAdminBeneficiarioQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public DatosAdminBeneficiarioQueryResult Retrieve(DatosAdminBeneficiarioQuery query)
        {
            var queryResult = new DatosAdminBeneficiarioQueryResult();

            //Traigo los datos de la sala cuna
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            SalaCunaByIdQuery querySala = new SalaCunaByIdQuery()
            {
                IdSalaCuna = query.SalaCunaId
            };
            SalaCunaByIdQueryResult resultadoSala = _queryDispatcher.Dispatch<SalaCunaByIdQuery, SalaCunaByIdQueryResult>(querySala);
            queryResult.SalaCuna = resultadoSala.SalaCuna;


            //Traigo las salitas de una sala
            _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            SalitaCunaAdminBenQuery querySalitas = new SalitaCunaAdminBenQuery()
            {
                SalaCunaId = query.SalaCunaId,
                SeleccionBaja = query.SeleccionBaja
            };
            SalitaCunaAdminBenQueryResult resultadoSalitas = _queryDispatcher.Dispatch<SalitaCunaAdminBenQuery, SalitaCunaAdminBenQueryResult>(querySalitas);
            queryResult.SalitasCuna = resultadoSalitas.SalitasCunaDto;

            return queryResult;
        }
    }
}
