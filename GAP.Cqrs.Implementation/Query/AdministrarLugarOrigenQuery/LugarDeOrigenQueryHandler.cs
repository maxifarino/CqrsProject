using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery.States;
using GAP.Cqrs.Implementation.QueryHandler.Domicilio.States;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery
{
   public class LugarDeOrigenQueryHandler :IQueryHandler<LugarDeOrigenQuery, LugarDeOrigenQueryResult>
    {
       private readonly RepositoryLocalScheme _repositryLocalScheme;
        public LugarDeOrigenQueryResult Retrieve(LugarDeOrigenQuery query)
        {
            return GetLugarByState(query);
        }
        public LugarDeOrigenQueryHandler(RepositoryLocalScheme repository)
        {
            _repositryLocalScheme = repository;
        }
        public virtual LugarDeOrigenQueryResult GetLugarByState(LugarDeOrigenQuery query)
        {
            switch (query.StateOrigen)
            {

                case LugarOrigenStateEnum.Provincia:
                    return StateProvinciaOrigen.GetInstance(_repositryLocalScheme).ExecuteState(query);

              

                case LugarOrigenStateEnum.Localidad:
                    return StateLocalidadOrigen.GetInstance(_repositryLocalScheme).ExecuteState(query);

           
            }

            return default(LugarDeOrigenQueryResult);
        }
    }
}
