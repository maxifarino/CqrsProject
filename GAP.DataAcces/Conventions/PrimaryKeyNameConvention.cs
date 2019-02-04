using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.DataAcces.Conventions
{
    public class PrimaryKeyNameConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            string primaryKeyName = ConventionUtils.CamelCaseToUnderscore(instance.EntityType.Name);
            instance.Column("ID_" + primaryKeyName);
        }
    }
}
