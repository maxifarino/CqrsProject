using GAP.Base;
using GAP.Base.AttributeCustom;
using GAP.Base.Dto;
using GAP.Base.Enumerations;
using GAP.Base.Mock;
using GAP.Cqrs.Implementation.Query.TablaSatelitesQuery;
using GAP.Cqrs.Implementation.QueryResult;
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
    public class TablaSatelitesGenericClassQueryHandler : IQueryHandler<TablaSatelitesGenericClassQuery, TablaSatelitesGenericClassQueryResult>
    {
        private readonly RepositoryLocalScheme _repositryLocalScheme;
        ExecuteCallSp _ExecuteCallSp { get; set; }
        TablaSatelitesGenericClassQueryResult queryResult;

        public TablaSatelitesGenericClassQueryHandler(RepositoryLocalScheme repositryLocalScheme)
        {
            _repositryLocalScheme = repositryLocalScheme;
        }


        public TablaSatelitesGenericClassQueryResult Retrieve(TablaSatelitesGenericClassQuery query)
        {
            _ExecuteCallSp = new ExecuteCallSp();
            queryResult = new TablaSatelitesGenericClassQueryResult();
            queryResult.ListOfListDto = _ExecuteCallSp.Execute(query.ListTablaSatelites, queryResult.ListOfListDto, _repositryLocalScheme);

            return queryResult;
        }
    }


    public class ExecuteCallSp
    {

        public ExecuteCallSp()
        {
        }

        public List<List<IdNombreDto>> Execute(List<TablaSateliteEnum> ListTablaSatelites, List<List<IdNombreDto>> listPassed, RepositoryLocalScheme _repositryLocalScheme)
        {
            var name = "";
            var namesp = "";

            foreach (TablaSateliteEnum itemEnum in ListTablaSatelites)
            {
                var enumType = itemEnum.GetType();
                name = Enum.GetName(enumType, itemEnum);
                namesp = (enumType.GetField(name).GetCustomAttributes(false)[0] as CallSpAttribute).NameSp;

                if(GlobalVars.MockedMode)
                    listPassed.Add(GetResultMocked(itemEnum));
                else
                    listPassed.Add(GetResult(ref namesp, _repositryLocalScheme));
            }

            return listPassed;
        }


        private List<IdNombreDto> GetResult(ref string nameSp, RepositoryLocalScheme _repositryLocalScheme)
        {


            var query1 = _repositryLocalScheme.Session.CallFunction<IdNombreDto>(nameSp);

            return (List<IdNombreDto>)query1.List<IdNombreDto>();
        }


        private List<IdNombreDto> GetResultMocked(TablaSateliteEnum itemEnum)
        {
            TablaSateliteMocked tablaSateliteDefault = TablaSateliteMocked.GetInstance();
            return tablaSateliteDefault.GetMocked(itemEnum);
        }

    }

}
