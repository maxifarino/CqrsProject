using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.DataAcces.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            string referenceName = ConventionUtils.CamelCaseToUnderscore(instance.Property.PropertyType.Name);
            instance.Column("ID_" + referenceName);
        }
    }
}
