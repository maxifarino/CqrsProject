using Castle.MicroKernel.Registration;
using GAP.Repository.Cidi;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Infraestructure
{
    public class IOCRepository : IConfigurator
    {
        public void Configure(Castle.Windsor.IWindsorContainer container)
        {
            //container.Register(Classes.FromAssemblyNamed("GAP.DataAcces").InNamespace("GAP.DataAcces.IRepository").LifestyleTransient());

            container.Register(Component.For(typeof(RepositoryLocalScheme)).LifestyleSingleton());
            container.Register(Component.For(typeof(RepositoryCidi)).LifestyleSingleton());
        }
    }
}
