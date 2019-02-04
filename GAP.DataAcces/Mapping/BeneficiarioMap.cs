using FluentNHibernate.Mapping;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.DataAcces.Mapping
{
    public class BeneficiarioMap : ClassMap<Beneficiario>
    {

        public BeneficiarioMap()
        {
            Table("T_BENEFICIARIOS");

            Id(x => x.Id).Column("ID_BENEFICIARIO").GeneratedBy.Sequence("SEQ_PERSONAS");
            //Map(x => x.Name).Column("NOMBRE");
            Map(x => x.Descripcion);
            Map(x => x.FechaAlta);
            Map(x => x.DescripcionLarga);
            Map(x => x.Obligatorio);
            Map(x => x.PersonId);
            //References(x => x.Person);
        }
    }
}
