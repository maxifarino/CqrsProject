using Castle.MicroKernel.Registration;
using GAP.CqrsCore.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
    public class IOCQueryHandler : IConfigurator
    {

        public void Configure(Castle.Windsor.IWindsorContainer container)
        {

            container.Register(Component.For(typeof(QueryDispatcher))
             .LifeStyle.Transient);


            container.Register(Classes.FromAssemblyNamed("GAP.Cqrs.Implementation")
                .BasedOn(typeof(IQueryHandler<,>)).WithService.AllInterfaces().LifestyleTransient());

        }
    }
}
