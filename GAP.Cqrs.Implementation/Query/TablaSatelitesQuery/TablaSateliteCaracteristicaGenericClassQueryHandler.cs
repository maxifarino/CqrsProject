using GAP.Base;
using GAP.Base.AttributeCustom;
using GAP.Base.Dto;
using GAP.Base.Enumerations;
using GAP.Cqrs.Implementation.Query.TablaSatelitesQuery;
using GAP.Cqrs.Implementation.QueryResult.TablaSateliteCaracteristicaQueryResult;
using GAP.Cqrs.Implementation.QueryResult.TablasSatelitesQueryResult;
using GAP.CqrsCore.Querys;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.QueryHandler.TablaSatelitesQueryHandler
{
   public class TablaSateliteCaracteristicaGenericClassQueryHandler:IQueryHandler<TablaSatelitesGenericClassQuery, TablaSateliteCaracteristicaGenericClassQueryResult>
    {
           private readonly RepositoryLocalScheme _repositryLocalScheme;
        ExecuteCallSp _ExecuteCallSp { get; set; }
        TablaSateliteCaracteristicaGenericClassQueryResult queryResult;

        public TablaSateliteCaracteristicaGenericClassQueryHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }


        public TablaSateliteCaracteristicaGenericClassQueryResult Retrieve(TablaSatelitesGenericClassQuery query)
        {
            _ExecuteCallSp = new ExecuteCallSp();
            queryResult = new TablaSateliteCaracteristicaGenericClassQueryResult();
            queryResult.ListOfListDtoCaracteristica = _ExecuteCallSp.Execute(query.ListTablaSatelites, queryResult.ListOfListDtoCaracteristica, _repositryLocalScheme);

            return queryResult;
        }
        public class ExecuteCallSp
        {

            public ExecuteCallSp()
            {
            }

            public List<List<IdNombreDtoCaracteristica>> Execute(List<TablaSateliteEnum> ListTablaSatelites, List<List<IdNombreDtoCaracteristica>> listPassed, RepositoryLocalScheme _repositryLocalScheme)
            {
                var name = "";
                var namesp = "";

                foreach (TablaSateliteEnum itemEnum in ListTablaSatelites)
                {
                    var enumType = itemEnum.GetType();
                    name = Enum.GetName(enumType, itemEnum);
                    namesp = (enumType.GetField(name).GetCustomAttributes(false)[0] as CallSpAttribute).NameSp;

                    listPassed.Add(GetResult(ref namesp, _repositryLocalScheme));
                }

                return listPassed;
            }


            private List<IdNombreDtoCaracteristica> GetResult(ref string nameSp, RepositoryLocalScheme _repositryLocalScheme)
            {


                var query1 = _repositryLocalScheme.Session.CallFunction<IdNombreDtoCaracteristica>(nameSp);

                return (List<IdNombreDtoCaracteristica>)query1.List<IdNombreDtoCaracteristica>();
            }

        }
    }
}
