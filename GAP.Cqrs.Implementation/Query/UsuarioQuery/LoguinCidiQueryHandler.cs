using GAP.Base;
using GAP.Base.Dto;
using GAP.Base.Dto.Usuario;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.Cidi;
using GAP.Repository.LocalScheme;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler
{
    public class LoguinCidiQueryHandler : IQueryHandler<LoguinCidiQuery, LoguinCidiQueryResult>
    {
        private RepositoryCidi _repositryCidi;
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        LoguinCidiQueryResult _loguinCidiQueryResult;


        public LoguinCidiQueryHandler(RepositoryCidi repositoryCidi, RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryCidi = repositoryCidi;
            _repositryLocalScheme = repositryLocalScheme;
        }


        public LoguinCidiQueryResult Retrieve(LoguinCidiQuery query)
        {
            _loguinCidiQueryResult = new LoguinCidiQueryResult();

            //Busco el id del usuario logueado en base al cuil

            if (GlobalVars.MockedMode)
            {
                UsuarioDtoMocked usuarioDtoMocked = UsuarioDtoMocked.GetInstance();
                _loguinCidiQueryResult.UsuarioDto = usuarioDtoMocked.GetUsuarioById(query.Cuil.ToString());
            }
            else
            {
                var querySession = _repositryLocalScheme.Session.CallFunction<UsuarioCidiDto>("PR_OBTENER_USUARIO (?)")
                    .SetParameter(0, query.Cuil.ToString());

                _loguinCidiQueryResult.UsuarioDto = (UsuarioCidiDto)querySession.UniqueResult<UsuarioCidiDto>();
            }


            //Busco Los roles del usuario
            //TODO Alvaro reemplazar por una función
            //if (_loguinCidiQueryResult.UsuarioDto != null)
            //{
            //    QueryDispatcher _queryDispatcher = ServiceLocator.Current.GetInstance<QueryDispatcher>();
            //    ar queryConvenios = new ConveniosDeSalaByFiltersQuery { SalaCunaId = (int)query.IdSalaCuna };
            //    var resultadoConvenios = _queryDispatcher.Dispatch<ConveniosDeSalaByFiltersQuery, ConveniosDeSalaCunaQueryResult>(queryConvenios);


            //    _loguinCidiQueryResult.UsuarioDto.Roles = new List<RolDto>(){
            //        new RolDto(){
            //            Id = 1,
            //            Nombre = "Adminstrador"
            //        },
            //        new RolDto(){
            //            Id = 2,
            //            Nombre = "Supervisor"
            //        },
            //        new RolDto(){
            //            Id = 3,
            //            Nombre = "Operador"
            //        }
            //    };
            //}
            //Busco las funcionalidades a partir del cuil.
            if(GlobalVars.MockedMode)
            {
                FuncionalidadesDtoMocked funcionalidadesDtoMock = FuncionalidadesDtoMocked.GetInstance();
                _loguinCidiQueryResult.FuncionalidadesDto = funcionalidadesDtoMock.GetListMocked(Int64.Parse(query.Cuil));
            }
            else
            {
                var querySession = _repositryLocalScheme.Session.CallFunction<FuncionalidadDto>("PR_VALIDAR_USUARIO (?)")

                    .SetParameter(0, query.Cuil.ToString());

                _loguinCidiQueryResult.FuncionalidadesDto = (List<FuncionalidadDto>)querySession.List<FuncionalidadDto>();            
            }

            return _loguinCidiQueryResult;
        }
    }
}
