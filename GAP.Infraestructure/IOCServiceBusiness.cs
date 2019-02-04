using Castle.MicroKernel.Registration;
using GAP.Visitor.Implementation.ServiceBusinessStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
    public class IOCServiceBusiness : IConfigurator
    {

        public void Configure(Castle.Windsor.IWindsorContainer container)
        {
            //container.Register(Classes.FromAssemblyNamed("GAP.Visitor.Implementation").InNamespace("GAP.Visitor.Implementation.ServiceBusinessStructure").LifestyleTransient());

            container.Register(Classes.FromAssemblyNamed("GAP.Visitor.Implementation")
                .BasedOn(typeof(ServiceBusinessEstructureBase<>)).WithService.AllInterfaces().LifestyleTransient());
        }
    }
}
