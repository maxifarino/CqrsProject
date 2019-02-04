using GAP.Base.Enumerations;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.AdministrarLugarOrigenQuery
{
   public class LugarDeOrigenQuery:IQuery
    {
       public LugarOrigenStateEnum StateOrigen { get; set; }
       public string PaisId { get; set; }
       public string ProvinciaId { get; set; }
       public decimal DepartamentoId { get; set; }
    }
}
