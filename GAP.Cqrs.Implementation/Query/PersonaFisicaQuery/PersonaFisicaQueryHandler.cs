using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query.PersonaFisicaQuery;
using GAP.Cqrs.Implementation.QueryResult.PersonaFisicaResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.PersonaFisicaHandler
{
    public class PersonaFisicaQueryHandler : IQueryHandler<PersonaFisicaByFilterQuery, PersonaFisicaQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public PersonaFisicaQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public PersonaFisicaQueryResult Retrieve(PersonaFisicaByFilterQuery query)
        {
            PersonaFisicaQueryResult result = new PersonaFisicaQueryResult();

            var querySession = _repositryLocalScheme.Session.CallFunction<PersonaFisicaDto>("PR_OBTENER_PERSONA_FISICA(?,?,?)")
                                .SetParameter(0, query.SexoId == null ? null : "0" + query.SexoId.ToString())
                                .SetParameter(1, query.Documento == null ? null : query.Documento.ToString())
                                .SetParameter(2, query.TipoDocumentoId == null ? null : query.TipoDocumentoId.ToString());

            result.PersonasFisicas = (List<PersonaFisicaDto>)querySession.List<PersonaFisicaDto>();

            //result.PersonasFisicas = PersonaFisicaMocked.GetInstance().GetMocked();//TODO:Quitar cuando este la funcion

            return result;
        }
    }
}
