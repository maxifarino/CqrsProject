using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Query.BandejaSalasCunaQuery
{
    public class SalasCunaBandejaByIdQuery : IQuery
    {
        public Int64 IdSalaCuna { get; set; }
        public string CodigoSalaCuna { get; set; }
    }
}
