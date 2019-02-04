using GAP.Base;
using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.Personal
{
    public class AsistenciaPersonalByFilterQueryHandler : IQueryHandler<AsistenciaPersonalByFilterQuery, AsistenciaPersonalByFilterQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public AsistenciaPersonalByFilterQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public AsistenciaPersonalByFilterQueryResult Retrieve(AsistenciaPersonalByFilterQuery query)
        {
            var queryResult = new AsistenciaPersonalByFilterQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonalAsistenciaDto>("PR_OBTENER_ASIS_PERS_BY_FILTER(?,?,?,?,?)");

            querySession.SetParameter(0, query.CursoId);
            querySession.SetParameter(1, query.SalaCunaId == 0 ? -1 : query.SalaCunaId);
            querySession.SetParameter(2, query.Nombre);
            querySession.SetParameter(3, query.Apellido);
            querySession.SetParameter(4, query.Documento);

            queryResult.ListPersonal = (List<PersonalAsistenciaDto>)querySession.List<PersonalAsistenciaDto>();

            return queryResult;
        }
    }
}
