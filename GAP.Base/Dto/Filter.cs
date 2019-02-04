using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Dto
{
    public class Filter
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PaginationFrom { get { return PageNumber * PageSize; } }
        public int PaginationTo { get { return ((PageNumber + 1) * PageSize) + 1; } }
    }
}
