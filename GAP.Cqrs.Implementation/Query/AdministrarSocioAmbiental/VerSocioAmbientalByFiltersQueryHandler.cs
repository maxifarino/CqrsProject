using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental
{
    public class VerSocioAmbientalByFiltersQueryHandler : IQueryHandler<VerSocioAmbientalByFiltersQuery, VerSocioAmbientalByFiltersQueryResults>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        public VerSocioAmbientalByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }

        public VerSocioAmbientalByFiltersQueryResults Retrieve(VerSocioAmbientalByFiltersQuery query)
        {
            var queryResult = new VerSocioAmbientalByFiltersQueryResults();
            try
            {
                //Call Caracteristicas socio ambiental
                var querySession = _repositryLocalScheme
                 .Session
                 .CallFunction<SocioAmbientalDto>("PR_OBTENER_SOCIOAMBIENTAL (?,?)").SetParameter(0, query.BenefeciarioId)
                 .SetParameter(1,query.TipoSocioAmbiental);


                queryResult.SocioAmbiental = querySession.List<SocioAmbientalDto>().First();

                //Call Lista Red Sosten Seleccionados
                var querySessionRedSosten = _repositryLocalScheme
                 .Session
                 .CallFunction<GridSocioAmbientalDto>("PR_OBTENER_RED_SOSTEN_BY_ID(?,?)").SetParameter(0, query.BenefeciarioId)
                 .SetParameter(1, query.TipoSocioAmbiental);
                queryResult.SocioAmbiental.LstRedSosten = (List<GridSocioAmbientalDto>)querySessionRedSosten.List<GridSocioAmbientalDto>();

                //Obtener Lista Ambientes Seleccionados
                var querySessionAmbiente = _repositryLocalScheme
                .Session
                .CallFunction<GridSocioAmbientalDto>("PR_OBTENER_AMBIENTE_BY_ID(?,?)").SetParameter(0, query.BenefeciarioId)
                .SetParameter(1, query.TipoSocioAmbiental);
                queryResult.SocioAmbiental.LstAmbiente = (List<GridSocioAmbientalDto>)querySessionAmbiente.List<GridSocioAmbientalDto>();
                //Obtener Lista Programa Seleccionados
                var querySessionPrograma = _repositryLocalScheme
                .Session
                .CallFunction<GridSocioAmbientalDto>("PR_OBTENER_CONTROL_MED_BY_ID(?,?)").SetParameter(0, query.BenefeciarioId)
                .SetParameter(1, query.TipoSocioAmbiental);
                queryResult.SocioAmbiental.LstPrograma = (List<GridSocioAmbientalDto>)querySessionPrograma.List<GridSocioAmbientalDto>();
                //Obtener Lista de los Situaciones de Crisis Seleccionados
                var querySessionCrisis = _repositryLocalScheme
                .Session
                .CallFunction<GridSocioAmbientalDto>("PR_OBTENER_SIT_CRISIS_BY_ID(?,?)").SetParameter(0, query.BenefeciarioId)
                .SetParameter(1, query.TipoSocioAmbiental);
                queryResult.SocioAmbiental.LstSituacionCrisis= (List<GridSocioAmbientalDto>)querySessionCrisis.List<GridSocioAmbientalDto>();

                return queryResult;

            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }


    }
}
