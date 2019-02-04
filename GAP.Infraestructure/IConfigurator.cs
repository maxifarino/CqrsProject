using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
    public interface IConfigurator
    {
        void Configure(IWindsorContainer container);
    }
}
