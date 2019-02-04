

using Castle.Windsor;
using System.Collections.Generic;
using GAP.Base.Dto;

namespace GAP.CqrsCore.Querys
{
    public class QueryFilter : IQuery
    {
        //public Filter Filter { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int? PaginationFrom { 
            get {
                return (!PageNumber.HasValue || !PageSize.HasValue) ? 0 : PageNumber * PageSize.Value;  
            } 
        }
        public int? PaginationTo { 
            get {
                return (!PageNumber.HasValue || !PageSize.HasValue) ? 0 : ((PageNumber + 1) * PageSize.Value) + 1; 
            } 
        }
    }
}