
using Castle.Core;
using Castle.MicroKernel.Registration;
using GAP.CqrsCore.Commands;
using GAP.Infraestructure.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
   public class IOCCommandHandler: IConfigurator
    {

        public void Configure(Castle.Windsor.IWindsorContainer container)
        {
            container.Register(Component.For<TransactionAspectCommandHandler>());

            container.Register(Component.For(typeof(CommandDispatcher))
             .LifeStyle.Transient.Interceptors(InterceptorReference.ForType<TransactionAspectCommandHandler>()).Anywhere);


            container.Register(Classes.FromAssemblyNamed("GAP.Cqrs.Implementation")
                .BasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            //container.Register(Classes.FromAssemblyNamed("GAP.Cqrs.Implementation").InNamespace("GAP.Cqrs.Implementation.CommandHandler")
            //    .OrBasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

        }
    }
}
