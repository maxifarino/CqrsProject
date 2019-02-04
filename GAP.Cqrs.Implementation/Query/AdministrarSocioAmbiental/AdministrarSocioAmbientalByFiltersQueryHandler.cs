using GAP.Base.Dto;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarSocioAmbiental
{
    public class AdministrarSocioAmbientalByFiltersQueryHandler : IQueryHandler<VerSocioAmbientalByFiltersQuery, AdministrarSocioAmbientalByFiltersQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private DateTime fechaHoy = DateTime.Today;
        public AdministrarSocioAmbientalByFiltersQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public AdministrarSocioAmbientalByFiltersQueryResult Retrieve(VerSocioAmbientalByFiltersQuery query)
        {
            QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            var queryResult = new AdministrarSocioAmbientalByFiltersQueryResult();

            //Call
            var querySession = _repositryLocalScheme
             .Session
             .CallFunction<BeneficiarioSADto>("PR_OBTENER_BENEFICIARIO_SA (?,?)").SetParameter(0, query.BenefeciarioId)
             .SetParameter(1, query.TipoSocioAmbiental);

            queryResult.Beneficiario = (BeneficiarioSADto)querySession.UniqueResult<BeneficiarioSADto>();

            if (queryResult.Beneficiario != null)
            {
                //queryResult.Beneficiario.Edad = DateTime.Today.AddTicks(-queryResult.Beneficiario.FechaNacimiento.Ticks).Year - 1;

               // DateTime oldDate = new DateTime(2002, 7, 15);
                DateTime newDate = DateTime.Now;
                if (queryResult.Beneficiario.FechaNacimiento.HasValue)
                {
                    TimeSpan ts = newDate - queryResult.Beneficiario.FechaNacimiento.Value;
                    int dias = ts.Days - 1;
                    int anios = dias / 365;
                    int meses = dias / 30;

                    if (dias >= 0)
                    {
                        if (anios >= 1)
                        {
                            queryResult.Beneficiario.Edad = anios;
                            queryResult.Beneficiario.TipoEdad = "años";
                        }
                        else
                        {
                            if (dias < 30)
                            {
                                queryResult.Beneficiario.Edad = dias;
                                queryResult.Beneficiario.TipoEdad = "días";
                            }

                            else
                            {
                                queryResult.Beneficiario.Edad = meses;
                                queryResult.Beneficiario.TipoEdad = "meses";

                            }

                        }
                    }
                }
                
                

               
                   


                


                if (queryResult.Beneficiario.IdSocioAmbiental.HasValue)
                {
                    queryResult.SocioAmbiental = _queryDispatcher.Dispatch<VerSocioAmbientalByFiltersQuery, VerSocioAmbientalByFiltersQueryResults>(query).SocioAmbiental;


                }
            
            }
            

            

            return queryResult;
        }




    }
}
