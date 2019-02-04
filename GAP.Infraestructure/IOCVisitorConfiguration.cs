using Castle.MicroKernel.Registration;
using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
    public class IOCVisitorConfiguration : IConfigurator
    {
        public void Configure(Castle.Windsor.IWindsorContainer container)
        {
            //container.Register(Classes.FromAssemblyNamed("GAP.Visitor.Implementation").InNamespace("GAP.Visitor.Implementation.Visitor").LifestyleTransient());

            container.Register(Classes.FromAssemblyNamed("GAP.Visitor.Implementation")
                .BasedOn(typeof(VisitorBase)).WithService.AllInterfaces().LifestyleTransient());

        }
    }
}
