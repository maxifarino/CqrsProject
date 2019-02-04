using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
    public class GuyWire
    {
        private IWindsorContainer _container;
        private readonly IConfigurator[] _configurators = new IConfigurator[] {new IOCRepository(),
            new IOCCommandHandler(),new IOCVisitorConfiguration(),new IOCServiceBusiness(),new IOCQueryHandler()
        };

        public void Dewire()
        {
            if (_container != null)
                _container.Dispose();
        }

        public void Wire()
        {
            if (_container != null)
                Dewire();

            _container = new WindsorContainer();
            _container.Register(Castle.MicroKernel.Registration.Component.For<IWindsorContainer>().Instance(_container));

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(_container));
            _container.Register(Castle.MicroKernel.Registration.Component.For<IServiceLocator>().Instance(ServiceLocator.Current));

            foreach (IConfigurator configurator in _configurators)
                configurator.Configure(_container);

        }
    }
}
