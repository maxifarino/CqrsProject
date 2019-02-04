using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.DataAcces.Conventions
{
    public class ColumnNameConvention : IPropertyConvention
    {

        public void Apply(IPropertyInstance instance)
        {

            string columnName = ConventionUtils.CamelCaseToUnderscore(instance.Property.Name);

            if (instance.Type == typeof(string))
            {
                columnName = "N_" + columnName;
            }

            if (instance.Type == typeof(char))
            {
                columnName = "N_BL_" + columnName;
            }

            if (instance.Type == typeof(DateTime))
            {
                columnName = "FEC_" + columnName;
            }

            instance.Column(columnName);
            //instance.
        }
    }
}
